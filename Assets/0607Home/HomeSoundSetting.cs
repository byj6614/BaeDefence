using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomeSoundSetting : HomePop
{
    protected override void Awake()
    {
        base.Awake();

        buttons["Save"].onClick.AddListener(() => { GameManager.Ui.ClosePopUpUI(); });
        buttons["Close"].onClick.AddListener(() => { GameManager.Ui.ClosePopUpUI(); });
    }
}
