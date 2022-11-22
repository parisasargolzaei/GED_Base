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

    // Edited
    // Will send notifications that something has happened to whoever is interested
    Subject subject = new Subject();

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
            // Edited
            case "spike1":
                editor.item = factory.GetEnemy("spike1").Create(factory.spike1Prefab);
                //Create boxes that can observe events and give them an event to do
                SpikeBall spike1 = new SpikeBall(editor.item, new GreenMat());
                //Add the boxes to the list of objects waiting for something to happen
                subject.AddObserver(spike1);
                break;
            case "spike2":
                editor.item = factory.GetEnemy("spike2").Create(factory.spike2Prefab);
                //Create boxes that can observe events and give them an event to do
                SpikeBall spike2 = new SpikeBall(editor.item, new YellowMat());
                //Add the boxes to the list of objects waiting for something to happen
                subject.AddObserver(spike2);
                break;
            default:
                break;
        }

        //Edited
        subject.Notify();
        editor.instantiated = true;     
    }
}
