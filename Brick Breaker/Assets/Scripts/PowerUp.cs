using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    public float speed;
    private Vector2 screenBounds;

    // Start is called before the first frame update
    void Start()
    {
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector2(0f, -1f) * Time.deltaTime * speed);
        if (transform.position.y < -screenBounds.y)
        {
            Destroy(gameObject);
        }
    }
}
