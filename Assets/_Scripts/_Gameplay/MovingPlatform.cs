using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    // [SerializeField] GameObject[] movepoints;
    [SerializeField] List<GameObject> movepoints;
    int currentMovepointIndex = 0;
    Vector3 targetpoint;

    [SerializeField] float speed = 15f;

    // Update is called once per frame
    void Update()
    {
        // Checking the distance from the target z point to current z axis value of platform
        if(Mathf.Abs(movepoints[currentMovepointIndex].transform.position.z - transform.position.z) < .1f)
        {
            currentMovepointIndex++;
            if(currentMovepointIndex >= movepoints.Count)
            {
                currentMovepointIndex = 0;
            }
        }

        targetpoint = new Vector3(transform.position.x, transform.position.y, movepoints[currentMovepointIndex].transform.position.z);
        transform.position = Vector3.MoveTowards(transform.position, targetpoint, speed * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision other) 
    {
        if(other.gameObject.name == "Player")
        {
            other.gameObject.transform.SetParent(transform);
        }
    }

    private void OnCollisionExit(Collision other) 
    {
        if(other.gameObject.name == "Player")
        {
            other.gameObject.transform.SetParent(null);
        }
    }
}
