using UnityEditor;
using UnityEngine;

public class BtnQuit : BaseButton
{
    protected override void OnClick()
    {
        Debug.Log("Thoat Game");
        Application.Quit();
    }
}
