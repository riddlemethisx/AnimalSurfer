using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodeMovement : MonoBehaviour
{

    public Transform connectedNode;

    float zPos;


    private void Start()
    {
        zPos = CollectController.zDistance;
        gameObject.transform.rotation = Quaternion.Euler(new Vector3(0, -90, 90));
        GetComponent<Coin>().enabled = false;
    }


    void Update()
    {
        transform.position = new Vector3(
            Mathf.Lerp(transform.position.x, connectedNode.position.x, Time.deltaTime * 20),
            connectedNode.position.y,
            connectedNode.position.z - zPos
            );


        //transform.position = new Vector3(
        //    connectedNode.position.x + 1,
        //    connectedNode.position.y,
        //    Mathf.Lerp(transform.position.z, connectedNode.position.z, Time.deltaTime * 20)
        //    );
    }
}
