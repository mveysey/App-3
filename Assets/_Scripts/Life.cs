using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Life : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") || other.CompareTag("Sword"))
        {

            LivesManager lifeManager = FindObjectOfType<LivesManager>();
            if (lifeManager != null)
            {
                lifeManager.GainLife();
            }


            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Player") || other.gameObject.CompareTag("Sword"))
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