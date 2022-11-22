using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour
{
    public int score = 0;
    public int heal = 0;

    private void OnCollisionEnter(Collision other) {
        if(other.collider.tag == "Player"){
            if(score == 0 && heal == 0)
            {
                GameplayManager.gameplay.WinPanelToggle();
            }
            else if(score != 0)
            {
                ScoreManager.instance.ChangeScore(score);
            }
            else if(heal != 0)
            {
                PlayerManager.instance.player.GetComponent<CharacterStats>().RecoverHealth(heal);
            }

            Destroy(gameObject);
        }  
    }
}
