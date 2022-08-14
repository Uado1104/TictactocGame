using System;
using System.Text;
using System.Collections.Generic;
using UnityEngine;


public static class MVC
{
    public static EventCenter EventCenter;
    public static ChessModel ChessModel;
    public static OpponentModel OpponentModel;
    public static Dictionary<string, Model> Models = new Dictionary<string, Model>();
    public static Dictionary<string, View> Views = new Dictionary<string, View>();
    //public static Dictionary<string, Controller> CommondMap = new Dictionary<string, Controller>();

    public static void RegisterModel(Model model)
    {
        Models[model.Name] = model;
    }

    public static void RegisterView(View view)
    {
        Views[view.Name] = view;
    }

    public static Model GetModel<T>()
        where T: Model
    { 
        foreach(Model m in Models.Values)
        {
            if (m is T)
                return m;
        }
        return null;
    }

    public static View GetView(string name)
    {
        if (Views.ContainsKey(name)) return Views[name];
        return null;
    }

    public static void HideAllView()
    {
        foreach (var view in Views.Values)
        {
            GameObject obj = view.GameObject;
            obj.SetActive(false);
        }
    }

}
