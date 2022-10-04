using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPlacer : MonoBehaviour
{
    static List<Transform> items;

    public static void PlaceItem(Transform item)
    {
        Transform newitem = item;
        if (items == null){
            items = new List<Transform>();
        }
        items.Add(newitem);
    }

    public static void RedoItem(Vector3 position, Transform item)
    {
        if(item)
        {
            Transform newitem = Instantiate(item, position, Quaternion.identity);
            if (items == null){
                items = new List<Transform>();
            }
            items.Add(newitem);
        } 
    }

    public static void RemoveItem(Vector3 position)
    {
        for (int i = 0; i < items.Count; i++){
            if (items[i].position == position) 
            {
                GameObject.Destroy(items[i].gameObject);
                items.RemoveAt(i);
                break;
            }
        }
    }
}
