using System;
using UnityEngine;

public class Frog : MonoBehaviour
{
    public float speed = 0.1f;
    Vector2 jump = Vector2.zero;
    public bool isAlive = true;

    public bool isJumping()
    {
        return jump != Vector2.zero;
    }

    void FixedUpdate()
    {
        if(isJumping())
        {
            Vector2 pos = transform.position;
            transform.position = Vector2.MoveTowards(pos, pos + jump, speed);
            jump -= (Vector2)transform.position - pos;
        }

        else
        {
            if(isAlive == true)
            {
                if(Input.GetKey(KeyCode.UpArrow))
                {
                    jump = Vector2.up;
                }
                else if(Input.GetKey(KeyCode.RightArrow))
                {
                    jump = Vector2.right;
                }
                else if(Input.GetKey(KeyCode.DownArrow))
                {
                    jump = Vector2.down;
                }
                else if(Input.GetKey(KeyCode.LeftArrow))
                {
                    jump = Vector2.left;
                }
            }
        }

        GetComponent<Animator>().SetFloat("X", jump.x);
        GetComponent<Animator>().SetFloat("Y", jump.y);
        GetComponent<Animator>().speed = Convert.ToSingle(isJumping());
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        GameOver.Collision();
    }
}
