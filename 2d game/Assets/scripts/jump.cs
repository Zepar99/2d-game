using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jump : MonoBehaviour
{
     public Animator animator;
[Range(1,10)]
public float jumpVelocity;
bool jumprequest;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Jump"))
        {
            jumprequest = true;
        }
    }

    void FixedUpdate()
    {
        if(jumprequest)
        {
            GetComponent<Rigidbody2D>().AddForce(Vector2.up*jumpVelocity,ForceMode2D.Impulse);
            jumprequest = false;
        }
        if(jumprequest)
        {
        animator.SetBool("Jump",true);
        }
        else
        {
          animator.SetBool("Jump",false);
        }
    }
}
