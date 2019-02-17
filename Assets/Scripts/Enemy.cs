using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//These are automatically added to the inspector
[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(BoxCollider2D))]
[RequireComponent(typeof(SpriteRenderer))]


public class Enemy : MonoBehaviour
{

    public Player player;
    public Transform target;
    public GameObject playerGameObject;
    public GameObject enemyGameObject;
    public float health = 100;
    public float attackDamage = 25;
    public float moveSpeed;
    public int points;
    public Slider healthBar;
    public Canvas canvas;

    private float range;

    Rigidbody2D rb;
    SpriteRenderer sr;
    BoxCollider2D bc;
    // Start is called before the first frame update

    private void Awake()
    {
        enemyGameObject = GameObject.FindGameObjectWithTag("Enemy");
        playerGameObject = GameObject.FindGameObjectWithTag("Player");
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        bc = GetComponent<BoxCollider2D>();
        sr.flipX = true;
        bc.isTrigger = false;
        sr.sortingOrder = 5;
        healthBar.value = health;
        canvas.enabled = false;
    }
    

    // Update is called once per frame
    void Update()
    {

        range = Vector2.Distance(enemyGameObject.transform.position, playerGameObject.transform.position);

        if(range <= 5f)
        {
            Vector2 velocity = new Vector2((transform.position.x - playerGameObject.transform.position.x) * moveSpeed, 0 );
            GetComponent<Rigidbody2D>().velocity = -velocity;
           
           healthBar.value = health;
        }

    }

    public void Attack() {

    }



    public void Die() {
        Destroy(gameObject);
    }

    public void TakeDamage(float playerDamage) {
        health -= playerDamage;

        if(health <= 0)
        {

            Die();

        }

    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.name == "Player") {
            player.TakeDamage(attackDamage);
            Debug.Log("Player Collided");
        }

    }



}
