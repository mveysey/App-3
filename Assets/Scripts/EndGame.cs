using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class EndGame : MonoBehaviour
{
    private bool complete = false;

    private void OnTriggerEnter(Collider other) {
        if (other.tag == "Player") {
            //other.SendMessage("Completed");
            complete = true;
        }
        Invoke("loadEnd", 0.5f);
    }

    public void loadEnd() {
        SceneManager.LoadScene(0);
    }

    public bool gameEnded() {
        return complete;
    }
}
