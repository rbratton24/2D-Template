using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{

    public GameManager gm;
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
         
        gm.currentState = GameManager.States.PLAYING;
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
        if (Input.GetKey(KeyCode.P)) {
            gm.currentState = GameManager.States.PAUSED;
            gm.GetState(gm.currentState);
        }


        if (health <= 0) {
            gm.currentState = GameManager.States.DEAD;
            gm.GetState(gm.currentState);
            
        }
        /*
        if (gm.currentState == GameManager.States.DEAD) {

            // SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            gm.currentState = GameManager.States.PLAYING;
            gm.GetState(gm.currentState);
        }
        */

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
