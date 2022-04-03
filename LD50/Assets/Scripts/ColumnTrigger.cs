using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class ColumnTrigger : MonoBehaviour
{
    private GameObject parent;
    // Start is called before the first frame update
    void Start()
    {
        parent = transform.parent.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Move in front of player if the trigger is tripped
        if (parent.GetComponent<SpriteRenderer>() != null)
            parent.GetComponent<SpriteRenderer>().sortingLayerName = "Objects-Front";
        if (parent.GetComponent<TilemapRenderer>() != null)
            parent.GetComponent<TilemapRenderer>().sortingLayerName = "Objects-Front";
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        //Move behind the player if the trigger is un-tripped
        if (parent.GetComponent<SpriteRenderer>() != null)
            parent.GetComponent<SpriteRenderer>().sortingLayerName = "Objects-Behind";
        if (parent.GetComponent<TilemapRenderer>() != null)
            parent.GetComponent<TilemapRenderer>().sortingLayerName = "Objects-Behind";
    }
}
