using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColumnTrigger : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        transform.parent.gameObject.GetComponent<SpriteRenderer>().sortingLayerName = "Objects-Front";
        Debug.Log(transform.parent.gameObject.GetComponent<SpriteRenderer>().rendererPriority);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        transform.parent.gameObject.GetComponent<SpriteRenderer>().sortingLayerName = "Objects-Behind";
    }
}
