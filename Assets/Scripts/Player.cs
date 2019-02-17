using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{

    
    public float health  = 50;
    public float damage = 10;
    public float attackPower = 15;
    public Slider healthbar;
    public float jumpHeight  = 8;
    public float moveSpeed = 2;
    public Rigidbody2D rb;
    
    

    public int score = 0;

    
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpHeight);
        }

        if (Input.GetKey(KeyCode.A))
        {
            rb.velocity = new Vector2(-moveSpeed, rb.velocity.y);
        }
        if (Input.GetKey(KeyCode.D))
        {
            rb.velocity = new Vector2(moveSpeed, rb.velocity.y);
        }

   

        if (health <= 0) {
            Die();
            SceneManager.LoadScene("2d");
        }

    }


    //Calls for the player to take damage
    public void TakeDamage(float damage) {
        health -= damage;
        Debug.Log("You took Damage");
        healthbar.value = health;
    }

    public void Die() {
        Destroy(this);
    }
}
