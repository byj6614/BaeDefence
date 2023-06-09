using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingSceneUI : SceneUI
{
    protected override void Awake()
    {
        base.Awake();

        buttons["InfoButton"].onClick.AddListener(() => { OpenInfoWindowUI(); });
        buttons["SoundButton"].onClick.AddListener(() => { Debug.Log("Sound"); });
        buttons["SettingButton"].onClick.AddListener(() => { OpenPausePopUp(); });
    }

    public void OpenInfoWindowUI()
    {
        GameManager.Ui.ShowWindowUI("UI/InfoWindowUI");
        
        
    }
    public void OpenPausePopUp()
    {
        GameManager.Ui.ShowPopUpUI<PopupUI>("UI/SettingPopUp");
    }
   
   
}
