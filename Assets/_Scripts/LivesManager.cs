using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LivesManager : MonoBehaviour
{
    private int lives = 10;
    public TextMeshProUGUI livesText; // reference to the UI text displaying lives

    private string livesKey = "PlayerLives";

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
            lives--;

            UpdateLifeText();
            SavePlayerLives(); // save to PlayerPrefs
        }

        if (lives == 0)
        {
            Debug.Log("Game Over");
        }
    }

    public void GainLife()
    {
        if (lives < 10)
        {
            lives++;

            UpdateLifeText();
            SavePlayerLives(); // save to PlayerPrefs
        }
    }

   
}
