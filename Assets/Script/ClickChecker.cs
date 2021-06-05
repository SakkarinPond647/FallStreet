﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickChecker : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        if (PauseMenu.gameIsPause == false && Time.timeScale == 1)
        if (PauseMenu.gameIsPause == false)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Vector2 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                RaycastHit2D hit = Physics2D.Raycast(pos, Vector2.zero);
                if (hit)
                {
                    if (hit.transform.name == "LeftSide")
                    {
                        hit.collider.GetComponent<ColliderGO>().CallPlayerMethod();
                    }
                    else if (hit.transform.name == "RightSide")
                    {

                        hit.collider.GetComponent<ColliderGO>().CallPlayerMethod();
                    }
                    else { Debug.Log("Unknown hit from click Checker"); return; }
                }
            }
        }
    }
}
