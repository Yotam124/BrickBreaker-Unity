using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour
{
    public int points;
    public int hitsToBreak;
    public Transform brick;

    public void BreakBrick()
    {
        if(hitsToBreak == 1)
        {
            Instantiate(brick, transform.position, transform.rotation);
            Destroy(gameObject);
        }
        else
        {
            hitsToBreak--;
        }
        
    }
    void Update()
    {
        gameObject.transform.parent = GameObject.FindWithTag("level").transform;
    }
        public bool checkhits()
    {
        if(hitsToBreak == 1)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
