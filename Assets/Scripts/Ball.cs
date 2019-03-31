using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public float speed = 1f;
    private Rigidbody2D ballRigidbody;

    // Start is called before the first frame update
    void Start()
    {
        ballRigidbody = GetComponent<Rigidbody2D>();
        ballRigidbody.velocity = new Vector2(
            -0.5f,
            speed
        );
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag == "Bound")
        {
            // Collided with top bound
            if (collider.transform.position.y > this.transform.position.y && ballRigidbody.velocity.y > 0)
            {
                ballRigidbody.velocity = new Vector2(
                    ballRigidbody.velocity.x,
                    -ballRigidbody.velocity.y
                );
            } 

            // Collided with bottom bound
            if (collider.transform.position.y < this.transform.position.y && ballRigidbody.velocity.y < 0)
            {
                ballRigidbody.velocity = new Vector2(
                    ballRigidbody.velocity.x,
                    -ballRigidbody.velocity.y
                );
            }
        }
        else if (collider.tag == "Paddle")
        {
            // Collided with left paddle
            if (collider.transform.position.x < this.transform.position.x && ballRigidbody.velocity.x < 0)
            {
                ballRigidbody.velocity = new Vector2(
                    -ballRigidbody.velocity.x,
                    ballRigidbody.velocity.y
                );
            }

            // Collided with right paddle
            if (collider.transform.position.x > this.transform.position.x && ballRigidbody.velocity.x > 0)
            {
                ballRigidbody.velocity = new Vector2(
                    -ballRigidbody.velocity.x,
                    ballRigidbody.velocity.y
                );
            }
        }
    }
}
