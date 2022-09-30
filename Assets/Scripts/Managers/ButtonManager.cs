using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


[RequireComponent(typeof(Button))]
public class ButtonManager : MonoBehaviour
{

    Button button;

    void Start()
    {
        if (gameObject.GetComponent<Button>() != null)
        {
            button = gameObject.GetComponent<Button>();
            if (gameObject.tag == "Replay")
            {
                button.onClick.AddListener(ReplayGame);
            }
            else if (gameObject.tag == "Quit")
            {
                button.onClick.AddListener(QuitGame);
            }
        }
    }

    public void ReplayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
