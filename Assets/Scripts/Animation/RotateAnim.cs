using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateAnim : MonoBehaviour
{

    [SerializeField]
    int rotationSpeed = 10;

    void Start()
    {

    }


    void Update()
    {
        transform.Rotate(0, 0, rotationSpeed * Time.deltaTime);
        
    }


 

}
