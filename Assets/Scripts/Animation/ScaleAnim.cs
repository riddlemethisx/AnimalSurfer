using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ScaleAnim : MonoBehaviour
{

    Vector3 originalScale;

    void Start()
    {
        originalScale = gameObject.transform.localScale;
        gameObject.transform.localScale = Vector3.zero;

    }

    void Update()
    {
        gameObject.transform.DOScale(originalScale, 1f);
        // Invoke("TimeStop", 1.1f);

    }
    void TimeStop()
    {
        Time.timeScale = 0;
    }


}
