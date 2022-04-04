using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EntryController : MonoBehaviour
{
    // Start is called before the first frame 
    string[] entrys = { "Captain's Log",
                        "The situation is grim. Far more grim than I ever imagined it was possible to be. The cannons have started firing at things, things I can only see the vague shape of in these dark and choppy waters. I fear for my life, and I fear for <i>The Inevitable</i>. God help me...",
                        "I’ve seen one of these monsters. They are unlike anything I’ve ever seen… and they seem bloodthirsty. They tried to kill me, but I managed to survive their attack with the help of my trusty cutlass. One of them had eyes like headlights that I can’t get out of my head… I think that, even if I survive this disaster, I shall not be the same as before it.",
                        "I often think of my crew, and I hate myself for not having done more for them. I see their faces whenever I close my eyes, and when I look over the railing, I see their faces, questioning, blaming me. “Why,” they ask, “Why did you not save us?” I have no answer. As their captain, I have failed them.",
                        "The main sail has seen better days. I can patch it up as a temporary measure, but I cannot see a way to maintain it if this storm keeps up for much longer. These blasted monsters will take any chance they can to get at me, so I can’t furl it either. I can only really hope that <i>The Inevitable</i> lives up to her name, and gets me home safe.",
                        "As if matters could not get any worse, the hull has begun to leak. I suspect that there are some underwater monsters, trying to get in. As with the sails, I can only patch up holes as they appear. This situation is increasingly becoming hopeless.",
                         "It seems that the light can be refueled with some sort of crystal from the monsters, similar to quartz and the like, but… dirty, somehow. Tainted. Regardless, results are results, and I am glad to be able to hope, even a little bit. I wonder if I deserve to, after what I’ve done",
                         "The rain is relentless. I had dared to hope the storm would be brief, but that hope is dashed by reality. It’s been going for hours now. Lightning bolts give me some light by which to see the monsters as they approach, but much of me would rather be left blissfully unaware.",
                         "If anyone else is reading this, I ask that you deliver this log to the family of Jonathan Wainwright of Elindra City. Tell them, if I am still in living memory, that I love them. No, even if I am not… I don’t know if I write this because I want to be remembered. I don’t know much anymore… ",
                         "I feel that dawn must be approaching. It has been a long night indeed, but I dare not believe that my ordeal will end with the rising of the sun. I do believe I will struggle to my last breath, and I will die, here at sea, devoured by one of these terrible creatures. There are worse fates, I suppose, but I will fight as long as I can.",
                          "I see the rays of dawn. I see my crewmates, too. They want me to come with them, to join with the fate that I deserve, rotting at the bottom of the ocean with them. I tell them I cannot by choice depart this world, for I have a duty to my family to continue as long as I "};
    public ArrayList displayed = new ArrayList();

    //Factors
    public bool firstMonster = false;
    public bool twomins = false;
    public bool firstSail = false;
    public bool firstHull = false;
    public bool firstCore = false;
    public bool level6 = false;
    public bool firstGun = false;
    public bool firstTrap = false;
    public bool ninemins = false;

    public bool firstMonsterDone = false;
    public bool twominsDone = false;
    public bool firstSailDone = false;
    public bool firstHullDone = false;
    public bool firstCoreDone = false;
    public bool level6Done = false;
    public bool firstGunDone = false;
    public bool firstTrapDone = false;
    public bool nineminsDone = false;

    //scroll stuff
    public int counter = 0;
    bool isNext = false;
    bool isPrev = false;

    void Start()
    {
        displayed.Add(entrys[0]);
        displayed.Add(entrys[1]);
        gameObject.GetComponent<Text>().text = displayed[0].ToString();

        GameObject.Find("ForwardButton").GetComponent<Button>().onClick.AddListener(moveForward);
        GameObject.Find("BackButton").GetComponent<Button>().onClick.AddListener(moveBack);
    }

    // Update is called once per frame
    void Update()
    {
        addEntrys();
        changeDisp();

        if (counter < 0)
            counter = 0;
        if (counter >= displayed.Count)
            counter = displayed.Count - 1;
        
        gameObject.GetComponent<Text>().text = displayed[counter].ToString();
        
    }

    private void changeDisp()
    {
        if(Input.GetKeyDown(KeyCode.RightArrow))
        {
            counter += 1;
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            counter -= 1;
        }
    }

    private void addEntrys()
    {

        if (firstMonster && !firstMonsterDone)
        {
            firstMonsterDone = true;
            displayed.Add(entrys[2]);

        }
        if (twomins && !twominsDone)
        {
            twominsDone = true;
            displayed.Add(entrys[3]);
        }
        if (firstSail && !firstSailDone)
        {
            firstSailDone = true;
            displayed.Add(entrys[4]);
        }
        if (firstHull && !firstHullDone)
        {
            firstHullDone = true;
            displayed.Add(entrys[5]);
        }
        if (firstCore && !firstCoreDone)
        {
            firstCoreDone = true;
            displayed.Add(entrys[6]);
        }
        if (level6 && !level6Done)
        {
            level6Done = true;
            displayed.Add(entrys[7]);
        }
        if (firstGun && !firstGunDone)
        {
            firstGunDone = true;
            displayed.Add(entrys[8]);
        }
        if (firstTrap && !firstTrapDone)
        {
            firstTrapDone = true;
            displayed.Add(entrys[9]);
        }
        if (ninemins && !nineminsDone)
        {
            nineminsDone = true;
            displayed.Add(entrys[10]);
        }

    }

    public void moveForward()
    {
        counter++;
    }

    public void moveBack()
    {
        counter--;
    }
}
