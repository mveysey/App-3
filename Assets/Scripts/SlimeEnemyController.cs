using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeEnemyController : MonoBehaviour
{
    // Check if slime has been hit
    // trigger hit animation
    // if 3 hits, trigger die animation

    private int lives = 3;
    private bool isHit = false;

    public Animator m_animator = null;

    private void Awake()
    {
        if (!m_animator) { gameObject.GetComponent<Animator>(); }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Sword") && PlayerController.isAttacking == true)
        {
            Debug.Log("hi");
            isHit = true;
            m_animator.SetBool("isHit", isHit);
            lives -= 1;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        isHit = false;
        m_animator.SetBool("isHit", isHit);
    }

    void Update()
    {
        if(lives <= 0)
        {
            m_animator.SetBool("isDead", true);
            Debug.Log("oh my god mrs keisha is dead");
        }

        
    }
}
