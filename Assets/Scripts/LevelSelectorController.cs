using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelectorController : MonoBehaviour
{
    public Button level1Button;
    public Button level2Button;
    public Button level3Button;
    public Button tutorialButton;

    void Start()
    {
        Button level1 = level1Button.GetComponent<Button>();
        Button level2 = level2Button.GetComponent<Button>();
        Button level3 = level3Button.GetComponent<Button>();
        Button tutorial = tutorialButton.GetComponent<Button>();

        level1.onClick.AddListener(Level1OnClick);
        level2.onClick.AddListener(Level2OnClick);
        level3.onClick.AddListener(Level3OnClick);
        tutorial.onClick.AddListener(TutorialOnClick);
    }

    void Level1OnClick()
    {
        SceneManager.LoadScene("Level1");
    }

    void Level2OnClick()
    {
        SceneManager.LoadScene("Level2");
    }

    void Level3OnClick()
    {
        SceneManager.LoadScene("Level3");
    }

    void TutorialOnClick()
    {
        SceneManager.LoadScene("Tutorial");
    }
}
