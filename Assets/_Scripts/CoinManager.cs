using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CoinManager : MonoBehaviour
{
    private int coins = 0;
    public TextMeshProUGUI coinsText; // coin text 

    private string coinsKey = "PlayerCoins";

    private void Start()
    {
        LoadPlayerCoins();
        UpdateCoinsText();
    }

    // save to prefs 
    private void SavePlayerCoins()
    {
        PlayerPrefs.SetInt(coinsKey, coins);
        PlayerPrefs.Save();
    }

    private void LoadPlayerCoins()
    {
        if (PlayerPrefs.HasKey(coinsKey))
        {
            coins = PlayerPrefs.GetInt(coinsKey);
        }
        UpdateCoinsText();
    }

    // update txt 
    private void UpdateCoinsText()
    {
        if (coinsText != null)
        {
            coinsText.text = "x" + coins;
        }
    }

    public int GetCoins()
    {
        return coins;
    }

    public void CollectCoin()
    {
        coins++;
        // save to playerprefs 
        UpdateCoinsText();
        SavePlayerCoins(); 
    }

    

    private void ResetCoins()
    {
        coins = 0;
        UpdateCoinsText();

        PlayerPrefs.DeleteKey(coinsKey);
        PlayerPrefs.Save();
    }

    // game over 
    private void GameOver()
    {
        Debug.Log("Game Over");

        // reset coins to 0 again when game ends 
        ResetCoins();
    }
}