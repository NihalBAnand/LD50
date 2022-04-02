using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardController : MonoBehaviour
{
    public Vector3 spawnPos;
    private bool dead;

    public GameObject board;
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
        //If the board hasn't been used, drag the mouse to move it
        if (!dead)
        {
            Vector3 mousepos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            gameObject.transform.position = new Vector3(mousepos.x, mousepos.y, 0);
        }
    }

    private void OnMouseDown()
    {
        transform.eulerAngles = new Vector3(0, 0, Random.Range(-180, 180));
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        //if the left mouse button isn't down, and the board is touching a tear, use the board and kill it
        if (!Input.GetMouseButton(0))
        {
            if (collision.tag == "Tear")
            {
                //reduce tear counter by 1
                GameObject.Find("hull").GetComponent<HullController>().holes -= 1;
                //destroy the tear
                Destroy(collision.gameObject);
                //create a new board to use in the board spot
                GameObject newBoard = Instantiate(board);
                newBoard.transform.parent = gameObject.transform.parent;
                newBoard.transform.position = spawnPos;
                //kill this board -- it's still there and can be seen, but does nothing. Tears can spawn on boardes
                Destroy(GetComponent<Rigidbody2D>());
                Destroy(GetComponent<BoxCollider2D>());
                GetComponent<SpriteRenderer>().sortingOrder = -1;
                dead = true;
            }
        }
    }
}
