using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TowerPlace : MonoBehaviour, IPointerClickHandler,IPointerExitHandler,IPointerEnterHandler
{
    [SerializeField] Color normal;
    [SerializeField] Color onMouse;
    private Renderer render;
    private void Awake()
    {
        render = GetComponent<Renderer>();
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        /*
        BuildInGameUI buildUI = GameManager.Ui.ShowInGameUI<BuildInGameUI>("UI/BuildInGame");
        buildUI.SetTarget(transform);
        buildUI.towerPlace = this;*/
        //0608°úÁ¦
        HomeBuild homeBuild = GameManager.Ui.ShowHInGameUI<HomeBuild>("HomeUI/HomeBuild");
        homeBuild.HomeTarget(transform);
        homeBuild.towerHplace=this;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        render.material.color = onMouse;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        render.material.color= normal;
    }

    public void BuildTower(TowerData data)
    {
        GameManager.Resource.Destroy(gameObject);
        GameManager.Resource.Instantiate(data.Towers[0].lv1Tower, transform.position, transform.rotation);
    }
}
