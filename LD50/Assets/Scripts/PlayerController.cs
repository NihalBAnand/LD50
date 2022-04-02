using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb;
    public float speed;

    public GameObject spacebarIndicator;
    private bool canInteract;
    public GameObject interactor;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spacebarIndicator = GameObject.Find("SpacebarIndicator");
        spacebarIndicator.SetActive(false);
        canInteract = false;
    }

    // Update is called once per frame
    void Update()
    {
        rb.MovePosition(new Vector2(transform.position.x + Input.GetAxisRaw("Horizontal") * speed, transform.position.y + Input.GetAxisRaw("Vertical") * speed));

        if (canInteract)
        {
            if (Input.GetKeyDown("space"))
            {
                interactor.GetComponent<InteractableGeneric>().Interaction(gameObject);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.parent.gameObject.tag == "Interactable")
        {
            spacebarIndicator.SetActive(true);
            canInteract = true;
            interactor = collision.transform.parent.gameObject;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.transform.parent.gameObject.tag == "Interactable")
        {
            spacebarIndicator.SetActive(false);
            canInteract = false;
        }
    }
}
