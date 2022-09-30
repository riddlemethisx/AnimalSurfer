using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pause : MonoBehaviour
{

    [SerializeField] Button pauseButton;
    [SerializeField] Button pausePanelCloseButton;

    [SerializeField] GameObject pausePanel;
    [SerializeField] GameObject gamePlayPanel;


    void Start()
    {
        pausePanel.SetActive(false);
        pauseButton.onClick.AddListener(ClickedPause);
        pausePanelCloseButton.onClick.AddListener(PausePanelClose);

    }

    private void PausePanelClose()
    {
        gamePlayPanel.SetActive(true);
        pausePanel.SetActive(false);
        Time.timeScale = 1;
    }

    private void ClickedPause()
    {
        gamePlayPanel.SetActive(false);
        pausePanel.SetActive(true);
        Time.timeScale = 0;
        
    }

    void Update()
    {
        
    }


}
