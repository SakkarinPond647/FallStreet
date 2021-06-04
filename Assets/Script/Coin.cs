using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public float moveSpeed;
    public Vector2 minMaxYValue;
    Vector2 pos;
    public SpriteRenderer spriteRenderer;
    public CircleCollider2D circleCollider;

    public AudioClip coinSound;

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.up * moveSpeed * Time.deltaTime;

        if (transform.position.y > minMaxYValue.x)
        {
            pos = transform.position;
            pos.x = transform.position.x;
            pos.y = minMaxYValue.y;
            transform.position = pos;
            //ShowOrHide();
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            StartCoroutine(HideObject());
            Debug.Log("Destroy Coin");
            AudioSource.PlayClipAtPoint(coinSound, transform.position);
            spriteRenderer.enabled = false;
            circleCollider.enabled = false;
        }
    }

    IEnumerator HideObject()
    {
        yield return new WaitForSeconds(3);
        spriteRenderer.enabled = true;
        circleCollider.enabled = true;
    }


}
