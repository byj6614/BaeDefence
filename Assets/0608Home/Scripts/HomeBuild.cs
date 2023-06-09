using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomeBuild : HomeInGame
{
    public TowerPlace towerHplace;

    protected override void Awake()
    {
        base.Awake();

      //  buttons["Blocker"].onClick.AddListener(() => { GameManager.Ui.CloseHInGameUI(this); });
        buttons["HBow"].onClick.AddListener(() => { });
    }
}
