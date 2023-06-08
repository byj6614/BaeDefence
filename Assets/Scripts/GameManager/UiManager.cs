using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UiManager : MonoBehaviour
{
    private EventSystem eventSystem;

    private Canvas popupUpCanvas;
    private Stack<PopupUI> popupStack;

    private Canvas windowCanvas;

    private Canvas inGameCanvas;
    private void Awake()
    {
        eventSystem = GameManager.Resource.Instantiate<EventSystem>("UI/EventSystem");
        eventSystem.transform.parent = transform;

        popupUpCanvas = GameManager.Resource.Instantiate<Canvas>("UI/Canvas");
        popupUpCanvas.gameObject.name = "PopupCanvas";
        popupUpCanvas.sortingOrder = 100;
        popupStack = new Stack<PopupUI>();

       windowCanvas = GameManager.Resource.Instantiate<Canvas>("UI/Canvas");
       windowCanvas.gameObject.name = "WindowCanvas";
       windowCanvas.sortingOrder = 10;

        //gameSceneCanvas.sortingOrder=1;

        inGameCanvas = GameManager.Resource.Instantiate<Canvas>("UI/Canvas");
        inGameCanvas.gameObject.name = "InGameCanvas";
        inGameCanvas.sortingOrder = 0;
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

    public void ShowWindowUI(WindowUI windowUI)
    {
        WindowUI ui = GameManager.Pool.GetUI(windowUI);
        ui.transform.SetParent(windowCanvas.transform, false);
    }
    public void ShowWindowUI(string path)
    {
        WindowUI ui = GameManager.Resource.Load<WindowUI>(path);
        ShowWindowUI(ui);
    }
    public void SelectWindowUI(WindowUI windowUI)
    {
        windowUI.transform.SetAsLastSibling();

    }
    public void CloseWindowUI(WindowUI windowUI)
    {
        GameManager.Pool.Release(windowUI.gameObject);
    }
    //0608°úÁ¦
    public void ShowHomeWindowUI(HomeWindow windowUI)
    {
        HomeWindow ui = GameManager.Pool.GetUI(windowUI);
        ui.transform.SetParent(windowCanvas.transform, false);
    }
    public void ShowHomeWindowUI(string path)
    {
        HomeWindow ui = GameManager.Resource.Load<HomeWindow>(path);
        ShowHomeWindowUI(ui);
    }
    public void CloseWindowUI(HomeWindow windowUI)
    {
        GameManager.Pool.Release(windowUI.gameObject);
    }
    public void SelectWindowUI(HomeWindow windowUI)
    {
        windowUI.transform.SetAsLastSibling();

    }
    public T ShowHInGameUI<T>(T inGameUI) where T : HomeInGame
    {
        T ui = GameManager.Pool.GetUI(inGameUI);
        ui.transform.SetParent(inGameCanvas.transform.transform, false);
        return ui;
    }

    public T ShowHInGameUI<T>(string Path) where T : HomeInGame
    {
        T ui = GameManager.Resource.Load<T>(Path);
        return ShowHInGameUI(ui);
    }
    public void CloseHInGameUI(HomeInGame inGameUI)
    {
        GameManager.Pool.Release(inGameUI.gameObject);
    }
    //
    public T ShowInGameUI<T>(T inGameUI) where T : InGameUI
    {
        T ui =GameManager.Pool.GetUI(inGameUI);
        ui.transform.SetParent(inGameCanvas.transform.transform, false);
        return ui;
    }

    public T ShowInGameUI<T>(string Path) where T : InGameUI
    {
        T ui = GameManager.Resource.Load<T>(Path);
        return ShowInGameUI(ui);
    }

    public void CloseInGameUI<T>(T inGameUI) where T : InGameUI
    {
        GameManager.Pool.Release(inGameUI.gameObject);
    }
}
