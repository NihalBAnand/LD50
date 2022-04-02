using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatchController : MonoBehaviour
{
    public Vector3 spawnPos;
    private bool dead;

    public GameObject patch;
    // Start is called before the first frame update
    void Start()
    {
        spawnPos = transform.position;
        dead = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDrag()
    {
        if (!dead)
        {
            Vector3 mousepos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            gameObject.transform.position = new Vector3(mousepos.x, mousepos.y, 0);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (!Input.GetMouseButton(0))
        {
            if (collision.tag == "Tear")
            {
                GameObject.Find("sail").GetComponent<SailController>().tears -= 1;
                Destroy(collision.gameObject);
                GameObject newPatch = Instantiate(patch);
                newPatch.transform.parent = gameObject.transform.parent;
                newPatch.transform.position = spawnPos;
                Destroy(GetComponent<Rigidbody2D>());
                Destroy(GetComponent<BoxCollider2D>());
                GetComponent<SpriteRenderer>().sortingOrder = -1;
                dead = true;
            }
        }
    }
}
