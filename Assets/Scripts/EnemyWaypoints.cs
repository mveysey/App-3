using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWaypoints : MonoBehaviour
{
    public GameObject[] waypoints;
    private int current = 0;
    public float speed = 3f;
    private float waypointRadius = 1;

    private void Update()
    {
        if (SlimeEnemyController.GetLives() <= 0)
        {
            transform.position = Vector3.MoveTowards(transform.position, transform.position, 0);
        }

        else
        {
            if (Vector3.Distance(waypoints[current].transform.position, transform.position) < waypointRadius)
            {
                current++;
                if (current >= waypoints.Length)
                {
                    current = 0;
                }
            }

            transform.position = Vector3.MoveTowards(transform.position, waypoints[current].transform.position, Time.deltaTime * speed);
        }
    }
}
