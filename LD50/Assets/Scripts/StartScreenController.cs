using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartScreenController : MonoBehaviour
{

    public GameObject start;
    // Start is called before the first frame update
    void Start()
    {
        start.GetComponent<Button>().onClick.AddListener(startGame);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void startGame()
    {
        SceneManager.LoadScene("MainScene");
    }
}
