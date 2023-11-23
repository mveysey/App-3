using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseCanvas;

    public Button exitButton;
    public Button continueButton;
    public Button restartButton;

    private Scene currentScene;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            PauseGame();
        }
        currentScene = SceneManager.GetActiveScene();
    }

    void PauseGame()
    {
        pauseCanvas.SetActive(true);
        Time.timeScale = 0;

        Button continueBtn = continueButton.GetComponent<Button>();
        Button restart = restartButton.GetComponent<Button>();
        Button exit = exitButton.GetComponent<Button>();

        continueBtn.onClick.AddListener(ContinueGame);
        restart.onClick.AddListener(RestartGame);
        exit.onClick.AddListener(ExitGame);
    }

    void ContinueGame()
    {
        pauseCanvas.SetActive(false);
        Time.timeScale = 1;
    }

    void RestartGame()
    {
        pauseCanvas.SetActive(false);

        if(currentScene.name == "Level1")
        {
            SceneManager.LoadScene("Level1");
        }
        else if(currentScene.name == "Level2")
        {
            SceneManager.LoadScene("Level2");
        }
        else if (currentScene.name == "Level3")
        {
            SceneManager.LoadScene("Level3");
        }
        else if (currentScene.name == "Tutorial")
        {
            SceneManager.LoadScene("Tutorial");
        }
        else if (currentScene.name == "LevelSelector")
        {
            SceneManager.LoadScene("LevelSelector");
        }

        Time.timeScale = 1;
    }

    void ExitGame()
    {
        pauseCanvas.SetActive(false);
        Application.Quit();
    }
}
