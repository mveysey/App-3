using UnityEngine;
using UnityEngine.UI;

public class FirstEnemyTutorialController : MonoBehaviour
{
    public GameObject firstEnemyCanvas;

    public Button continueButton;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            PauseGame();
        }
    }

    void PauseGame()
    {
        firstEnemyCanvas.SetActive(true);
        Time.timeScale = 0;

        Button continueBtn = continueButton.GetComponent<Button>();

        continueBtn.onClick.AddListener(ContinueGame);
    }

    void ContinueGame()
    {
        firstEnemyCanvas.SetActive(false);
        Time.timeScale = 1;
    }
}
