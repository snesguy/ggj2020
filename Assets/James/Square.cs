using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Square : MonoBehaviour
{
    int health;
    // Start is called before the first frame update
    void Start()
    {
        health = 10;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        Bullet bullet;
        if(null != (bullet = collision.gameObject.GetComponent<Bullet>()))
        {
            TakeDamage(bullet.damage);
        }
    }

    public void TakeDamage(int dmg)
    {
        health -= dmg;
        if(health == 0)
        {
            Destroy(gameObject);
        }
    }
}
