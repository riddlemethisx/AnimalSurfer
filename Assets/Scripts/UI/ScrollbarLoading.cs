using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

[RequireComponent(typeof(Scrollbar))]
public class ScrollbarLoading : MonoBehaviour
{


    Scrollbar progressBar;
    int activeScene;
    void Start() {


        progressBar = gameObject.GetComponent<Scrollbar>();
        activeScene = SceneManager.GetActiveScene().buildIndex;
        StartCoroutine(startLoading());
    }

    IEnumerator startLoading()
    {
        AsyncOperation async = SceneManager.LoadSceneAsync(activeScene + 1);

        while (!async.isDone)
        {
            progressBar.size = async.progress;
            yield return null;
        }
    }
}
