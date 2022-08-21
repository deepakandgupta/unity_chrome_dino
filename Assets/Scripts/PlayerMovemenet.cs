using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovemenet : MonoBehaviour
{
    
    public GameObject stand;
    public GameObject crouch;

    Rigidbody2D rb;
    bool inAir;

    public GameManager gameManager;

    public AudioSource jumpSound;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        inAir = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if ((Input.GetKey("space") || Input.GetKey("up") )&& inAir == false) {
            rb.velocity = new Vector3(0, 18, 0);
            inAir = true;
            jumpSound.Play();
        }

        if (Input.GetKey("down") )
        {
            if (inAir == false)
            {
                crouch.SetActive(true);
                stand.SetActive(false);
            }
            else {
                rb.velocity = new Vector3(0, -10, 0);
            }
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "ground") {
            inAir = false;
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "enemy")
        {
            gameManager.GameOver();
        }
    }
}
