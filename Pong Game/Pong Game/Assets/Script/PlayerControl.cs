using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    //input
    public KeyCode upButton = KeyCode.W;
    public KeyCode downButton = KeyCode.S;

    //kecepatan
    public float speed = 10f;

    //batas game scene
    public float yBoundary = 9.0f;

    //Rigidbody 2D
    Rigidbody2D rigidBody2D;

    //skor
    int score;

    //titik tumbukan bola
    ContactPoint2D lastContactPoint;

    public ContactPoint2D LastContactPoint
    {
        get
        {
            return lastContactPoint;
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        rigidBody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 velocity = rigidBody2D.velocity;
        Vector3 position = transform.position;

        if (Input.GetKey(upButton))
        {
            velocity.y = speed;
        }  
        else if (Input.GetKey(downButton))
        {
            velocity.y = -speed;
        }
        else
        {
            velocity.y = 0f;
        }
        rigidBody2D.velocity = velocity;

        if (position.y > yBoundary)
        {
            position.y = yBoundary;
        }
        else if (position.y < -yBoundary)
        {
            position.y = -yBoundary;
        }
        transform.position = position;

    }

    public void IncrementScore()
    {
        score++;
    }

    public void ResetScore()
    {
        score = 0;
    }

    public int Score
    {
        get
        {
            return score;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name.Equals("Ball"))
        {
            lastContactPoint = collision.GetContact(0);
        }
    }
}
