using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    private Rigidbody2D rb;
    public GameManager gameManager;

    public void ResetBall()
    {
        transform.position = Vector2.zero;

        if(rb == null) rb = GetComponent<Rigidbody2D>();

        rb.velocity = gameManager.startingVelocity;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Wall"))
        {
            Vector2 newVelocity = rb.velocity;

            // Invertendo a direção
            newVelocity.y *= -1;

            rb.velocity = newVelocity;

        }

        if(collision.gameObject.CompareTag("Player") || collision.gameObject.CompareTag("Enemy"))
        {
            rb.velocity = new Vector2(-rb.velocity.x, rb.velocity.y);
            rb.velocity *= gameManager.ballDifficultMultiplier;

        }

        if(collision.gameObject.CompareTag("PlayerWall"))
        {
            gameManager.ScoreEnemy();
            ResetBall();
        }
        
        if(collision.gameObject.CompareTag("EnemyWall"))
        {
            gameManager.ScorePlayer();
            ResetBall();
        }
    }


}
