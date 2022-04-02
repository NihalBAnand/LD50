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
        //If the patch hasn't been used, drag the mouse to move it
        if (!dead)
        {
            Vector3 mousepos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            gameObject.transform.position = new Vector3(mousepos.x, mousepos.y, 0);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        //if the left mouse button isn't down, and the patch is touching a tear, use the patch and kill it
        if (!Input.GetMouseButton(0))
        {
            if (collision.tag == "Tear")
            {
                //reduce tear counter by 1
                GameObject.Find("sail").GetComponent<SailController>().tears -= 1;
                //destroy the tear
                Destroy(collision.gameObject);
                //create a new patch to use in the patch spot
                GameObject newPatch = Instantiate(patch);
                newPatch.transform.parent = gameObject.transform.parent;
                newPatch.transform.position = spawnPos;
                //kill this patch -- it's still there and can be seen, but does nothing. Tears can spawn on patches
                Destroy(GetComponent<Rigidbody2D>());
                Destroy(GetComponent<BoxCollider2D>());
                GetComponent<SpriteRenderer>().sortingOrder = -1;
                dead = true;
            }
        }
    }
}
