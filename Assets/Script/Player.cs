using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Advertisements;

public class Player : MonoBehaviour
{
    public Vector2 xValue ;
    public bool changeDirecionBool, leftFacing, changeIt,easing;
    Animator animator;
    Vector3 desiredPosition;

    public GameObject loseMenuUI;

    public ScorePerSecond score;

    string placementId = "video";

    // Start is called before the first frame update
    void Start()
    {
        DesiredPosition();
        changeDirection();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (changeIt)
        {
            if (easing)
            {
                transform.position = Vector3.Lerp(transform.position, desiredPosition, .1f);
            }
            else
            {
                transform.position = desiredPosition;
            }
          

            if (Mathf.Abs(desiredPosition.x - transform.position.x) <= 0.1f)
            {
                //Debug.Log("Changing gravity");
                changeIt = false;
            }

        }
        animator.SetBool("ChangeDirection", changeDirecionBool);
    }
    public void CallThisMethod()
    {
        DesiredPosition();
        changeDirection();
    }
    public void DesiredPosition()
    {
        desiredPosition = new Vector2(changeDirecionBool ? xValue.x : xValue.y, transform.position.y);
    }
    void changeDirection()
    {
        changeDirecionBool = !changeDirecionBool;
        // transform.position = Vector3.Lerp(transform.position,desiredPosition,.1f);
        if (changeDirecionBool != leftFacing)
        {
            changeIt = true;

            leftFacing = changeDirecionBool;
        }

        //Debug.Log(transform.position.x);
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Spike")
        {
            //Debug.Log("dead Player");
            ShowAds();
            loseMenuUI.SetActive(true);
            Time.timeScale = 0;
        }

        if (collision.tag == "Coin")
        {
            Debug.Log("Get coin");
            score.scoreAmount += 10;
        }
    }

    void ShowAds()
    {
        if (Advertisement.IsReady(placementId))
        {
            Advertisement.Show(placementId);
        }
    }
}
