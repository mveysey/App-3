using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Level2Complete : MonoBehaviour
{
    public Button exitButton;
    public Button nextLevelButton;
    public Button levelSelectorButton;

    void Start()
    {
        Button next = nextLevelButton.GetComponent<Button>();
        Button select = levelSelectorButton.GetComponent<Button>();
        Button exit = exitButton.GetComponent<Button>();

        next.onClick.AddListener(LoadNextLevel);
        select.onClick.AddListener(LoadLevelSelector);
        exit.onClick.AddListener(ExitGame);
    }

    void LoadNextLevel()
    {
        SceneManager.LoadScene("Level3");
    }

    void LoadLevelSelector()
    {
        SceneManager.LoadScene("LevelSelector");
    }

    void ExitGame()
    {
        Application.Quit();
    }
}
