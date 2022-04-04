using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb;
    public float speed;

    private SpriteRenderer sr;

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

    public int harmTraps;
    public int slowTraps;

    public GameObject harmTrap;
    public GameObject slowTrap;

    public int exp;
    public int level;
    public int damage;

    public string direction;
    private Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        sr = GetComponent<SpriteRenderer>();

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
        StartCoroutine(passiveHeal());

        coreCount = GameObject.Find("CoreCounter").GetComponentInChildren<Text>();
        cores = 0;
        tarCount = GameObject.Find("TarCounter").GetComponentInChildren<Text>();
        tars = 0;
        teethCount = GameObject.Find("TeethCounter").GetComponentInChildren<Text>();
        teeth = 0;

        harmTraps = 0;
        slowTraps = 0;

        exp = 0;
        level = 1;
        damage = 10 + (5 * level);

        anim = GetComponent<Animator>();
        direction = "Down";
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
            if (!swordAudio.isPlaying)
            {
                //Basic movement -- this works, pls no touch
                rb.MovePosition(new Vector2(transform.position.x + Input.GetAxisRaw("Horizontal") * speed, transform.position.y + Input.GetAxisRaw("Vertical") * speed));
            }

            if (!swordAudio.isPlaying)
            {
                if (Input.GetAxisRaw("Horizontal") > 0)
                {
                    anim.Play("PlayerRight");
                    sr.flipX = false;
                    direction = "Right";
                }
                else if (Input.GetAxisRaw("Horizontal") < 0)
                {
                    anim.Play("PlayerRight");
                    sr.flipX = true;
                    direction = "Left";
                }
                else if (Input.GetAxisRaw("Vertical") > 0)
                {
                    anim.Play("PlayerUp");
                    direction = "Up";
                }
                else if (Input.GetAxisRaw("Vertical") < 0)
                {
                    anim.Play("PlayerDown");
                    direction = "Down";
                }
            }

            if ((Input.GetAxisRaw("Horizontal") != 0 || Input.GetAxisRaw("Vertical") != 0) && !stepAudio.GetComponent<AudioSource>().isPlaying)
            {
                stepAudio.GetComponent<AudioSource>().clip = steps[1];
                stepAudio.GetComponent<AudioSource>().Play();
            }
            else if (Input.GetAxisRaw("Horizontal") == 0 && Input.GetAxisRaw("Vertical") == 0 && !swordAudio.isPlaying)
            {
                stepAudio.GetComponent<AudioSource>().Stop();
                switch (direction)
                {
                    case "Down":
                        anim.Play("PlayerDownIdle");
                        break;
                    case "Up":
                        anim.Play("PlayerUpIdle");
                        break;
                    case "Left":
                        anim.Play("PlayerRightIdle");
                        sr.flipX = true;
                        break;
                    case "Right":
                        anim.Play("PlayerRightIdle");
                        sr.flipX = false;
                        break;
                }
            }

            if (Input.GetKeyDown(KeyCode.Alpha1) && harmTraps >= 1)
            {
                GameObject newHarmTrap = Instantiate(harmTrap);
                newHarmTrap.transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                newHarmTrap.transform.position += new Vector3(0, 0, 10);
                harmTraps -= 1;
            }

            if (Input.GetKeyDown(KeyCode.Alpha2) && slowTraps >= 1)
            {
                GameObject newSlowTrap = Instantiate(slowTrap);
                newSlowTrap.transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                newSlowTrap.transform.position += new Vector3(0, 0, 10);
                slowTraps -= 1;
            }

            if (Input.GetMouseButtonDown(0) && !swordAudio.isPlaying)
            {
                swordAudio.Play();
                switch (direction)
                {
                    case "Down":
                        anim.Play("PlayerSwordDown");
                        break;
                    case "Up":
                        anim.Play("PlayerSwordUp");
                        break;
                    case "Left":
                        anim.Play("PlayerSwordRight");
                        sr.flipX = true;
                        break;
                    case "Right":
                        anim.Play("PlayerSwordRight");
                        sr.flipX = false;
                        break;
                }
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

        coreCount.text = "x" + cores.ToString();
        tarCount.text = "x" + tars.ToString();
        teethCount.text = "x" + teeth.ToString();

        if (exp > Math.Pow(level, 2))
        {
            exp -= (int)Math.Pow(level, 2);
            level += 1;
            damage = 10 + (5 * level);
            Debug.Log("Level: " + level.ToString());
        }

        rb.velocity = Vector3.ClampMagnitude(rb.velocity, 3f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.parent != null)
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
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.transform.parent != null)
        {
            //Cancel ability to interact if player is too far away
            if (collision.transform.parent.gameObject.tag == "Interactable")
            {
                spacebarIndicator.SetActive(false);
                canInteract = false;
            }
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

    private IEnumerator passiveHeal()
    {
        while (true)
        {
            yield return new WaitForSeconds(7.5f);
            if (health + 10 <= 100)
                health += 10;
            if (health + 10 > 100)
                health = 100;
            Debug.Log(health);
        }
    }

    bool AnimatorIsPlaying(Animator animator)
    {
        return animator.GetCurrentAnimatorStateInfo(0).length > animator.GetCurrentAnimatorStateInfo(0).normalizedTime;
    }

    bool AnimatorIsPlaying(Animator animator, string stateName)
    {
        return AnimatorIsPlaying(animator) && animator.GetCurrentAnimatorStateInfo(0).IsName(stateName);
    }
}
