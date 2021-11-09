using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float playerspeed;
    public float jump;
    public float jumpForce;
    private Rigidbody2D rd;
    public Animator animator;
    bool Grounded;
    private void Awake()
    {
      Debug.Log("Player controller awake");
      rd = gameObject.GetComponent<Rigidbody2D>();
      SpriteRenderer sprite = gameObject.GetComponent<SpriteRenderer>();
    }
//    private void OnCollisionEnter2D(Collision2D collision)
//    {
//        Debug.Log("collision: " + collision.gameObject.name);
//    }
    private void Update()
    {
        float speed = Input.GetAxisRaw("Horizontal");
        float speedv = Input.GetAxisRaw("Jump");
        
        MoveCharater(speed,speedv);
        PlayerMovement(speed,speedv);
    }
      private void MoveCharater(float speed,float speedv)
      {
          Vector3 position = transform.position;
          position.x += speed  * playerspeed * Time.deltaTime;
          transform.position = position;

          if(speedv>0)
          {
              rd.AddForce(new Vector2(0f,jump),ForceMode2D.Force);
          }
      }
        private void PlayerMovement(float speed,float speedv)
    {
         animator.SetFloat("speed",Mathf.Abs(speed));

        Vector3 scale =  transform.localScale;
        if(speed<0)
        {
          scale.x = -1f * Mathf.Abs(scale.x);
        }
        else if(speed>0){
           scale.x =Mathf.Abs(scale.x);

        }

        transform.localScale = scale;
        if(speedv>0)
        {
        animator.SetBool("Jump",true);
        }
        else
        {
          animator.SetBool("Jump",false);
        }
    
    }
}
