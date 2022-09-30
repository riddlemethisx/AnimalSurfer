using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LogoAnim : MonoBehaviour
{



    [SerializeField] float minScale;
    [SerializeField] int animSpeed = 3;

    Vector3 myScale;


    void Start()
    {
        myScale = gameObject.transform.localScale;
        gameObject.transform.localScale = myScale / minScale;
    }

    void Update()
    {
        if (gameObject == true)
        {
            if (gameObject.transform.localScale.x < myScale.x)
                gameObject.transform.localScale += Vector3.one * animSpeed * Time.deltaTime;
            else
                Application.LoadLevel(Application.loadedLevel + 1);
        }
    }
}
