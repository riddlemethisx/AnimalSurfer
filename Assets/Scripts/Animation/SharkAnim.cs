using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SharkAnim : MonoBehaviour
{

    public float minXPos;
    public float maxXPos;

    public int animSpeed = 1;


    void Start()
    {
        
    }

    void Update()
    {
        if(transform.position.x < minXPos)
        {
            //�b�r tarafa d�n
            transform.Rotate(0, -180, 0);
            
        }

        if(transform.position.x > maxXPos)
        {
            //�b�r tarafa d�n
            transform.Rotate(0, 180, 0);
        }

        transform.Translate(-animSpeed * Time.deltaTime, 0, 0);
    }
}
