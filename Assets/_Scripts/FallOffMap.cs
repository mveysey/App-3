using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FallOffMap : MonoBehaviour
{
    private Scene currentScene;

    private void Update()
    {
        currentScene = SceneManager.GetActiveScene();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            SceneManager.LoadScene(currentScene.name);
            // find lives manager object in the game 
            LivesManager livesManager = FindObjectOfType<LivesManager>();
            if (livesManager != null)
            {
                // loose live when falling off platform 
                livesManager.LoseLife();
            }
        }
    }
}
