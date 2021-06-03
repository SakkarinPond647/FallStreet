using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGScore : MonoBehaviour
{
    Material material;
    Vector2 offset;

    public float xVelocity, yVelocity;

    // Start is called before the first frame update
    void Start()
    {
        material = GetComponent<Renderer>().material;
        //offset = new Vector2(xVelocity, yVelocity);
    }

    // Update is called once per frame
    void Update()
    {
        offset = new Vector2(xVelocity, -0.4f);
        material.mainTextureOffset += offset * Time.deltaTime;
    }
}

