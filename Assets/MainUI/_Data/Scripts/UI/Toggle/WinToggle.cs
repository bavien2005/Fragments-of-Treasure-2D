using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinToggle : BaseToggle
{
    protected static WinToggle instance;
    public static WinToggle Instance => instance;
    [Header("Win Toggle")]
    [SerializeField] protected Transform winMenu;
    [SerializeField] protected Transform playerMenu;
    protected override void Awake()
    {
        base.Awake();
        if (WinToggle.instance != null) Debug.LogWarning("Only 1 WinToggle allow to exist");
        WinToggle.instance = this;
    }
    protected override void Start()
    {
        base.Start();
        this.sceneTrans.gameObject.SetActive(true);
        this.winMenu.gameObject.SetActive(false);
    }
    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadWinMenu();
        this.LoadPlayerMenu();
    }

    protected void LoadWinMenu()
    {
        if (this.winMenu != null) return;
        this.winMenu = GameObject.Find("WinMenu").transform;
        Debug.Log(transform.name + ": LoadWinMenu", gameObject);
    }

    protected void LoadPlayerMenu()
    {
        if (this.playerMenu != null) return;
        this.playerMenu = GameObject.Find("UITopLeft/PlayerMenu").transform;
        Debug.Log(transform.name + ": LoadPlayerMenu", gameObject);
    }
    public void WinGameMenu()
    {
        StartCoroutine(Wait2DisplayMenu());
    }

    IEnumerator Wait2DisplayMenu()
    {
        yield return new WaitForSeconds(2);
        AudioManagerr.Instance.OpenMusic();
        this.sceneTrans.gameObject.SetActive(false);
        this.playerMenu.gameObject.SetActive(false);
        this.winMenu.gameObject.SetActive(true);
    }
}
