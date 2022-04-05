using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoseScreenController : MonoBehaviour
{
    public GameObject restartButton;
    public GameObject quitButton;
    // Start is called before the first frame update
    void Start()
    {
        restartButton.GetComponent<Button>().onClick.AddListener(restart);
        quitButton.GetComponent<Button>().onClick.AddListener(quit);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void restart()
    {
        SceneManager.LoadScene("StartScene");
    }

    private void quit()
    {
        Application.Quit();
    }
}
