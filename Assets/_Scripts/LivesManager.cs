using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class LivesManager : MonoBehaviour
{
    private int lives = 10;
    public TextMeshProUGUI livesText; // reference to the UI text displaying lives

    private string livesKey = "PlayerLives";

    public AudioSource SFXAudioSource;
    public AudioClip getHit;
    public AudioClip getLife;

    private void Start()
    {
        LoadPlayerLives();
        UpdateLifeText();
    }

    private void SavePlayerLives()
    {
        PlayerPrefs.SetInt(livesKey, lives);
        PlayerPrefs.Save();
    }

    private void LoadPlayerLives()
    {
        if (PlayerPrefs.HasKey(livesKey))
        {
            lives = PlayerPrefs.GetInt(livesKey);
        }
        UpdateLifeText();
    }

    private void UpdateLifeText()
    {
        if (livesText != null)
        {
            livesText.text = "x" + lives;
        }
    }

    public int GetLives()
    {
        return lives;
    }

    public void LoseLife()
    {
        if (lives > 0)
        {
            SFXAudioSource.PlayOneShot(getHit);
            lives--;

            UpdateLifeText();
            SavePlayerLives(); // save to PlayerPrefs
        }

        // have another condition 
        if (lives == 0)
        {
            GameOver();
            Debug.Log("Game Over");
        }
    }

    public void LoseTwoLives()
    {
        if (lives >= 2)
        {
            SFXAudioSource.PlayOneShot(getHit);
            lives -=2;

            UpdateLifeText();
            SavePlayerLives(); // save to PlayerPrefs
        }
        else if (lives == 1)
        {
            PlayerPrefs.SetInt(livesKey, 0);
            UpdateLifeText();
            SavePlayerLives();
            GameOver(); 
            Debug.Log("Game Over");
        }
         
        if (lives == 0)
        {
            GameOver();
            Debug.Log("Game Over");
        }

    }
    public void GainLife()
    {
        if (lives < 10)
        {
            SFXAudioSource.PlayOneShot(getLife);
            lives++;

            UpdateLifeText();
            SavePlayerLives(); // save to PlayerPrefs
        }
    }

  
  
    public void ResetLives()
    {
        lives = 10;
        UpdateLifeText();


        PlayerPrefs.DeleteAll(); 
        

        PlayerPrefs.SetInt(livesKey, 10);
        PlayerPrefs.Save();
    }

    
    public void GameOver()
    {
        Debug.Log("Game Over");

        EndGame endGame = GetComponent<EndGame>();
        if (endGame != null)
        {
            ResetLives(); // reset lives there 
            SceneManager.LoadScene("GameOver");
        }
    }
}
