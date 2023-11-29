using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TutorialController : MonoBehaviour
{
    public Button continueButton;

    void Start()
    {
        Button continueBtn = continueButton.GetComponent<Button>();

        continueBtn.onClick.AddListener(ContinueOnClick);
    }

    void ContinueOnClick()
    {
        SceneManager.LoadScene("Level1");
    }
}
