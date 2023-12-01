using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Level3Complete : MonoBehaviour
{
    public Button exitButton;
    public Button nextLevelButton;

    void Start()
    {
        Button next = nextLevelButton.GetComponent<Button>();
        Button exit = exitButton.GetComponent<Button>();

        next.onClick.AddListener(LoadNextLevel);
        exit.onClick.AddListener(ExitGame);
    }

    void LoadNextLevel()
    {
        SceneManager.LoadScene("EndGame");
    }

    void ExitGame()
    {
        Application.Quit();
    }
}
