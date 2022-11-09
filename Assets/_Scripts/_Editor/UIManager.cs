using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public Canvas editorUI;
    public Canvas gameplayUI;

    bool editorMode;

    // Start is called before the first frame update
    void Start()
    {
        editorMode = GetComponent<EditorManager>().editorMode;

        if(editorMode == false)
        {
            editorUI.enabled = false;
            gameplayUI.enabled = true;
        }
        else
        {
            editorUI.enabled = true;
            gameplayUI.enabled = false;
        }
    }

    public void ToggleEditorUI()
    {
        editorUI.enabled = !editorUI.enabled;
        gameplayUI.enabled = !gameplayUI.enabled;
    }
}
