using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Events : MonoBehaviour
{

    [SerializeField] Button replayButton = null;
    [SerializeField] Button quitButton = null;

    private void Start()
    {

            replayButton.onClick.AddListener(ReplayGame);
            quitButton.onClick.AddListener(QuitGame);

        



    }

    public void ReplayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Repeater.triggerNumber=0;
    }
    public void QuitGame()
    {
        Application.Quit();
    }

}
