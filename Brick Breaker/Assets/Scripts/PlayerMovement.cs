using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    private float posX;
    private bool isBeingHeld = false;

    private Vector2 screenBounds;
    private float objectWidth;
    public GameManager gm;

    private void Start()
    {
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width,Screen.height, Camera.main.transform.position.z));
        objectWidth = transform.GetComponent<SpriteRenderer>().bounds.size.x / 2;
    }

    private void LateUpdate()
    {
        Vector3 po = transform.position;
        po.x = Mathf.Clamp(po.x, screenBounds.x * -1 + objectWidth, screenBounds.x - objectWidth);
        transform.position = po;
    }

    // Update is called once per frame
    void Update()
    {
        if (gm.gameOver)
        {
            return;
        }

        if(isBeingHeld == true)
        {
            Vector2 mousePos = Input.mousePosition;
            mousePos = Camera.main.ScreenToWorldPoint(mousePos);

            this.gameObject.transform.localPosition = new Vector2(mousePos.x - posX, transform.position.y);
        }

    }

    private void OnMouseDown()
    {

        if (Input.GetMouseButtonDown(0))
        {
            Vector2 mousePos = Input.mousePosition;
            mousePos = Camera.main.ScreenToWorldPoint(mousePos);

            posX = mousePos.x - this.transform.localPosition.x;

            isBeingHeld = true;
        }
    }

    private void OnMouseUp()
    {

        isBeingHeld = false;

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("extra life"))
        {
            gm.UpdateLives(1);
            Destroy(other.gameObject);
        }
        
    }
}
