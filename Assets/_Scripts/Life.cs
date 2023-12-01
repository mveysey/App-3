using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Life : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {

            LivesManager lifeManager = FindObjectOfType<LivesManager>();
            if (lifeManager != null)
            {
                lifeManager.GainLife();
            }


            Destroy(gameObject);
        }
    }
}