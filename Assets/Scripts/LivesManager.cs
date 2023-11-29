using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LivesManager : MonoBehaviour
{
    private int lives = 10;
    public GameObject[] lifeIcons; // life icons 


    private string livesKey = "PlayerLives";

    private void Start()
    {

        LoadPlayerLives();
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

        
        UpdateLifeIcons();
    }

    private void UpdateLifeIcons()
    {
        
        for (int i = 0; i < lifeIcons.Length; i++)
        {
            lifeIcons[i].SetActive(i < lives);
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
            lifeIcons[lives - 1].SetActive(false);
            lives--;

            
            SavePlayerLives(); // save to playerprefs
        }

        if (lives == 0)
        {
            Debug.Log("Game Over");
        }
    }

    public void HideHeartIcon(int index)
    {
        if (index >= 0 && index < lifeIcons.Length)
        {
            lifeIcons[index].SetActive(false);
        }
    }
}
