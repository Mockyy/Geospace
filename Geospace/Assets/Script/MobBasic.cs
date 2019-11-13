using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobBasic : MonoBehaviour
{
    private Rigidbody2D rb;

    private float speed;
    public float maxSpeed;
    public float moveTime;

    private Vector2 screenBounds;
    private float objectWidth;
    private float objectHeight;

    public GameObject bullet;
    private float shoot;
    public float firstShoot;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        shoot = firstShoot;

        speed = Random.Range(-maxSpeed, maxSpeed);

        screenBounds = Camera.main.ScreenToWorldPoint(
            new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        objectWidth = GetComponent<SpriteRenderer>().bounds.size.x / 2;
        objectHeight = GetComponent<SpriteRenderer>().bounds.size.y / 2;
    }

    // Update is called once per frame
    void Update()
    {

            shoot -= Time.deltaTime;

            if (shoot < 0)
            {
                Shoot();
                shoot = Random.Range(1f, 5f);
            }
    }

    private void FixedUpdate()
    {
        //Bouncing off screen
        if (((rb.position.x + objectWidth >= screenBounds.x) && (speed > 0)) || 
            ((rb.position.x - objectWidth <= -screenBounds.x) && (speed < 0)))
        {
            speed = -speed;
        }

        if(rb.position.y + GetComponent<SpriteRenderer>().bounds.size.y < -screenBounds.y)
        {
            Destroy(gameObject);
        }

        Vector2 position = rb.position;
        position.x = position.x + speed * Time.fixedDeltaTime;
        position.y = position.y - 1 * Time.fixedDeltaTime;

        rb.MovePosition(position);
    }

    private void Shoot()
    {
        GameObject b = Instantiate(bullet, transform.position, transform.rotation);
        b.GetComponent<Rigidbody2D>().velocity = Vector2.down * 3.0f;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Weapons")
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }
}
