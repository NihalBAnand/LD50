using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public GameObject player;

    private Rigidbody2D rb;

    public float speed;
    public int damage;
    public int health;

    public string type;

    public GameObject logText;

    private float lastHit;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        rb = GetComponent<Rigidbody2D>();
        logText = GameObject.Find("LogText");
        lastHit = 0;
    }

    // Update is called once per frame
    void Update()
    {
        rb.MovePosition(Vector2.MoveTowards(transform.position, player.transform.position, speed));

        if (health <= 0)
        {
            switch (type)
            {
                case "w":
                    player.GetComponent<PlayerController>().cores += 1;
                    player.GetComponent<PlayerController>().teeth += 1;
                    if (!logText.GetComponent<EntryController>().firstCore) logText.GetComponent<EntryController>().firstCore = true;
                    break;
                case "t":
                    player.GetComponent<PlayerController>().teeth += 1;
                    break;
                case "s":
                    player.GetComponent<PlayerController>().tars += 1;
                    break;
            }
            player.GetComponent<PlayerController>().exp += 5;
            if (!logText.GetComponent<EntryController>().firstMonster) logText.GetComponent<EntryController>().firstMonster = true;
            Destroy(gameObject);
            
        }

        if (transform.position.x > player.transform.position.x)
        {
            if (GetComponent<SpriteRenderer>() != null)
                GetComponent<SpriteRenderer>().flipX = true;
        }
        else
        {
            if (GetComponent<SpriteRenderer>() != null)
                GetComponent<SpriteRenderer>().flipX = false;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.transform.parent.tag == "Player")
        {
            if (collision.name.Contains(player.GetComponent<PlayerController>().direction) && player.GetComponent<PlayerController>().swordAudio.isPlaying && Time.fixedUnscaledTime - lastHit > 0.8f)
            {
                rb.AddForce((transform.position - collision.transform.position) * 2500);
                health -= player.GetComponent<PlayerController>().damage;
                lastHit = Time.fixedUnscaledTime;
                StartCoroutine(colorChange());
            }
        }
    }

    IEnumerator colorChange()
    {
        if (GetComponent<SpriteRenderer>() != null)
        {
            GetComponent<SpriteRenderer>().color = new Color(255, 0, 0, .75f);
            yield return new WaitForSeconds(.3f);
            GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 1);
        }
        else
        {
            transform.Find("Top").gameObject.GetComponent<SpriteRenderer>().color = new Color(255, 0, 0, .75f);
            transform.Find("Bottom").gameObject.GetComponent<SpriteRenderer>().color = new Color(255, 0, 0, .75f);
            yield return new WaitForSeconds(.3f);
            transform.Find("Top").gameObject.GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 1f);
            transform.Find("Bottom").gameObject.GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 1f);
        }
    }
}
