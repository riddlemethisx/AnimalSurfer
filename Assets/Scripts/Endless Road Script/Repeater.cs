using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Repeater : MonoBehaviour
{


    [SerializeField] float mapLength;


    [SerializeField] GameObject map1;
    [SerializeField] GameObject map2;
    public static int triggerNumber = 0;



    void OnTriggerEnter(Collider other)
    {
        Debug.Log("oyuncu triggera girdi");
        if (other.gameObject.tag == "Player" && triggerNumber != 0)
        {
            if (triggerNumber % 2 == 1)
            {
                map1.transform.position = new Vector3(map1.transform.position.x, map1.transform.position.y, map1.transform.position.z + mapLength);
            }
            else
            {
                map2.transform.position = new Vector3(map2.transform.position.x, map2.transform.position.y, map2.transform.position.z + mapLength);
            }
        }
        triggerNumber++;
    }
}
