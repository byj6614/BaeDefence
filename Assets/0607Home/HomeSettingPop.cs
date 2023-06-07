using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomeSettingPop : HomePop
{
    protected override void Awake()
    {
        base.Awake();
        buttons["ContinueButton"].onClick.AddListener(() => { GameManager.Ui.ClosePopUpUI(); });
        buttons["SoundButton"].onClick.AddListener(() => { GameManager.Ui.ShowPopUpUI("HomeUI/SoundSetting"); });
    }
}
