using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PingPongObject : MonoBehaviour {

    private float limitX = 750;
    private float limitY = 400;

    public float speedX;
    public float speedY;

    private void Awake()
    {
        speedX = UnityEngine.Random.Range(-10, 10);
        speedY = UnityEngine.Random.Range(-10, 10);

        if(speedX == 0)
        {
            speedX = 1;
        }
        if(speedY == 0)
        {
            speedY = 1;
        }
    }

   

    private void Update()
    {
        Vector3 newPos = this.gameObject.transform.localPosition;

        newPos.x = newPos.x + speedX;
        newPos.y = newPos.y + speedY;

        if (newPos.x < -limitX)
        {
            newPos.x = -limitX;
            speedX = UnityEngine.Random.Range(1, 10);
            
        }
        else if(newPos.x > limitX)
        {
            newPos.x = limitX;
            speedX = UnityEngine.Random.Range(-10, -1);
        }

        if(newPos.y < -limitY)
        {
            newPos.y = -limitY;
            speedY = UnityEngine.Random.Range(1, 10);
        }
        else if(newPos.y > limitY)
        {
            newPos.y = limitY;
            speedY = UnityEngine.Random.Range(-10, -1);
        }
        this.gameObject.transform.localPosition = newPos;
    }

}
