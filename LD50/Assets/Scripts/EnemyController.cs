using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public GameObject player;

    private Rigidbody2D rb;

    public float speed;
    public int damage;

    public string type;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.MovePosition(Vector2.MoveTowards(transform.position, player.transform.position, speed));
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Player")
        {
            
        }
    }

    private void OnMouseOver()
    {
        if (Input.GetMouseButton(1))
        {
            switch (type)
            {
                case "w":
                    player.GetComponent<PlayerController>().cores += 1;
                    break;
                case "t":
                    player.GetComponent<PlayerController>().teeth += 1;
                    break;
                case "s":
                    player.GetComponent<PlayerController>().tars += 1;
                    break;
            }
            player.GetComponent<PlayerController>().exp += 5;
            Destroy(gameObject);
        }
    }
}
