using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Platform : MonoBehaviour
{
    protected int width;
    protected int height;
    protected GameObject clone;

    public abstract GameObject Spawn();
    public abstract Platform Clone();
}

public class CustomizablePlatform : Platform
{
    public CustomizablePlatform(GameObject clone, int width, int height)
    {
        this.clone = clone;
        this.width = width;
        this.height = height;
    }

    public override GameObject Spawn()
    {
        clone.transform.localScale = new Vector3(width, height, clone.transform.localScale.z);

        return clone;
    }

    public override Platform Clone()
    {
        return new CustomizablePlatform(Instantiate(clone), width, height);
    }
}
