using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Bullet : MonoBehaviour
{
    CharacterStats playerStat;

    private void Awake() {
        playerStat = PlayerManager.instance.player.GetComponent<PlayerStats>();
    }

    private void OnEnable() {
        transform.GetComponent<Rigidbody>().WakeUp();
    }

    private void OnDisable() {
        transform.GetComponent<Rigidbody>().Sleep();
    }

    private void OnCollisionEnter(Collision other) {

        // Without object pooling
        // Destroy(gameObject);

        // With object pooling
        gameObject.SetActive(false);

        if(other.collider.tag == "Player")
        {
            playerStat.TakeDamage(playerStat.damage);
        } 
        else if(other.collider.tag == "Enemy")
        {
            Destroy(other.gameObject);
        }
    }
}
