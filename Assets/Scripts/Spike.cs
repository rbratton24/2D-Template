using System.Collections;
using System.Collections.Generic;
using UnityEngine;




[RequireComponent(typeof(BoxCollider2D))]

public class Spike : MonoBehaviour
{

    public float damage = 10;
    public GameObject player;

    // Start is called before the first frame update
    

    // Update is called once per frame
    void Update()
    {
        
    }

    

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log(collision.collider.name);
        collision.collider.GetComponent<Player>().TakeDamage(damage);
    }
}
