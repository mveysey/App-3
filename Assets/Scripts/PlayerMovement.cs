using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 2f;
    public float turnSpeed = 5f;

    private Rigidbody m_Rigidbody;

    void Start()
    {
        m_Rigidbody = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 m_Movement = new Vector3(horizontal, 0f, vertical).normalized;

        if (m_Movement != Vector3.zero)
        {
            Quaternion m_Rotation = Quaternion.LookRotation(m_Movement);
            m_Rigidbody.MoveRotation(m_Rotation);

            Vector3 newPosition = transform.position + m_Movement * moveSpeed * Time.fixedDeltaTime;
            m_Rigidbody.MovePosition(newPosition);
        }
    }
}
