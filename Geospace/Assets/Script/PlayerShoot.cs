using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    //Shoot attributes
    public GameObject bullet;
    public float bulletspeed;
    public float cooldown;
    private float shoot;
 

    void Update()
    {
        shoot -= Time.deltaTime;

        if (shoot < 0)
        {
            //Shoot();
            shoot = cooldown;
        }
    }

    private void Shoot()
    {
        GameObject b = Instantiate(bullet, transform.position, transform.rotation);
        b.GetComponent<Rigidbody2D>().velocity = Vector2.up * bulletspeed;
    }
}
