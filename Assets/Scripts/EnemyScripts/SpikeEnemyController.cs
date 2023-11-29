using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeEnemyController : MonoBehaviour
{
    Collider m_Collider;
    private static int lives = 1;
    public Animator m_animator = null;

    private void Awake()
    {
        if (!m_animator) { gameObject.GetComponent<Animator>(); }
        m_Collider = GetComponent<Collider>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Sword") && lives > 0)
        {
            m_animator.SetTrigger("hit");
            m_animator.SetTrigger("dizzy");

            lives -= 1;
        }
    }

    void Update()
    {
        if (lives == 0)
        {
            m_animator.SetBool("isDead", true);

            m_Collider.isTrigger = true;
        }
    }

    public static int GetLives()
    {
        return lives;
    }
}
