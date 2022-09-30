using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndTrigger : MonoBehaviour
{

    public Animator characterAnim;

    void Start()
    {

    }

    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            //Debug.Log("de�di");
            characterAnim.SetTrigger("Dance");
            CollectController.isDestroyed = true;
        }
    }
}
