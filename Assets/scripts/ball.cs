using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ball : MonoBehaviour
{
    public float speed = 5.0f;
    GameManager gamemanager;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Rigidbody2D>().velocity = Vector2.down * speed;
        gamemanager = FindObjectOfType<GameManager>();
        gamemanager.gameover = false;
    }

    float hitFactor(Vector2 ballPos, Vector2 racketPos, float racketWidth)
    {
        // ascii art:
        //  -1  -0.5  0  0.5  1
        //  ===================
        //
        return (ballPos.x - racketPos.x) / racketWidth;
    }

    GameObject racket;

    void OnCollisionEnter2D(Collision2D col)
    {
        // Hit the Racket?
        if (col.gameObject.name == "racket")
        {
            // Calculate hit Factor
            float x = hitFactor(transform.position, col.transform.position, col.collider.bounds.size.x);

            // Calculate direction, make length=1 via .normalized
            Vector2 dir = new Vector2(x, 1).normalized;

            // Set Velocity with dir * speed
            GetComponent<Rigidbody2D>().velocity = dir * speed;

            racket = col.gameObject;
        }
        if (col.gameObject.name == "bottom")
        {
            gamemanager.gameover = true;
            racket.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePositionX;
            Destroy(gameObject);
        }

    }
    void Update()
    {
   
        //Debug.Log(GetComponent<Rigidbody2D>().velocity.magnitude);
    }
}
