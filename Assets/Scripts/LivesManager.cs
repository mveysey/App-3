using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class LivesManager : MonoBehaviour
{
    private int lives = 10;
    public GameObject[] lifeIcons; // life icons 
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

        }

        if (lives == 0)
        {
            Debug.Log("Game Over");

        }
    }
}
