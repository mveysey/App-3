using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public Button exitButton;
    public Button restartButton;

    void Start()
    {
        Button restart = restartButton.GetComponent<Button>();
        Button exit = exitButton.GetComponent<Button>();

        restart.onClick.AddListener(RestartOnClick);
        exit.onClick.AddListener(ExitOnClick);
    }

    void RestartOnClick()
    {
        SceneManager.LoadScene("Level1");
    }

    void ExitOnClick()
    {
        Application.Quit();
    }
}
