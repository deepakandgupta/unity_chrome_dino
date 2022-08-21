using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGMovement : MonoBehaviour
{
    public float speed;
    public float start;
    public float end;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position = new Vector2(transform.position.x - speed * Time.deltaTime, transform.position.y);
        if (transform.position.x <= end) {
            if (gameObject.tag == "cloud") {
                transform.position = new Vector2(start, Random.Range(0.0F, 2.5F));
            }
            else if (gameObject.tag == "enemy") {
                Destroy(gameObject);
            }
            else {
                transform.position = new Vector2(start, transform.position.y);
            }
        }
    }
}
