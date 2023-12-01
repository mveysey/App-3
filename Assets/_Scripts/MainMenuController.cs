using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{

    public void StartOnClick()
    {
        SceneManager.LoadScene("Tutorial");
    }

    public void ExitOnClick()
    {
        Application.Quit();
    }

    public void LevelsOnClick()
    {
        SceneManager.LoadScene("LevelSelector");
    }
}
