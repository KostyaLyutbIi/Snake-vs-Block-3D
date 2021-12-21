using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour
{
    private Vector2 _menuSize = new Vector2(500, 300);
    private float _buttonMinHeight = 60f;
    private Font _captionFont;
    private Font _buttonFont;
    private string _mainMenuText = "Menu";
    private string _startButtonText = "Start game";
    private string _exitButtonText = "Exit";

    [System.Obsolete]
    public void OnGUI()
    {
        Rect rect = new Rect(
            Screen.width / 2f - _menuSize.x / 2,
            Screen.height / 2f - _menuSize.y / 2,
            _menuSize.x,
            _menuSize.y);
        GUILayout.BeginArea(rect, GUI.skin.textArea);
        {
            GUIStyle captionStyle = new GUIStyle(GUI.skin.label);
            captionStyle.font = _captionFont;
            captionStyle.alignment = TextAnchor.MiddleCenter;
            captionStyle.fontSize = 70;

            GUILayout.Label(_mainMenuText, captionStyle);
            GUIStyle buttonStyle = new GUIStyle(GUI.skin.button);
            buttonStyle.font = _buttonFont;
            buttonStyle.margin = new RectOffset(20, 20, 3, 3);
            buttonStyle.fontSize = 40;
            
            GUILayout.FlexibleSpace();
            
            if (GUILayout.Button(_startButtonText, buttonStyle, GUILayout.MinHeight(_buttonMinHeight)))
            {
                Application.LoadLevel("Level 1");
            }

            GUILayout.FlexibleSpace();
            
            if (GUILayout.Button(_exitButtonText, buttonStyle, GUILayout.MinHeight(_buttonMinHeight)))
            {
                Application.Quit();
            }

            GUILayout.FlexibleSpace();
        }

        GUILayout.EndArea();
    }
}
