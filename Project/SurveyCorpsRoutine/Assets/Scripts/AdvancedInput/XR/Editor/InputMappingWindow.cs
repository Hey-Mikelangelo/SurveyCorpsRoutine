using UnityEngine;
using UnityEditor;
using System.Collections.Generic;
using CoreSystems.XR.Input;
using System;
using System.Linq;

public class InputMappingWindow : EditorWindow
{
    string[] toolbarTitles = { "action names", "action maps" };
    int toolbarId = 0;
    List<string> ActionNames = new List<string>();

    [MenuItem("Window/Input Mapping")]
    public static void ShowWindow()
    {
        GetWindow<InputMappingWindow>();
    }
    
    
    private void OnGUI()
    {
        GUIStyle toolbarButtonStyle = EditorStyles.toolbarButton;
        GUILayout.BeginHorizontal(toolbarButtonStyle);
        toolbarId = GUILayout.Toolbar(toolbarId, toolbarTitles);
        GUILayout.EndHorizontal();

        ActionNames = GetActionNames().ToList();
        switch (toolbarId)
        {
            case 0:
                DrawActionNamesWindow();
                break;
            case 1:
                DrawActionMapsWindow();
                break;

        }
        
    }  
    void DrawActionNamesWindow()
    {
        GUILayoutOption[] layoutOptions = { GUILayout.MaxWidth(200) };
        GUIStyle style = EditorStyles.toolbarButton;
        style.alignment = TextAnchor.UpperLeft;
        GUILayout.Space(10);
        GUILayout.BeginVertical(layoutOptions);
        foreach (String actionName in ActionNames)
        {
            if (GUILayout.Button(actionName, style))
            {

            }
        }
        GUILayout.EndArea();
    }
    void DrawActionMapsWindow()
    {

    }
    string[] GetActionNames()
    {
        return Enum.GetNames(typeof(ActionName));
    }
}
