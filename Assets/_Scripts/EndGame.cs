using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class EndGame : MonoBehaviour
{
   

    private void OnTriggerEnter(Collider other) {
        if (other.tag == "Player") 
        {
            // reset coins and lives 
            LivesManager livesManager = FindObjectOfType<LivesManager>();
            CoinManager coinsManager = FindObjectOfType<CoinManager>();
            if (livesManager != null)
            {
                livesManager.ResetLives();
                coinsManager.ResetCoins();
            }
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }

     public void LoadScene ()
    {
        SceneManager.LoadScene("GameOver");
    }
    
    public void QuitGame()
    {
        Application.Quit();
    }
}
