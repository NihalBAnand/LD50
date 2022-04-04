using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HarmTrapController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("SpikeTrapIdle"))
        {
            StartCoroutine(kill());
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            collision.GetComponent<PlayerController>().health -= 20;
            GetComponent<Animator>().Play("SpikeTrap");
            Debug.Log("HIIII");
        }
        else if (collision.tag == "Monster")
        {
            Destroy(collision.gameObject);
            GetComponent<Animator>().Play("SpikeTrap");
        }
        
    }

    IEnumerator kill()
    {
        yield return new WaitForSeconds(GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).length + GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).normalizedTime);
        Destroy(gameObject);
    }
}
