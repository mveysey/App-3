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
        }
    }
}
