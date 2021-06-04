using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DelayedStartScript : MonoBehaviour
{
    public GameObject countDown;
    public Image image;
    public Button button;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(nameof(StartDelay));
        image.enabled = false;
        button.enabled = false;
    }
    
    IEnumerator StartDelay()
    {
        Time.timeScale = 0;
        float pauseTime = Time.realtimeSinceStartup + 3f;
        while (Time.realtimeSinceStartup < pauseTime)
            yield return 0;
        countDown.gameObject.SetActive(false);
        Time.timeScale = 1;

        image.enabled = true;
        button.enabled = true;
    }
}
