using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundSpikeController : MonoBehaviour
{
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            // lose a life
        }
    }
}
