using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{






    [SerializeField] int rotateSpeed = 30;

    void Start()
    {

    }

    void Update()
    {
        if (gameObject.tag != "Coin2")
            transform.Rotate(rotateSpeed * Time.deltaTime, 0, 0);
        else
            transform.Rotate(0, 0, rotateSpeed * Time.deltaTime);
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            FindObjectOfType<AudioManager>().PlaySound("PickUpCoin");
            PlayerManager.numberOfCoins++;
            //Destroy(gameObject);
        }
    }


}
