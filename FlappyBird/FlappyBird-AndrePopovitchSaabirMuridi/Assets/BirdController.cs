using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdController : MonoBehaviour {
    public float jumpHeight = 8;
    public float rotationMult = 2;
    public List<Sprite> birds;
    GameController gcont;


    // Use this for initialization
    void Start ()
    {
        gcont = Camera.main.GetComponent<GameController>();
        GetComponent<SpriteRenderer>().sprite = birds[Random.Range(0, birds.Count)];
    }
	
	// Update is called once per frame
	void Update ()
    {
        var rb = GetComponent<Rigidbody2D>();
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            rb.velocity = new Vector3(0, jumpHeight, 0);
        }
        transform.eulerAngles = new Vector3(0, 0, rb.velocity.y * rotationMult);


    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "KillsPlayer")
        {
            Destroy(gameObject);
            gcont.GameOver();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "GivesPoints")
        {
            gcont.points += 1;
        }
    }

}
