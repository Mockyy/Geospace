using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatingBackground : MonoBehaviour
{
    private Rigidbody2D rb;
    private BoxCollider2D backCollider;
    private float backHeight;

    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(0, -speed);
        backCollider = GetComponent<BoxCollider2D>();
        backHeight = backCollider.size.y;
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.y < -backHeight)
        {
            RepositionBackground();
        }
    }

    private void RepositionBackground()
    {
        Vector3 backOffset = new Vector3(0, backHeight * 2f, 0);
        transform.position = transform.position + backOffset;
    }

}
