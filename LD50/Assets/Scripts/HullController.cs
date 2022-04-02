using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HullController : MonoBehaviour
{
    public GameObject hole;
    public int holes;

    private Renderer renderer;
    // Start is called before the first frame update
    void Start()
    {
        holes = 0;
        StartCoroutine(updateTears(2));
        renderer = GetComponent<Renderer>();
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

            //1 in 10 chance of spawning a hole
            if (Random.Range(0, 0) == 0)
            {
                GameObject newHole = Instantiate(hole);
                newHole.transform.parent = gameObject.transform;
                newHole.transform.position = new Vector3(Random.Range((float)(transform.position.x - (0.5 * renderer.bounds.size.x) + 1), (float)(transform.position.x + (0.5 * renderer.bounds.size.x) - 1)), Random.Range((float)(transform.position.y - (0.5 * renderer.bounds.size.y) + 1), (float)(transform.position.y + (0.5 * renderer.bounds.size.y) - 1)));
                Debug.Log(newHole.transform.position);
                holes += 1;
            }
        }
    }
}
