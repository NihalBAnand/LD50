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
    public bool interacting;

    public GameObject stepAudio;
    public AudioClip step1;
    public AudioClip step2;
    public AudioClip step3;
    private AudioClip[] steps = new AudioClip[3];

    public AudioSource swordAudio;

    public bool vulnerable;
    public int health;

    private Text coreCount;
    public int cores;
    private Text tarCount;
    public int tars;
    private Text teethCount;
    public int teeth;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        spacebarIndicator = GameObject.Find("SpacebarIndicator");
        spacebarIndicator.SetActive(false);
        canInteract = false;
        interacting = false;

        stepAudio = GameObject.Find("PlayerAudioSteps");
        steps[0] = step1;
        steps[1] = step2;
        steps[2] = step3;

        swordAudio = GameObject.Find("PlayerAudioSword").GetComponent<AudioSource>();

        vulnerable = true;
        health = 100;

        coreCount = GameObject.Find("CoreCounter").GetComponentInChildren<Text>();
        cores = 0;
        tarCount = GameObject.Find("TarCounter").GetComponentInChildren<Text>();
        tars = 0;
        teethCount = GameObject.Find("TeethCounter").GetComponentInChildren<Text>();
        teeth = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0)
        {
            Camera.main.transform.parent = GameObject.Find("Center").transform;
            Destroy(gameObject);
        }

        if (!interacting) 
        {
            //Basic movement -- this works, pls no touch
            rb.MovePosition(new Vector2(transform.position.x + Input.GetAxisRaw("Horizontal") * speed, transform.position.y + Input.GetAxisRaw("Vertical") * speed));

            if ((Input.GetAxisRaw("Horizontal") != 0 || Input.GetAxisRaw("Vertical") != 0) && !stepAudio.GetComponent<AudioSource>().isPlaying)
            {
                stepAudio.GetComponent<AudioSource>().clip = steps[1];
                stepAudio.GetComponent<AudioSource>().Play();
            }
            else if (Input.GetAxisRaw("Horizontal") == 0 && Input.GetAxisRaw("Vertical") == 0)
            {
                stepAudio.GetComponent<AudioSource>().Stop();
            }



            if (Input.GetMouseButtonDown(0) && !swordAudio.isPlaying)
            {
                swordAudio.Play();
            }
        }

        //Interact with something if possible
        if (canInteract)
        {
            if (Input.GetKeyDown("space"))
            {
                //Using this script call means that it works for all interactable objects (tagged with 'Interactable' and inherit InteractableGeneric class) -- no need to create an if for every single one
                interactor.GetComponent<InteractableGeneric>().Interaction(gameObject);
                interacting = true;
            }
        }
        if (Camera.main.transform.parent == gameObject.transform)
        {
            interacting = false;
        }

        coreCount.text = cores.ToString();
        tarCount.text = tars.ToString();
        teethCount.text = teeth.ToString();
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

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Monster" && vulnerable)
        {
            rb.AddForce((transform.position - collision.collider.transform.position) * 2500);
            health -= collision.collider.GetComponent<EnemyController>().damage;
            Debug.Log(health);
            StartCoroutine(iFrames());
        }
    }

    private IEnumerator iFrames()
    {
        vulnerable = false;
        GetComponent<SpriteRenderer>().color = new Color(166, 166, 166, .7f);
        yield return new WaitForSeconds(1.7f);
        vulnerable = true;
        GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 1f);
    }
}
