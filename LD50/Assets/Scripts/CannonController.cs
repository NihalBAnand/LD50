using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
public class CannonController : InteractableGeneric
{
    // Start is called before the first frame update
    public PowderLevelController pc;

    private bool activated;

    private AudioSource audioS;
    public Animator animator;

    public override void Interaction(GameObject player)
    {
        if (!activated)
        {
            activated = true;
            Camera.main.transform.parent = GameObject.Find("Center").transform;
            Camera.main.transform.position = GameObject.Find("GunpowderStorage").transform.position;
            Camera.main.transform.position += new Vector3(0, 0, -10);
            GameObject.Find("GunpowderLevel").GetComponent<Text>().enabled = true;
        }
        else
        {
            activated = false;
            Camera.main.transform.parent = GameObject.FindGameObjectWithTag("Player").transform;
            Camera.main.transform.position = GameObject.Find("Player").transform.position;
            Camera.main.transform.position += new Vector3(0, 0, -10);
            //GameObject.Find("GunpowderStorage").transform.Find("Canvas").gameObject.SetActive(false);
            GameObject.Find("GunpowderLevel").GetComponent<Text>().enabled = false;
        }
    }


    void Start()
    {
        pc = Resources.FindObjectsOfTypeAll<PowderLevelController>()[0];
        

        activated = false;
        GameObject.Find("GunpowderLevel").GetComponent<Text>().enabled = false;

        audioS = transform.Find("Audio Source").gameObject.GetComponent<AudioSource>();

        StartCoroutine(fireShot());

        animator = GetComponent<Animator>();
        animator.Play("CannonIdle");
    }

    // Update is called once per frame
    void Update()
    {
        if (!AnimatorIsPlaying(animator, "CannonFire"))
        {
            animator.Play("CannonIdle");
        }
        
    }

    //lines 61-69 by @edu4hd0 on Unity forums
    bool AnimatorIsPlaying(Animator animator)
    {
        return animator.GetCurrentAnimatorStateInfo(0).length > animator.GetCurrentAnimatorStateInfo(0).normalizedTime;
    }

    bool AnimatorIsPlaying(Animator animator, string stateName)
    {
        return AnimatorIsPlaying(animator) && animator.GetCurrentAnimatorStateInfo(0).IsName(stateName);
    }


    IEnumerator fireShot()
    {
        while (true)
        {
            yield return new WaitForSeconds(3f);
            if (pc.cannonStatus && UnityEngine.Random.Range(1,6) == 1)
            {
                audioS.Play();
                GetComponent<Animator>().Play("CannonFire");
            }
        }
    }

}
