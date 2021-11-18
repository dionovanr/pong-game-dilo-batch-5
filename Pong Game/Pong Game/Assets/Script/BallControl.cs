using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallControl : MonoBehaviour
{
    //rigidbody2d pada bola
    Rigidbody2D rigidBody2D;

    //gaya bola
    public float xInitialForce;
    public float yInitialForce;

    public float forceBall;

    //titik asal lintasan bola
    Vector2 trajectoryOrigin;

    public Vector2 TrajectoryOrigin
    {
        get
        {
            return trajectoryOrigin;
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        rigidBody2D = GetComponent<Rigidbody2D>();

        RestartGame();
        trajectoryOrigin = transform.position;
    }


    void ResetBall()
    {
        //reset posisi
        transform.position = Vector2.zero;

        //reset kecepatan
        rigidBody2D.velocity = Vector2.zero;
    }

    void PushBall()
    {
        float yRandomInitialForce = Random.Range(-yInitialForce, yInitialForce);
        float randomDirection = Random.Range(0, 2);

        if (randomDirection < 1.0f)
        {
            rigidBody2D.AddForce(new Vector2(-xInitialForce, yRandomInitialForce * forceBall));
        }
        else
        {
            rigidBody2D.AddForce(new Vector2(xInitialForce, yRandomInitialForce * forceBall));
        }
    }

    void RestartGame()
    {
        ResetBall();

        Invoke("PushBall", 2);
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        trajectoryOrigin = transform.position;
    }
}
