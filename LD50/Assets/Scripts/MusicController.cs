using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicController : MonoBehaviour
{
    public AudioClip[] audioClips = new AudioClip[4];
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(playMusic());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator playMusic()
    {
        while (true)
        {
            GetComponent<AudioSource>().clip = audioClips[Random.Range(0, 4)];
            GetComponent<AudioSource>().Play();
            yield return new WaitForSeconds(Random.Range(25, 50));
        }
    }
}
