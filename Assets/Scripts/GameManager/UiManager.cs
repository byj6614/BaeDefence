using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UiManager : MonoBehaviour
{
    private EventSystem eventSystem;

    private Canvas popupUpCanvas;
    private Stack<PopupUI> popupStack;

    private void Awake()
    {
        eventSystem = GameManager.Resource.Instantiate<EventSystem>("UI/EventSystem");
        eventSystem.transform.parent = transform;

        popupUpCanvas = GameManager.Resource.Instantiate<Canvas>("UI/Canvas");
        popupUpCanvas.gameObject.name = "PopupCanvas";
        popupUpCanvas.sortingOrder = 100;
        popupStack = new Stack<PopupUI>();
    }

    public T ShowPopUpUI<T>(T popUPui) where T : PopupUI
    {
        if(popupStack.Count>0)
        {
            PopupUI prevUI = popupStack.Peek();
            prevUI.gameObject.SetActive(false);
        }
        T ui=GameManager.Pool.GetUI(popUPui);
        ui.transform.SetParent(popupUpCanvas.transform,false);

        popupStack.Push(ui);

        Time.timeScale = 0;
        return ui;
    }
    public T ShowPopUpUI<T>(string path) where T : PopupUI
    {
        T ui = GameManager.Resource.Load<T>(path);
        return ShowPopUpUI(ui);  
    }
    public void ClosePopUpUI()
    {
        PopupUI ui = popupStack.Pop();
        GameManager.Pool.Release(ui.gameObject);

        if(popupStack.Count>0)
        {
            PopupUI curUI=popupStack.Peek();
            curUI.gameObject.SetActive(true);
        }
        if(popupStack.Count ==0)
        {
            Time.timeScale = 1f;
        }
    }
}
