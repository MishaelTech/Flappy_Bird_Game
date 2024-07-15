using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdScript : MonoBehaviour
{
    public Rigidbody2D myRigidbody;
    public float flapStrenght;
    public LogicScript logic;
    public bool birdIsAlive = true;
    public Health health;


    // Start is called before the first frame update
    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
        health = GameObject.FindGameObjectWithTag("Health").GetComponent<Health>();
        Time.timeScale = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && birdIsAlive || Input.touchCount > 0 && birdIsAlive)
        {
            myRigidbody.velocity = Vector2.up * flapStrenght;

            
        } 

        if (transform.position.y > 13)
        {
            health.health = 0;
            birdIsAlive = false;

            health.checkHealth();

            Debug.Log("Out of ward");

            transform.position=new Vector3(transform.position.x ,transform.position.y-2, transform.position.z);
        }

        if (transform.position.y < -13)
        {
            health.health = 0;
            birdIsAlive = false;

            health.checkHealth();

            Debug.Log("Out of ward");

            transform.position = new Vector3(transform.position.x, transform.position.y+2, transform.position.z);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        health.damage(1);
        if(health.health < 1)
        {
            logic.gameOver();
            birdIsAlive = false;
        }

        health.checkHealth();

    }
}
