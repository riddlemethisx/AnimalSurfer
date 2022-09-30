using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerManager : MonoBehaviour
{



    public static bool gameOver;
    public GameObject gameOverPanel;

    public static bool isGameStarted;
    public GameObject startingText;
    public GameObject startingTextBg;

    public static int numberOfCoins;

    public Text coinsText;
    public Text coinsTextGameOver;

    public PlayerController player;
    public Animator playerAnimator;

    public static int coinVal;

    void Start()
    {
        gameOver = false;
        gameOverPanel.SetActive(false);
        Time.timeScale = 1;
        isGameStarted = false;
        numberOfCoins = 0;
        startingTextBg.SetActive(true);
    }

    void Update()
    {
        if (gameOver)
        {
            gameOverPanel.SetActive(true);  
            player.enabled=false;
            playerAnimator.enabled=false;
        }
        coinsText.text = numberOfCoins.ToString();
        //coinsTextGameOver.text = numberOfCoins.ToString(); 


        if (SwipeManager.tap)
        {
            isGameStarted = true;
            Destroy(startingText);
            Destroy(startingTextBg);
        }

    }

    public static int GetCoin()
    {
        coinVal = numberOfCoins * 10;
        return coinVal;
    }



}
