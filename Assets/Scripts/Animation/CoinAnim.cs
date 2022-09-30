using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class CoinAnim : MonoBehaviour
{

    int coin;
    float loadCoin = 0;
    Text txtCoin;


    void Start()
    {
        txtCoin = GetComponent<Text>();
        coin = PlayerManager.GetCoin();
    }

    void Update()
    {
        if (loadCoin < coin)
            loadCoin += 1;

        txtCoin.text = ((int)loadCoin).ToString();
    }
}
