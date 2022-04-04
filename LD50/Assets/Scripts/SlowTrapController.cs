using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowTrapController : MonoBehaviour
{
    public int usesRemaining;
    // Start is called before the first frame update
    void Start()
    {
        usesRemaining = 5;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Debug.Log("Slow player");
            collision.GetComponent<PlayerController>().speed /= 2;
        }
        else if (collision.tag == "Monster")
        {
            collision.GetComponent<EnemyController>().speed /= 2;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            collision.GetComponent<PlayerController>().speed *= 2;
            usesRemaining -= 1;
        }
        else if (collision.tag == "Monster")
        {
            collision.GetComponent<EnemyController>().speed *= 2;
        }
        
        if (usesRemaining <= 0)
        {
            Destroy(gameObject);
        }
    }
}
