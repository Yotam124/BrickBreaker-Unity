using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    private Rigidbody2D rb;
    private bool inPlay = false;
    public Transform Player;
    public float speed;
    public Transform explosion;
    public GameManager gm;
    public Transform extraLife;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (gm.gameOver)
        {
            return;
        }
        if (inPlay == false)
        {
            transform.position = Player.position;
        }

        if (Input.GetButtonDown("Jump") && !inPlay)
        {
            inPlay = true;
            rb.AddForce(Vector2.up * speed);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        
        if (other.CompareTag("bottom"))
        {
            rb.velocity = Vector2.zero;
            inPlay = false;
            gm.UpdateLives(-1);

        }
    }

    public void newLevel()
    {
        rb.velocity = Vector2.zero;
        transform.position = Player.position;
        inPlay = false;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        Brick brickScript = other.gameObject.GetComponent<Brick>();
        if (other.transform.CompareTag("brick") || other.transform.CompareTag("last brick") && !brickScript.checkhits())
        {
            brickScript.BreakBrick();
        }
        else if (other.transform.CompareTag("last brick") && brickScript.checkhits())
        {
            int random = Random.Range(1, 101);
            if (random < 50)
            {
                Instantiate(extraLife, other.transform.position, other.transform.rotation);
            }

            Transform newExplosion = Instantiate(explosion, other.transform.position, other.transform.rotation);
            Destroy(newExplosion.gameObject, 2.5f);
            gm.UpdateScore(brickScript.points);
            gm.UpdateNumOfBricks();
            Destroy(other.gameObject);
        }
    }
}
