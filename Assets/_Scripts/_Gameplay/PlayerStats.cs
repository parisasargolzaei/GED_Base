using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerStats : CharacterStats
{
    public bool isDead = false;
    public Animator animator;

    public override void Die()
    {
        base.Die();

        // isDead = true;

        // animator.SetTrigger("Death");
        
        // SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

        GameplayManager.gameplay.DeadPanelToggle();
        // Destroy(gameObject);
    }
}
