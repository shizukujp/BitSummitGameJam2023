using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    Animator animator;
    public float speed = 1f;
    Vector2 vct1;
    Vector2 vct2;
    Vector2 vct3;
    //敵が次のターンに移動するポジション
    Vector2 MovePos;
    //敵がvct2.vct3まで向かっているか(falseの場合、元いた場所まで向かう)
    bool Go = true;
    bool One = true;
    //縦方向に移動するかどうか(falseなら横方向)
    public bool isVertical = true;
    //敵が移動するポジションのy座標
    public int EnemyMovePos_y = 0;
    //敵が移動するポジションのx座標
    public int EnemyMovePos_x = 0;
    // Start is called before the first frame update
    void Start()
    {
        //初めの敵のポジション
        vct1 = new Vector2(transform.position.x, transform.position.y);
        //敵が移動する最も遠いポジション(縦方向)
        vct2 = new Vector2(transform.position.x, EnemyMovePos_y);
        //敵が移動する最も遠いポジション(横方向)
        vct3 = new Vector2(EnemyMovePos_x, transform.position.y);
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(!Player.instance.isPlayerTurn)
        {
            Move();
        }
    }

    void Move()
    {
        //次移動する場所の設定
        if(Go && One && isVertical)
        {
            Debug.Log("++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++");
            //縦方向への移動(vct2へ向かう)
            if(vct2.y < transform.position.y)
            {
                MovePos = new Vector2(transform.position.x, transform.position.y - 1f);
            }else if(vct2.y > transform.position.y)
            {
                MovePos = new Vector2(transform.position.x, transform.position.y + 1f);
            }
            One = false;
            animator.SetBool("IsMove", true);
        }
        else if(Go && One && !isVertical)
        {
            //横方向への移動(vct3へ向かう)
            if (vct3.x < transform.position.x)
            {
                MovePos = new Vector2(transform.position.x - 1f, transform.position.y);
            }
            else if (vct3.x > transform.position.x)
            {
                MovePos = new Vector2(transform.position.x + 1f, transform.position.y);
            }
            One = false;
            animator.SetBool("IsMove", true);
        }
        else if(!Go && One && isVertical)
        {
            //自分が初めにいた場所へ向かう(縦方向)
            if (vct1.y < transform.position.y)
            {
                MovePos = new Vector2(transform.position.x, transform.position.y - 1f);
            }
            else if (vct1.y > transform.position.y)
            {
                MovePos = new Vector2(transform.position.x, transform.position.y + 1f);
            }
            One = false;
            animator.SetBool("IsMove", true);
        } else if(!Go && One && !isVertical)
        {
            //自分が初めにいた場所へ向かう(横方向)
            if (vct1.x < transform.position.x)
            {
                MovePos = new Vector2(transform.position.x - 1f, transform.position.y);
            }
            else if (vct1.x > transform.position.x)
            {
                MovePos = new Vector2(transform.position.x + 1f, transform.position.y);
            }
            One = false;
            animator.SetBool("IsMove", true);
        }

        transform.position = Vector2.MoveTowards(transform.position, MovePos, speed * Time.deltaTime);
        if(transform.position.x == MovePos.x && transform.position.y == MovePos.y)
        {
            Debug.Log("敵の移動完了");
            //Player.instance.TurnText.GetComponent<Count>().score += 1;
            animator.SetBool("IsMove", false);
            RoundController.instance.EnemyTurnEnd();
            One = true;
        }
        //敵がvct2かvct3、または元いた場所に到達したかどうか
        if (isVertical)
        {
            //縦方向の場合(vct2)
            if (transform.position.y == vct2.y)
            {
                Go = false;
            }else if(transform.position.y == vct1.y)
            {
                Go = true;
            }
        }
        else
        {
            //横方向の場合(vct3)
            if (transform.position.x == vct3.x)
            {
                Go = false;
            }
            else if (transform.position.x == vct1.x)
            {
                Go = true;
            }
        }
    }
}
