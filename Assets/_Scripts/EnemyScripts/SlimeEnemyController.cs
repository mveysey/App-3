using System.Collections;
using UnityEngine;

public class SlimeEnemyController : MonoBehaviour
{
    Collider m_Collider;
    private int lives = 3;
    public Animator m_animator = null;

    private void Awake()
    {
        if (!m_animator) { gameObject.GetComponent<Animator>(); }
        m_Collider = GetComponent<Collider>();
    }

    //private IEnumerator OnCollisionEnter(Collision collision)
    //{
    //    if (collision.gameObject.CompareTag("Sword") && lives > 0)
    //    {
    //        m_Collider.enabled = !m_Collider.enabled;

    //        m_animator.SetTrigger("hit");
    //        m_animator.SetTrigger("dizzy");

    //        lives -= 1;

    //        yield return StartCoroutine(Timeout());
    //    }
    //}

    private IEnumerator OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Sword") && lives > 0)
        {
            m_Collider.enabled = !m_Collider.enabled;

            m_animator.SetTrigger("hit");
            m_animator.SetTrigger("dizzy");

            lives -= 1;

            yield return StartCoroutine(Timeout());
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

    IEnumerator Timeout()
    {
        yield return new WaitForSeconds(2);
        m_Collider.enabled = !m_Collider.enabled;
    }
}
