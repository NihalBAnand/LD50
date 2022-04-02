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
        //Basic movement -- this works, pls no touch
        rb.MovePosition(new Vector2(transform.position.x + Input.GetAxisRaw("Horizontal") * speed, transform.position.y + Input.GetAxisRaw("Vertical") * speed));

        //Interact with something if possible
        if (canInteract)
        {
            if (Input.GetKeyDown("space"))
            {
                //Using this script call means that it works for all interactable objects (tagged with 'Interactable' and inherit InteractableGeneric class) -- no need to create an if for every single one
                interactor.GetComponent<InteractableGeneric>().Interaction(gameObject);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Determine if it's possible to interact
        if (collision.transform.parent.gameObject.tag == "Interactable")
        {
            spacebarIndicator.SetActive(true);
            canInteract = true;
            //game object that can be interacted with
            interactor = collision.transform.parent.gameObject;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        //Cancel ability to interact if player is too far away
        if (collision.transform.parent.gameObject.tag == "Interactable")
        {
            spacebarIndicator.SetActive(false);
            canInteract = false;
        }
    }
}
