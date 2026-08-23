using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransition : DinoBehaviourScript
{
    [SerializeField] protected SceneName sceneName;
    [SerializeField] protected Vector2 playerPos;
    [SerializeField] protected PlayerPos playerStorage;
    [SerializeField] protected PlayerHpSO playerHpSO;
    [SerializeField] protected ArrowSO arrowSO;
    [SerializeField] protected Inventory inventory;
    [SerializeField] protected Animator transAnim;
    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadPlayerPos();
        this.LoadPlayerHpSO();
        this.LoadArrowSO();
        this.LoadInventory();
        this.LoadAnimator();
    }
    protected void LoadPlayerPos()
    {
        if (this.playerStorage != null) return;
        this.playerStorage = Resources.Load<PlayerPos>("GameData/PlayerPos");
        Debug.Log(transform.name + ": LoadPlayerPos", gameObject);
    }
    protected void LoadPlayerHpSO()
    {
        if (this.playerHpSO != null) return;
        this.playerHpSO = Resources.Load<PlayerHpSO>("GameData/PlayerHpSO");
        Debug.Log(transform.name + ": LoadPlayerHpSO", gameObject);
    }
    protected void LoadArrowSO()
    {
        if (this.arrowSO != null) return;
        this.arrowSO = Resources.Load<ArrowSO>("GameData/ArrowSO");
        Debug.Log(transform.name + ": LoadArrowSO", gameObject);
    }
    protected void LoadInventory()
    {
        if (this.inventory != null) return;
        this.inventory = GameObject.Find("Player").GetComponentInChildren<Inventory>();
        Debug.Log(transform.name + ": LoadInventory", gameObject);
    }
    protected void LoadAnimator()
    {
        if (this.transAnim != null) return;
        this.transAnim = GetComponentInChildren<Animator>();
        Debug.Log(transform.name + ": LoadAnimator", gameObject);
    }
    protected void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.gameObject.CompareTag("Player")) return;
        this.SetHp();
        this.SetPos();
        this.SetInventory();
        this.SetArrowCount();
        this.NextLevel();
        AudioManagerr.Instance.FootStepSource.enabled = false;
    }
    protected void SetHp()
    {
        this.playerHpSO.currentHp = PlayerCtrl.Instance.PlayerDamReceive.Hp;
    }
    protected void SetPos()
    {
        this.playerStorage.intialValue = playerPos;
    }
    protected void SetInventory()
    {
        this.inventory.ClearInventory();
        this.inventory.SaveItems();
    }
    protected void SetArrowCount()
    {
        this.arrowSO.arrowCounts = ArrowPlayerSpawn.Instance.SpawnCount;
    }
    protected void NextLevel()
    {
        StartCoroutine(this.LoadLevel());
    }
    IEnumerator LoadLevel()
    {
        this.StopPlayerMovement();
        this.transAnim.SetTrigger("End");
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(this.sceneName.ToString());
        this.transAnim.SetTrigger("Start");
    }
    protected void StopPlayerMovement()
    {
        PlayerCtrl.Instance.PlayerMovement._Rb.constraints = RigidbodyConstraints2D.FreezeAll;
        PlayerCtrl.Instance.PlayerMovement.enabled = false;
        PlayerCtrl.Instance.PlayerMovement.SetHorizontal(0);
        PlayerCtrl.Instance.PlayerMovement.SetVertical(0);
        PlayerCtrl.Instance.PlayerAttack.enabled = false;
    }
}
