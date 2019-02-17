using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(BoxCollider2D))]

public class Bullet : MonoBehaviour
{ 
    public float speed = 20f;
    public float damage;
    public int bulletsInClip;
    public Enemy enemy;

    public Rigidbody2D rb;
   


    

    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = transform.right * speed;
    }

    // Update is called once per frame

    void OnTriggerEnter2D(Collider2D hitInfo){

        Debug.Log(hitInfo.name);
        hitInfo.GetComponent<Enemy>().TakeDamage(damage);
        Destroy(gameObject);
    }
    
}
