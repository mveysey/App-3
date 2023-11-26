using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class EndGame : MonoBehaviour
{

    private void OnTriggerEnter(Collider other) {
        if (other.tag == "Player") 
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }

     public void LoadScene ()
    {
        SceneManager.LoadScene("TitleScreen");
    }
    
    public void QuitGame()
    {
        Application.Quit();
    }
}
