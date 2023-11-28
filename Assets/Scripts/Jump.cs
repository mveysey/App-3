using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour
{
    public GameObject jump;
    // Start is called before the first frame update
    void Start()
    {
        jump.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.Space))
        {
            jumps();
        }
        else
        {
            stopJump();
        }
    }
    void jumps()
    {
        jump.SetActive(true);
    }

    void stopJump()
    {
        jump.SetActive(false);
    }
}
