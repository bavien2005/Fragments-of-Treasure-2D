using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RestartToggle : BaseToggle
{
    protected static RestartToggle instance;
    public static RestartToggle Instance => instance;

    [Header("Restart Toggle")]
    [SerializeField] protected Transform restartMenu;
    protected override void Awake()
    {
        base.Awake();
        if (RestartToggle.instance != null) Debug.LogWarning("Only 1 RestartToggle allow to exist");
        RestartToggle.instance = this;
    }
    protected override void Start()
    {
        base.Start();
        this.sceneTrans.gameObject.SetActive(true);
        this.restartMenu.gameObject.SetActive(false);
    }
    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadRestartMenu();
    }

    protected void LoadRestartMenu()
    {
        if (this.restartMenu != null) return;
        this.restartMenu = GameObject.Find("RestartMenu").transform;
        Debug.Log(transform.name + ": LoadRestartMenu", gameObject);
    }

    public void RestartGameMenu()
    {
        StartCoroutine(Wait2DisplayMenu());
    }

    IEnumerator Wait2DisplayMenu()
    {
        yield return new WaitForSeconds(3);
        this.sceneTrans.gameObject.SetActive(false);
        this.restartMenu.gameObject.SetActive(true);
        AudioManagerr.Instance.PlaySFX("GameOver");
    }
}
