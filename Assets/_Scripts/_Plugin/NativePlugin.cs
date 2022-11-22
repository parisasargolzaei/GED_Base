using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.InteropServices;

public class NativePlugin : MonoBehaviour
{
    [DllImport("NativePlugin")]
    private static extern int GetID();

    [DllImport("NativePlugin")]
    private static extern void SetID(int id);

    [DllImport("NativePlugin")]
    private static extern Vector3 GetPosition();

    [DllImport("NativePlugin")]
    private static extern void SetPosition(float x, float y, float z);

    [DllImport("NativePlugin")]
    private static extern void SaveToFile(int id, float x, float y, float z);

    [DllImport("NativePlugin")]
    private static extern void StartWriting(string fileName);

    [DllImport("NativePlugin")]
    private static extern void EndWriting();

    public static NativePlugin plugin;

    PlayerAction inputAction;

    string m_Path;
    string fn;

    // Start is called before the first frame update
    void Start()
    {

        inputAction = PlayerInputController.controller.inputAction;

        inputAction.Editor.Save.performed += cntxt => SaveItems();

        // Edited
        if (Application.isEditor)
        {
            m_Path = Application.dataPath;
        }
        else
        {
            m_Path = Application.persistentDataPath;
        }

        Debug.Log(Application.persistentDataPath);
        
        fn = m_Path + "/save.txt";
    }

    void SaveItems()
    {
        StartWriting(fn);
        foreach(GameObject obj in GameObject.FindGameObjectsWithTag("SpikeBall"))
        {
            if(obj.name.Contains("SpikeBall1"))
            {
                SaveToFile(1, obj.transform.position.x, obj.transform.position.y, obj.transform.position.z);
            }
            else
            {
                SaveToFile(2, obj.transform.position.x, obj.transform.position.y, obj.transform.position.z);
            }
        }
        EndWriting();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
