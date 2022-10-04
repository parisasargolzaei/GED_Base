using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceItemCommand : ICommand
{
    Vector3 position;
    Transform item;

    public PlaceItemCommand(Vector3 position, Transform item)
    {
        this.position = position;
        this.item = item;
    }
    
    public void Execute()
    {
        ItemPlacer.PlaceItem(item);
    }

    public void Redo()
    {
        ItemPlacer.RedoItem(position, item);
    }

    public void Undo()
    {
        ItemPlacer.RemoveItem(position);
    }
}
