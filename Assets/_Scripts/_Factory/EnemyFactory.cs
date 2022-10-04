using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System.Reflection;
using System;
using TMPro;

public class EnemyFactory : MonoBehaviour
{
    public GameObject enemy1Prefab;
    public GameObject enemy2Prefab;

    public GameObject buttonPanel;
    public GameObject buttonPrefab;

    List<Enemy> enemies;
    
    // Start is called before the first frame update
    void Start()
    {
        var enemyTypes = Assembly.GetAssembly(typeof(Enemy)).GetTypes().Where(myType => myType.IsClass && !myType.IsAbstract && myType.IsSubclassOf(typeof(Enemy)));

        enemies = new List<Enemy>();

        foreach(var type in enemyTypes)
        {
            var tempEffect = Activator.CreateInstance(type) as Enemy;
            enemies.Add(tempEffect);
        }

        ButtonPanel();
    }

    public Enemy GetEnemy(string enemyType)
    {

        foreach(Enemy enemy in enemies)
        {
            // Debug.Log(enemy.Name);
            if(enemy.Name == enemyType)
            {
                Debug.Log("enemy found");
                var target = Activator.CreateInstance(enemy.GetType()) as Enemy;

                return target;
            }
        }

        return null;
    }

    public void ButtonPanel()
    {
        foreach(Enemy enemy in enemies)
        {
            var button = Instantiate(buttonPrefab);
            button.transform.SetParent(buttonPanel.transform);
            button.gameObject.name = enemy.Name + " Button";
            button.GetComponentInChildren<TextMeshProUGUI>().text = enemy.Name;
        }
    }
}
