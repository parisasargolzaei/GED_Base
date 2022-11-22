using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class EditorManager : MonoBehaviour
{
    public static EditorManager instance;

    public PlayerAction inputAction;

    public Camera mainCam;
    public Camera editorCam;

    public bool editorMode = false;

    Vector3 mousePos;
    public GameObject prefab1;
    public GameObject prefab2;
    public GameObject item;
    public TMP_InputField yInput;
    public float ypos = 0f;
    public bool instantiated = false;

    //Edited
    public int unit = 1;
    Vector3 defaultPos;

    // Command
    ICommand command;

    // UIManager
    UIManager ui;

    private void Awake() {
        if(instance == null)
        {
            instance = this;
        }

        //Edited
        defaultPos = new Vector3(0, editorCam.transform.position.y, 0);
    }

    // Start is called before the first frame update
    void Start()
    {
        inputAction = PlayerInputController.controller.inputAction;

        inputAction.Editor.EditorMode.performed += cntxt => EnterEditorMode();

        // Edited
        inputAction.Editor.DropItem.performed += cntxt => DropItem();

        mainCam.enabled = true;
        editorCam.enabled = false;  

        ui = GetComponent<UIManager>();
    }  

    public void EnterEditorMode()
    {
        mainCam.enabled = !mainCam.enabled;
        editorCam.enabled = !editorCam.enabled;

        ui.ToggleEditorUI();
    }

    // AddItem() was removed

    public void DropItem()
    {
        if(editorMode && instantiated)
        {
            if(item.GetComponent<Rigidbody>())
            {
                item.GetComponent<Rigidbody>().useGravity = true;
            }
            item.GetComponent<Collider>().enabled = true;

            // Add item transform to items list
            command = new PlaceItemCommand(item.transform.position, item.transform);
            CommandInvoker.AddCommand(command);

            instantiated = false; 
        }        
    }

    // Update is called once per frame
    void Update()
    {
        // Edited
        // Checking if we are in editor mode
        if(mainCam.enabled == false && editorCam.enabled == true)
        {
            // Stop all movement in game
            Time.timeScale = 0;
            editorMode = true;  

            // Making cursor visible when in editor mode
            Cursor.lockState = CursorLockMode.None;          
        }
        else if(GameplayManager.gameplay.isDead || GameplayManager.gameplay.isWon)
        {
            // Stop all movement in game
            Time.timeScale = 0;

            // Making cursor visible when in editor mode
            Cursor.lockState = CursorLockMode.None;  
        }
        else
        {
            Time.timeScale = 1;
            editorMode = false;

            // Making cursor invisible when in play mode
            Cursor.lockState = CursorLockMode.Locked;
        }

        if(instantiated)
        {
            ypos = int.Parse(yInput.text);
            mousePos = Mouse.current.position.ReadValue();
            mousePos = new Vector3(mousePos.x, mousePos.y, editorCam.transform.position.y - ypos);
 
            item.transform.position = editorCam.ScreenToWorldPoint(mousePos);
        }
        
    }

    // Added
    public void MoveCameraPos(string direction)
    {
        switch (direction)
        {
            case "up":
                editorCam.transform.Translate(transform.forward * unit, Space.World);
                break;
            case "down":
                editorCam.transform.Translate(transform.forward * -unit, Space.World);
                break;
            case "left":
                editorCam.transform.Translate(transform.right * -unit, Space.World);
                break;
            case "right":
                editorCam.transform.Translate(transform.right * unit, Space.World);
                break;
            case "reset":
                editorCam.transform.position = defaultPos;
                break;
            default:
                break;
        }
    }
}
