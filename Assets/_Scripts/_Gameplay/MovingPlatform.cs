using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    // Edited
    List<Vector3> movepoints;
    Vector3 point1;
    Vector3 point2;
    int currentMovepointIndex = 0;
    Vector3 targetpoint;

    [SerializeField] float speed = 15f;

    // Edited
    void Start() {
        movepoints = new List<Vector3>();

        point1 = new Vector3(0, 0, 40);
        point2 = new Vector3(0, 0, -40);

        movepoints.Add(point1);
        movepoints.Add(point2);
    }

    // Update is called once per frame
    void Update()
    {
        // Checking the distance from the target z point to current z axis value of platform
        // Edited
        if(Mathf.Abs(movepoints[currentMovepointIndex].z - transform.position.z) < .1f)
        {
            currentMovepointIndex++;
            if(currentMovepointIndex >= movepoints.Count)
            {
                currentMovepointIndex = 0;
            }
        }

        // Edited
        targetpoint = new Vector3(transform.position.x, transform.position.y, movepoints[currentMovepointIndex].z);
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
