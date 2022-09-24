using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class EditorManager : MonoBehaviour
{
    public static EditorManager instance;

    public PlayerAction inputAction;

    public Camera mainCam;
    public Camera editorCam;

    public bool editorMode;

    Vector3 mousePos;
    public GameObject prefab1;
    public GameObject prefab2;
    GameObject item;
    public bool instantiated = false;

    //Will send notifications that something has happened to whoever is interested
    Subject subject = new Subject();

    private void OnEnable() {
        inputAction.Enable();
    }

    private void OnDisable() {
        inputAction.Disable();
    }

    // Start is called before the first frame update
    void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }

        inputAction = new PlayerAction();

        inputAction.Editor.EditorMode.performed += cntxt => EnterEditorMode();

        inputAction.Editor.AddItem1.performed += cntxt => AddItem(1);
        inputAction.Editor.AddItem2.performed += cntxt => AddItem(2);
        inputAction.Editor.DropItem.performed += cntxt => DropItem();
               
        editorMode = false;

        mainCam.enabled = true;
        editorCam.enabled = false;  
    }  

    public void EnterEditorMode()
    {
        mainCam.enabled = !mainCam.enabled;
        editorCam.enabled = !editorCam.enabled;
    }

    public void AddItem(int itemId)
    {
        if(editorMode && !instantiated)
        {
            switch (itemId)
            {
                case 1:
                    item = Instantiate(prefab1);
                    //Create boxes that can observe events and give them an event to do
                    SpikeBall spike1 = new SpikeBall(item, new GreenMat());
                    //Add the boxes to the list of objects waiting for something to happen
                    subject.AddObserver(spike1);
                    break;
                case 2:
                    item = Instantiate(prefab2);
                    //Create boxes that can observe events and give them an event to do
                    SpikeBall spike2 = new SpikeBall(item, new YellowMat());
                    //Add the boxes to the list of objects waiting for something to happen
                    subject.AddObserver(spike2);
                    break;
                default:
                    break;
            }
            instantiated = true; 
        }        
    }

    public void DropItem()
    {
        if(editorMode && instantiated)
        {
            item.GetComponent<Rigidbody>().useGravity = true;
            item.GetComponent<Collider>().enabled = true;
            instantiated = false; 
        }        
    }

    // Update is called once per frame
    void Update()
    {
        if(mainCam.enabled == false && editorCam.enabled == true)
        {
            Time.timeScale = 0;
            editorMode = true;  
            Cursor.lockState = CursorLockMode.None;          
        }
        else
        {
            Time.timeScale = 1;
            editorMode = false;
            Cursor.lockState = CursorLockMode.Locked;
        }

        if(instantiated)
        {
            mousePos = Mouse.current.position.ReadValue();
            mousePos = new Vector3(mousePos.x, mousePos.y, 40f);
 
            item.transform.position = editorCam.ScreenToWorldPoint(mousePos);

            subject.Notify();
        }
        
    }
}
