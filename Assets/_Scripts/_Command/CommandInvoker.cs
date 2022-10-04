using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommandInvoker : MonoBehaviour
{
    PlayerAction inputAction;

    static Queue<ICommand> commandBuffer;

    static List<ICommand> commandHistory;
    static int counter;

    Subject subject = new Subject();

    private void Start() 
    {
        commandBuffer = new Queue<ICommand>();
        commandHistory = new List<ICommand>();

        inputAction = PlayerInputController.controller.inputAction;

        inputAction.Editor.Undo.performed += cntxt => UndoCommand();
        inputAction.Editor.Redo.performed += cntxt => RedoCommand();
    }

    public static void AddCommand(ICommand command)
    {
        while(commandHistory.Count > counter)
        {
            commandHistory.RemoveAt(counter);
        }
        
        commandBuffer.Enqueue(command);
    }

    // Update is called once per frame
    void Update()
    {
        if (commandBuffer.Count > 0)
        {
            ICommand c = commandBuffer.Dequeue();
            c.Execute();

            commandHistory.Add(c);
            counter++;
            Debug.Log("Command history length: " + commandHistory.Count);
        }
    }

    public void UndoCommand()
    {
        if(commandBuffer.Count <= 0)
        {
            if (counter > 0)
            {
                counter--;
                commandHistory[counter].Undo();
            }
        }  
    }

    public void RedoCommand()
    {
        if(commandBuffer.Count <= 0)
        {
            if (counter < commandHistory.Count)
            {
                commandHistory[counter].Redo();
                counter++;
            }
        }    
    }
}
