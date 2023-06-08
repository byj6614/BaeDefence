using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingPopUpUI : PopupUI
{
    protected override void Awake()
    {
        base.Awake();
        buttons["ContinueButton"].onClick.AddListener(()=>{ GameManager.Ui.ClosePopUpUI(); });
        buttons["SettingButton"].onClick.AddListener(() => { GameManager.Ui.ShowPopUpUI<PopupUI>("UI/ConfigPopUpUI"); });
    }
}
