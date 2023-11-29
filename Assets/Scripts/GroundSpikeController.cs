using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundSpikeController : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // lose a life
        }
    }
}
