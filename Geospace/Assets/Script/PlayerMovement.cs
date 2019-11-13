using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //Movement attributes
    private Rigidbody2D rb;
    private Vector2 pointA;
    private Vector2 pointB;
    private bool touchStart = false;
    public float speed;
    private Vector2 direction;

    //Screen attributes
    private Vector2 screenBounds;
    private float objectHeight;
    private float objectWidth;

    //Health
    private PlayerHealth PlayerHealth;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        PlayerHealth = GetComponent<PlayerHealth>();

        //Calcul de la taille de la camera
        screenBounds = Camera.main.ScreenToWorldPoint(
            new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));

        //Calcul de la taille du sprite
        objectWidth = GetComponent<SpriteRenderer>().bounds.size.x;
        objectHeight = GetComponent<SpriteRenderer>().bounds.size.y;
    }

    // Update is called once per frame
    void Update()
    {
        //Get movement touchscreen
        if (Input.GetMouseButtonDown(0))
        {
            pointA = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y,
                Camera.main.transform.position.z));
        }
        if (Input.GetMouseButton(0))
        {
            touchStart = true;
            pointB = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y,
                Camera.main.transform.position.z));
        }
        else
        {
            touchStart = false;
        }
    }

    private void FixedUpdate()
    {
        //Move
        if (touchStart)
        {
            //Calculating direction
            Vector2 offset = pointB - pointA;

            //Clamping direction
            direction = Vector2.ClampMagnitude(offset, 1.0f);

            //Clamping player position
            Vector2 position = rb.position + direction * speed * Time.deltaTime;
            position.x = Mathf.Clamp(position.x, -screenBounds.x + objectWidth / 2, screenBounds.x - objectWidth / 2);
            position.y = Mathf.Clamp(position.y, -screenBounds.y + objectHeight / 2, screenBounds.y - objectHeight / 2);

            //Moving player
            rb.MovePosition(position);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Damage taken
        if (collision.gameObject.tag == "Enemies")
        {
            PlayerHealth.TakeDamage();
        }
    }
}
