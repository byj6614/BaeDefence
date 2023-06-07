using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConfigPopUpUI : PopupUI
{
    protected override void Awake()
    {
        base.Awake();

        buttons["SaveButton"].onClick.AddListener(()=> { GameManager.Ui.ClosePopUpUI(); });
        buttons["CancleButton"].onClick.AddListener(() => { GameManager.Ui.ClosePopUpUI(); });
    }
}
