using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PowderLevelController : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject cannon;
    void Start()
    {
        gameObject.GetComponent<Text>().text = cannon.GetComponent<CannonController>().gunpowderStack.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
