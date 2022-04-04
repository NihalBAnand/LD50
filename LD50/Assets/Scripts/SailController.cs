using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SailController : MonoBehaviour
{
    public GameObject tear;
    public int tears;

    public Sprite[] tearSprites = new Sprite[3];

    private Renderer renderer;

    private GameObject ship;

    private int diff;
    // Start is called before the first frame update
    void Start()
    {
        tears = 0;
        diff = 0;

        StartCoroutine(updateTears(diff));
        renderer = GetComponent<Renderer>();

        ship = GameObject.Find("ShipController");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator updateTears(int difficulty)
    {
        while (true)
        {
            //Based on difficulty, change the time in between hole spawn chances
            if (difficulty == 0)
                yield return new WaitForSeconds(10);
            else if (difficulty == 1)
                yield return new WaitForSeconds(5);
            else if (difficulty == 2)
                yield return new WaitForSeconds(3);

            //1 in 10 chance of spawning a tear
            if (Random.Range(0, 10) == 0)
            {
                GameObject newTear = Instantiate(tear);
                //newTear.transform.parent = gameObject.transform;
                newTear.GetComponent<SpriteRenderer>().sprite = tearSprites[Random.Range(0, 3)];
                newTear.transform.position = new Vector3(Random.Range((float)(transform.position.x - (0.5 * renderer.bounds.size.x) + 1), (float)(transform.position.x + (0.5 * renderer.bounds.size.x) - 1)), Random.Range((float)(transform.position.y - (0.5 * renderer.bounds.size.y) + 1), (float)(transform.position.y + (0.5 * renderer.bounds.size.y) - 1)));
                Debug.Log(newTear.transform.position);
                tears += 1;
                if (tears > 1)
                    ship.GetComponent<ShipController>().enemySpawnChance /= (tears - 1) * 2;
                ship.GetComponent<ShipController>().enemySpawnChance *= tears * 2;
            }
        }
    }

    public void increaseDifficulty()
    {
        StopAllCoroutines();
        diff++;
        StartCoroutine(updateTears(diff));
    }
}
