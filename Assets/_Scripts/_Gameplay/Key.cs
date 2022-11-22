using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    GameplayManager gameplay;

    // Start is called before the first frame update
    void Start()
    {
        gameplay = GameplayManager.gameplay;
    }

    private void OnCollisionEnter(Collision other) {
        if(other.gameObject.name == "Player")
        {
            gameplay.WinPanelToggle();
        }
    }
}
