using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class HomeUIManager : MonoBehaviour
{
    private EventSystem eventSystem;

    private Canvas popUpCanvas;
    private Stack<HomePop> popupStack;
    private void Awake()
    {
        eventSystem = GameManager.Resource.Instantiate<EventSystem>("HomeUI/EventSystem");
        eventSystem.transform.parent = transform;

        popUpCanvas = GameManager.Resource.Instantiate<Canvas>("HomeUI/GameSetting");
        popUpCanvas.gameObject.name = "HomePopupCanvas";
        popUpCanvas.sortingOrder = 100;
        popupStack = new Stack<HomePop>();
    }

    public void ShowPopUpUI(HomePop popUpui)
    {
        if(popupStack.Count>0)
        {
            HomePop prevUI = popupStack.Peek();
            prevUI.gameObject.SetActive(false);
        }
        HomePop ui=GameManager.Pool.GetUI(popUpui);
        ui.transform.SetParent(popUpCanvas.transform, false);

        popupStack.Push(ui);

        Time.timeScale = 0;
    }

    public void ShowPopUpUI(string path)
    {
        HomePop ui = GameManager.Resource.Load<HomePop>(path);
        ShowPopUpUI(ui);
    }
    public void ClosePopUpUI()
    {
        HomePop ui = popupStack.Pop();
        GameManager.Pool.Release(ui.gameObject);

        if (popupStack.Count > 0)
        {
            HomePop curUI = popupStack.Peek();
            curUI.gameObject.SetActive(true);
        }
        if (popupStack.Count == 0)
        {
            Time.timeScale = 1f;
        }
    }
}
