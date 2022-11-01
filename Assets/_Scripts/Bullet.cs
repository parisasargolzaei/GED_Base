using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Bullet : MonoBehaviour
{
    private void OnEnable() {
        transform.GetComponent<Rigidbody>().WakeUp();
    }

    private void OnDisable() {
        transform.GetComponent<Rigidbody>().Sleep();
    }

    private void OnCollisionEnter(Collision other) {
        // Destroy(gameObject);
        gameObject.SetActive(false);

        if(other.collider.tag == "Player")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        } else if(other.collider.tag == "Enemy")
        {
            Destroy(other.gameObject);
        }
    }
}
