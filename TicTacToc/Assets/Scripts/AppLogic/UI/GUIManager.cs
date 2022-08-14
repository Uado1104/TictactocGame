using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GUIManager : MonoBehaviour
{
    public static void Init()
    {
        GameObject mainPanel = Resources.Load<GameObject>("UI/MainPanel");
        GameObject objMainPanel = Instantiate(mainPanel);
        objMainPanel.transform.SetParent(GameObject.Find("Canvas").transform, false);
        MainView mainView = objMainPanel.GetComponent<MainView>();
        mainView.GameObject = objMainPanel;
        MVC.RegisterView(mainView);
        mainView.Init();

        GameObject chessBoardObj = GameObject.Find("ChessBoard");
        ChessBoard chessBoard = chessBoardObj.GetComponent<ChessBoard>();
        MVC.RegisterView(chessBoard);
        chessBoard.GameObject = chessBoardObj;
        chessBoard.Init();
        objMainPanel.SetActive(false);

        string[] nameList = { "MenuPanel", "PausePanel", "EndPanel", "WinPanel", "SelectPanel" };
        for (int i = 0; i < nameList.Length; i++)
        {
            string name = nameList[i];
            GameObject res = Resources.Load<GameObject>("UI/" + name);
            GameObject obj = Instantiate(res);
            obj.SetActive(false);
            obj.transform.SetParent(GameObject.Find("Canvas").transform, false);
            if (name == "MenuPanel")
            {
                MenuView view = obj.GetComponent<MenuView>();
                view.GameObject = obj;
                MVC.RegisterView(view);
            }
            else if (name == "PausePanel")
            {
                PauseView view = obj.GetComponent<PauseView>();
                view.GameObject = obj;
                MVC.RegisterView(view);
            }
            else if (name == "EndPanel")
            {
                EndView view = obj.GetComponent<EndView>();
                view.GameObject = obj;
                MVC.RegisterView(view);
            }
            else if (name == "WinPanel")
            {
                WinView view = obj.GetComponent<WinView>();
                view.GameObject = obj;
                MVC.RegisterView(view);
            }
            else if (name == "SelectPanel")
            {
                SelectView view = obj.GetComponent<SelectView>();
                view.GameObject = obj;
                MVC.RegisterView(view);
            }
        }

    }
    public static void ShowView(string name)
    {
        Debug.Log(name);
        View view =  MVC.GetView(name);
        if (view != null)
        {
            GameObject obj = view.GameObject;
            obj.SetActive(true);
        }
    }

    public static void HideView(string name)
    {
        View view = MVC.GetView(name);
        if (view != null)
        {
            GameObject obj = view.GameObject;
            obj.SetActive(false);
        }
    }


}
