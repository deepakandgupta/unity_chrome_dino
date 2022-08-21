using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCrouched : MonoBehaviour
{
    public GameObject stand;
    public GameObject crouch;

    public GameManager gameManager;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.timeScale > 0 && Input.GetKeyUp("down"))
        {
                crouch.SetActive(false);
                stand.SetActive(true);
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
