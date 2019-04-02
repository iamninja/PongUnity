using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public float difficultyMultiplier = 1.3f;
    public float minXspeed = 0.8f;
    public float maxXspeed = 1.2f;
    public float minYspeed = 0.8f;
    public float maxYspeed = 1.2f;


    private Rigidbody2D ballRigidbody;

    // Start is called before the first frame update
    void Start()
    {
        ballRigidbody = GetComponent<Rigidbody2D>();
        ballRigidbody.velocity = new Vector2(
            Random.Range(minXspeed, maxXspeed) * (Random.value > 0.5f ? -1 : 1),
            Random.Range(minYspeed, maxYspeed) * (Random.value > 0.5f ? -1 : 1)
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
                    -ballRigidbody.velocity.x * difficultyMultiplier,
                    ballRigidbody.velocity.y * difficultyMultiplier
                );
            }

            // Collided with right paddle
            if (collider.transform.position.x > this.transform.position.x && ballRigidbody.velocity.x > 0)
            {
                ballRigidbody.velocity = new Vector2(
                    -ballRigidbody.velocity.x * difficultyMultiplier,
                    ballRigidbody.velocity.y * difficultyMultiplier
                );
            }
        }
    }
}
