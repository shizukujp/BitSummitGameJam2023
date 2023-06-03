using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class RoundController : MonoBehaviour
{
    public static RoundController instance;

    //�V�[���̌����ɂ���
    Scene scenePreb;

    int playerturn = 1, playerturnpreb = 1, playerround = 1, enemyturn = 1, enemyround = 1;
    RecordTurnPosition recordTurnPositon;

    private void Awake()
    {
        if (instance == null)
        {
            DontDestroyOnLoad(gameObject);
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        scenePreb = SceneManager.GetActiveScene();
        recordTurnPositon = GetComponent<RecordTurnPosition>();
    }


    //���s�p�֐�
    private void Update()
    {
        //�����V�[�����ς������
        if (SceneManager.GetActiveScene() != scenePreb)
        {
            playerturn = 1;
            playerturnpreb = 1;
            playerround = 1;
            enemyturn = 1;
            enemyround = 1;
            recordTurnPositon.SetTurnPosition(0);
        }

        if (playerturn != playerturnpreb )
        {
            playerturnpreb = playerturn;
            Player.instance.isPlayerTurn = false;
        }
        //�e�X�g�p
        //if (Input.GetKey(KeyCode.Escape) && !Player.instance.isPlayerTurn) EnemyTurnEnd();


        //Debug.Log(enemyturn);
        if (enemyturn >= 12)
        {
            recordTurnPositon.GetTurnPositionToScene(0);

            playerturn = 1;
            playerturnpreb = 1;
            enemyturn = 1;

            //�F�C��
            CanMoveMas.instance.Moveoff();
            CanMoveMas.instance.CanMove();

            //�v���C���[�����̒ǉ�
            Player.instance.isPlayerTurn = true;
        }
    }



    //�����œ����֐�




    //�p�u���b�N�֐�
    public int GetTurn() { return playerturn; }
    public int GetRound() { return playerround; }
    public void SetTurn(int tn) { playerturn = tn; }
    public void SetRound(int rd) { playerround = rd; }
    public void EnemyTurnEnd() 
    { 
        recordTurnPositon.SetTurnPosition(enemyturn);
        enemyturn++;
        if (enemyturn < 12) Player.instance.isPlayerTurn = true;
    }
    public void EnemyRoundEnd()
    {
        enemyround++;
    }
}
