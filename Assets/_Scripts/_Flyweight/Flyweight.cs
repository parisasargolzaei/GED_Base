using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.InteropServices;

public class Flyweight : MonoBehaviour
{
    [DllImport("Plugin2")]
    private static extern float LoadFromFile(int j, string fileName);

    [DllImport("Plugin2")]
    private static extern int GetLines(string fileName);

    List<Item> allItems;

    string fileName;

    // Start is called before the first frame update
    void Start()
    {
        allItems = new List<Item>();
        allItems.Clear();

        fileName = Application.dataPath + "/save.txt";

        // LoadItems();
    }

    void LoadItems()
    {
        int numLines = GetLines(fileName);
        int maxItems = numLines/4;
        int infoSet = 0;

        // with flyweight
        // Item newitem = new Item();
        // float y = LoadFromFile(2, fileName);

        for(int j = 0; j < 10000; j++)
        {
            for(int i = 0; i < maxItems; i++)
            {
                // without flyweight
                Item newitem = new Item();

                newitem.itemID = (int) LoadFromFile(0 + infoSet, fileName);
                newitem.itemPosition.x = LoadFromFile(1 + infoSet, fileName);
                newitem.itemPosition.y = LoadFromFile(2 + infoSet, fileName);
                newitem.itemPosition.z = LoadFromFile(3 + infoSet, fileName);

                // with flyweight
                // newitem.itemID = (int) LoadFromFile(0 + infoSet, fileName);
                // newitem.itemPosition.x = LoadFromFile(1 + infoSet, fileName);
                // newitem.itemPosition.y = y;
                // newitem.itemPosition.z = LoadFromFile(3 + infoSet, fileName);

                allItems.Add(newitem);

                infoSet += 4;
            }

            infoSet = 0;
        }

        Debug.Log(allItems.Count);
    }

}
