﻿﻿using System.Collections.Generic;
using UnityEngine;

public class PlayerController: MonoBehaviour
{
    [SerializeField] private float m_moveSpeed = 2;
    [SerializeField] private float m_jumpForce = 4;

    [SerializeField] private Animator m_animator = null;
    [SerializeField] private Rigidbody m_rigidBody = null;

    private float m_currentV = 0;
    private float m_currentH = 0;

    private readonly float m_interpolation = 10;
    private readonly float m_walkScale = 0.33f;


    private bool m_wasGrounded;
    public static bool isAttacking;
    private Vector3 m_currentDirection = Vector3.zero;

    private float m_jumpTimeStamp = 0;
    private float m_minJumpInterval = 0.5f;
    private bool m_jumpInput = false;

    private bool m_isGrounded;

    private List<Collider> m_collisions = new List<Collider>();

    public AudioSource SFXAudioSource;
    public AudioClip attack;
    public AudioClip jump;

    //AudioManager audioManager;
    //AudioSource m_AudioSource;

    private void Awake()
    {
        if (!m_animator) { gameObject.GetComponent<Animator>(); }
        if (!m_rigidBody) { gameObject.GetComponent<Animator>(); }
        //audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
        //m_AudioSource = GetComponent<AudioSource> ();
    }

    private void OnCollisionEnter(Collision collision)
    {
        ContactPoint[] contactPoints = collision.contacts;
        for (int i = 0; i < contactPoints.Length; i++)
        {
            if (Vector3.Dot(contactPoints[i].normal, Vector3.up) > 0.5f)
            {
                if (!m_collisions.Contains(collision.collider))
                {
                    m_collisions.Add(collision.collider);
                }
                m_isGrounded = true;
            }
        }

        // touch slime enemy loose 1 life
        if (collision.gameObject.CompareTag("SlimeEnemy"))
        {
            
            LivesManager livesManager = FindObjectOfType<LivesManager>();
            if (livesManager != null)
            {
                livesManager.LoseLife();
            }
        }

        // touch spike enemy looke 2 lives 
        if (collision.gameObject.CompareTag("SpikeEnemy"))
        {
           
            LivesManager livesManager = FindObjectOfType<LivesManager>();
            if (livesManager != null)
            {
                livesManager.LoseTwoLives();
            }
        }
        if (collision.gameObject.CompareTag("GroundSpike"))
        {
            LivesManager livesManager = FindObjectOfType<LivesManager>();
            if (livesManager != null)
            {
                livesManager.LoseLife();
            }
        }

        if (collision.gameObject.CompareTag("SpikeTrap"))
        {
            LivesManager livesManager = FindObjectOfType<LivesManager>();
            if (livesManager != null)
            {
                livesManager.LoseLife();
            }
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        ContactPoint[] contactPoints = collision.contacts;
        bool validSurfaceNormal = false;
        for (int i = 0; i < contactPoints.Length; i++)
        {
            if (Vector3.Dot(contactPoints[i].normal, Vector3.up) > 0.5f)
            {
                validSurfaceNormal = true; break;
            }
        }

        if (validSurfaceNormal)
        {
            m_isGrounded = true;
            if (!m_collisions.Contains(collision.collider))
            {
                m_collisions.Add(collision.collider);
            }
        }
        else
        {
            if (m_collisions.Contains(collision.collider))
            {
                m_collisions.Remove(collision.collider);
            }
            if (m_collisions.Count == 0) { m_isGrounded = false; }
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (m_collisions.Contains(collision.collider))
        {
            m_collisions.Remove(collision.collider);
        }
        if (m_collisions.Count == 0) { m_isGrounded = false; }
    }

    private void Update()
    {
        if (!m_jumpInput && Input.GetKey(KeyCode.Space))
        {
            m_jumpInput = true;
        }

        if (Input.GetMouseButtonDown(0))
        {
            SFXAudioSource.PlayOneShot(attack);
            isAttacking = true;
        }
        else
        {
            isAttacking = false;
        }
        m_animator.SetBool("isAttacking", isAttacking);
    }

    private void FixedUpdate()
    {
        DirectUpdate();
        m_wasGrounded = m_isGrounded;
        m_jumpInput = false;
    }

    private void DirectUpdate()
    {
        float v = Input.GetAxis("Vertical");
        float h = Input.GetAxis("Horizontal");

        Transform camera = Camera.main.transform;

        if (Input.GetKey(KeyCode.LeftShift))
        {
            v *= m_walkScale;
            h *= m_walkScale;
        }

        bool hasHorizontalInput = !Mathf.Approximately(h, 0f);
        bool hasVerticalInput = !Mathf.Approximately(v, 0f);
        bool isWalking = (hasHorizontalInput || hasVerticalInput) && !m_jumpInput;
        m_animator.SetBool("isWalking", isWalking);

        m_currentV = Mathf.Lerp(m_currentV, v, Time.deltaTime * m_interpolation);
        m_currentH = Mathf.Lerp(m_currentH, h, Time.deltaTime * m_interpolation);

        Vector3 direction = camera.forward * m_currentV + camera.right * m_currentH;

        float directionLength = direction.magnitude;
        direction.y = 0;
        direction = direction.normalized * directionLength;

        if (direction != Vector3.zero)
        {
            m_currentDirection = Vector3.Slerp(m_currentDirection, direction, Time.deltaTime * m_interpolation);

            transform.rotation = Quaternion.LookRotation(m_currentDirection);
            transform.position += m_currentDirection * m_moveSpeed * Time.deltaTime;
        }

        JumpingAndLanding();
    }

    private void JumpingAndLanding()
    {
        bool jumpCooldownOver = (Time.time - m_jumpTimeStamp) >= m_minJumpInterval;

        if (jumpCooldownOver && m_isGrounded && m_jumpInput)
        {
            SFXAudioSource.PlayOneShot(jump);
            m_jumpTimeStamp = Time.time;
            m_rigidBody.AddForce(Vector3.up * m_jumpForce, ForceMode.Impulse);
        }
    }
}
