using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    public Button startButton;
    public Button levelsButton;
    public Button exitButton;

    void Start()
    {
        Button start = startButton.GetComponent<Button>();
        Button exit = exitButton.GetComponent<Button>();
        Button levels = levelsButton.GetComponent<Button>();

        start.onClick.AddListener(StartOnClick);
        exit.onClick.AddListener(ExitOnClick);
        levels.onClick.AddListener(LevelsOnClick);
    }

    void StartOnClick()
    {
        SceneManager.LoadScene("Tutorial");
    }

    void ExitOnClick()
    {
        Application.Quit();
    }

    void LevelsOnClick()
    {
        SceneManager.LoadScene("LevelSelector");
    }
}
