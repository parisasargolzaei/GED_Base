using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadSave : MonoBehaviour
{
    string text;

    // Start is called before the first frame update
    void Start()
    {
        // text = Resources.Load(Application.dataPath + "/save.txt") as string;
        TextAsset mydata = Resources.Load(Application.dataPath + "/save") as TextAsset;
        Debug.Log(mydata);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
