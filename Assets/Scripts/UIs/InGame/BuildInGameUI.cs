using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildInGameUI : InGameUI
{
    public TowerPlace towerPlace;
    protected override void Awake()
    {
        base.Awake();

        buttons["Blocker"].onClick.AddListener(() => { GameManager.Ui.CloseInGameUI(this); });
        buttons["Bow"].onClick.AddListener(() => { BuildArchorTower(); });
        buttons["Bomb"].onClick.AddListener(() => { BuildCanonTower(); });
    }

    public void BuildArchorTower()
    {
        TowerData archorTowerData = GameManager.Resource.Load<TowerData>("Data/ArcherTowerData");
        towerPlace.BuildTower(archorTowerData);
        GameManager.Ui.CloseInGameUI(this);
    }

    public void BuildCanonTower()
    {
        TowerData canonTowerData = GameManager.Resource.Load<TowerData>("Data/CanonTowerData");
        towerPlace.BuildTower(canonTowerData);
        GameManager.Ui.CloseInGameUI(this);
    }
}

