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

    enum TextMode{
        MasCount,
        turn,
        round,
        Whichturn,
    }
    [SerializeField]
    TextMode textMode = new TextMode();
    void Start()
    {
        scoreText = GetComponent<Text>();
    }

    void Update()
    {
        switch (textMode)
        {
            case TextMode.MasCount:
                if(scoreText.text != Player.instance.playerwalkcount.ToString())
                {
                    scoreText.text = Player.instance.playerwalkcount.ToString();
                }
                break;
            case TextMode.turn:
                if (scoreText.text != RoundController.instance.GetETurn().ToString())
                {
                    scoreText.text = RoundController.instance.GetETurn().ToString();
                }
                break;
            case TextMode.round:
                if (scoreText.text != RoundController.instance.GetERound().ToString())
                {
                    scoreText.text = RoundController.instance.GetERound().ToString();
                }
                break;
            case TextMode.Whichturn:
                if (Player.isPlayerTurn)
                {
                    scoreText.text = Myturn.ToString();
                }
                else
                {
                    scoreText.text = Eneturn.ToString();
                }
                break;
            default:
                Debug.Log("error");
                break;

        }
    }
}
