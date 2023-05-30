using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Count : MonoBehaviour
{
    private Text scoreText;
    public int score = 0;
    string Myturn = "自分のターン";
    string Eneturn = "相手のターン";
    public bool IorEnemy = false;
    void Start()
    {
        scoreText = GetComponentInChildren<Text>();
        if (!IorEnemy)
        {
            scoreText.text = "0";
        }
    }

    void Update()
    {
        if(!IorEnemy)
            scoreText.text = score.ToString();
        if(IorEnemy)
        {
            if(Player.instance.isPlayerTurn)
            {
                scoreText.text = Myturn.ToString();
            }else
            {
                scoreText.text = Eneturn.ToString();
            }
        }
    }
}
