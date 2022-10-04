using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EnemyButton : MonoBehaviour
{
    private EnemyFactory factory;

    private EditorManager editor;

    TextMeshProUGUI btnText;

    GameObject enemy;

    private void Start() 
    {
        factory = GameObject.Find("Game Manager").GetComponent<EnemyFactory>();

        editor = EditorManager.instance;

        btnText = GetComponentInChildren<TextMeshProUGUI>();
    }    

    public void OnClickSpawn()
    {
        switch(btnText.text)
        {
            case "crab":
                editor.item = factory.GetEnemy("crab").Create(factory.enemy1Prefab);
                break;
            case "monster":
                editor.item = factory.GetEnemy("monster").Create(factory.enemy2Prefab);
                break;
            default:
                break;
        }
        
        editor.instantiated = true;     
    }
}
