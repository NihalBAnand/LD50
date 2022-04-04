using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClockController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<RectTransform>().eulerAngles = new Vector3(0, 0, 90 - (Time.fixedUnscaledTime * (360 / 600f)));
    }
}
