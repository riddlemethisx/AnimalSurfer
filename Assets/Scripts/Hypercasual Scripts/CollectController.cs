using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectController : MonoBehaviour
{

    public static int zDistance = 1;

    public List<GameObject> coinObjects = new List<GameObject>();

    public static bool isDestroyed = false;

    bool onetime = false;

    private void Start()
    {
        zDistance = 1;
        isDestroyed = false;
        onetime = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Collect"))
        {
            //other.gameObject.transform.position = transform.position + Vector3.left;

            //Destroy(gameObject.GetComponent<CollectController>());
            //other.gameObject.AddComponent<CollectController>();
            zDistance++;

            //other.gameObject.GetComponent<Collider>().isTrigger = false;
            coinObjects.Add(other.gameObject);

            other.gameObject.AddComponent<NodeMovement>();
            other.gameObject.GetComponent<NodeMovement>().connectedNode = transform; 

            other.gameObject.tag = "Collected";
        }

        
    }

    private void Update()
    {
        if (isDestroyed && !onetime)
        {
            StartCoroutine(DestroyObjects());
            onetime = true;
        }
    }

    IEnumerator DestroyObjects()
    {
        if (coinObjects != null)
        {
            if(coinObjects.Count > 0) { 
                Destroy(coinObjects[coinObjects.Count - 1]);
                coinObjects.RemoveAt(coinObjects.Count - 1);
            }
            else { 
                Destroy(coinObjects[0]);
                coinObjects.RemoveAt(0);
            }
            yield return new WaitForSeconds(0.1f);
            if(coinObjects.Count != 0)
            StartCoroutine(DestroyObjects());
        }
    }



}
