using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    public abstract string Name {get;}
    
    public abstract GameObject Create(GameObject prefab);
}

public class Crab : Enemy
{
    // public override string Name { get { return "crab"; } }
    public override string Name => "crab";

    public override GameObject Create(GameObject prefab)
    {
        GameObject enemy = Instantiate(prefab);
        // Debug.Log("Crab enemy is created");
        return enemy;
    }
}

public class Monster : Enemy
{
    public override string Name => "monster";

    public override GameObject Create(GameObject prefab)
    {
        GameObject enemy = Instantiate(prefab);
        Debug.Log("Monster enemy is created");
        return enemy;
    }
}

// Edited
public class Spike1 : Enemy
{
    public override string Name => "spike1";

    public override GameObject Create(GameObject prefab)
    {
        GameObject enemy = Instantiate(prefab);
        Debug.Log("Spike1 enemy is created");
        return enemy;
    }
}

public class Spike2 : Enemy
{
    public override string Name => "spike2";

    public override GameObject Create(GameObject prefab)
    {
        GameObject enemy = Instantiate(prefab);
        Debug.Log("Spike2 enemy is created");
        return enemy;
    }
}
