using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyMove : MonoBehaviour
{
    public static EnemyMove instance;
    GameObject GameManager;
    RecordTurnPosition recordTurnPositon;
    public void Awake()
    {
        if (instance == null)
        {
            //DontDestroyOnLoad(gameObject);
            instance = this;
        }
        else
        {
            //Destroy(gameObject);
        }
    }

    Animator animator;
    public float speed = 1f;
    Vector2 vct1;
    Vector2 vct2;
    Vector2 vct3;
    public GameObject Enem;
    public GameObject player;
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
    //敵が移動しているかどうか
    public bool isEneMove = false;
    //敵が動いている方向
    public bool Up,Down, Right, Left;
    public bool FUp, FDown, FRight, FLeft;
    public static int Deathcount = 0;
    void Start()
    {
        GameManager = GameObject.FindGameObjectWithTag("GameController");
        recordTurnPositon = GameManager.GetComponent<RecordTurnPosition>();
        //初めの敵のポジション
        vct1 = new Vector2(transform.position.x, transform.position.y);
        //敵が移動する最も遠いポジション(縦方向)
        vct2 = new Vector2(transform.position.x, EnemyMovePos_y);
        //敵が移動する最も遠いポジション(横方向)
        vct3 = new Vector2(EnemyMovePos_x, transform.position.y);
        animator = GetComponent<Animator>();
        //Up = Down = Right = Left = false;
        Enem = this.gameObject;
        FUp = Up;
        FDown = Down;
        FRight = Right;
        FLeft = Left;
    }

    // Update is called once per frame
    void Update()
    {
        if(!Player.instance.isPlayerTurn)
        {
            Move();
        }
        /*if (Player.instance.ismove || isEneMove)
            Discover(Up, Down, Right, Left);*/
    }

    void Move()
    {
        //アラームモードにはいったら
        if(Discover())
        {
            isEneMove = true;
            One = false;
        }
        if (Deathcount == 1)
        {
            //ループ
            Debug.Log("死に戻り");
            Deathcount = 2;
            isEneMove = true;
            One = false;
            //SceneManager.LoadScene("SampleScene2");
        }

        //次移動する場所の設定
        if (Go && One && isVertical)
        {
            //縦方向への移動(vct2へ向かう)
            if(vct2.y < transform.position.y)
            {
                //下方向
                MovePos = new Vector2(transform.position.x, transform.position.y - 1f);
                Down = true;
                Up = Right = Left = false;
            }
            else if(vct2.y > transform.position.y)
            {
                //上方向
                MovePos = new Vector2(transform.position.x, transform.position.y + 1f);
                Up = true;
                Down = Right = Left = false;
            }
            One = false;
            isEneMove = true; 
            animator.SetBool("IsMove", true);
        }
        else if(Go && One && !isVertical)
        {
            //横方向への移動(vct3へ向かう)
            if (vct3.x < transform.position.x)
            {
                //左方向
                MovePos = new Vector2(transform.position.x - 1f, transform.position.y);
                Right = true;
                Up = Down = Left = false;
            }
            else if (vct3.x > transform.position.x)
            {
                //右方向
                MovePos = new Vector2(transform.position.x + 1f, transform.position.y);
                Left = true;
                Up = Right = Down = false;
            }
            One = false;
            isEneMove = true;
            animator.SetBool("IsMove", true);
        }
        else if(!Go && One && isVertical)
        {
            //自分が初めにいた場所へ向かう(縦方向)
            if (vct1.y < transform.position.y)
            {
                MovePos = new Vector2(transform.position.x, transform.position.y - 1f);
                Down = true;
                Up = Right = Left = false;
            }
            else if (vct1.y > transform.position.y)
            {
                MovePos = new Vector2(transform.position.x, transform.position.y + 1f);
                Up = true;
                Down = Right = Left = false;
            }
            One = false;
            isEneMove = true;
            animator.SetBool("IsMove", true);
        } else if(!Go && One && !isVertical)
        {
            //自分が初めにいた場所へ向かう(横方向)
            if (vct1.x < transform.position.x)
            {
                MovePos = new Vector2(transform.position.x - 1f, transform.position.y);
                Right = true;
                Up = Down = Left = false;
            }
            else if (vct1.x > transform.position.x)
            {
                MovePos = new Vector2(transform.position.x + 1f, transform.position.y);
                Left = true;
                Up = Right = Down = false;
            }
            One = false;
            isEneMove = true;
            animator.SetBool("IsMove", true);
        }

        transform.position = Vector2.MoveTowards(transform.position, MovePos, speed * Time.deltaTime);
        if(transform.position.x == MovePos.x && transform.position.y == MovePos.y)
        {
            //Debug.Log("敵の移動完了");
            animator.SetBool("IsMove", false);
            player.
            if (Discover())
            {
                animator.SetBool("isDiscover", true);
                Deathcount = 1;
            }
            Player.instance.isPlayerTurn = true;
            isEneMove = false;
            One = true;
        }

        // 敵がvct2かvct3、または元いた場所に到達したかどうか
        if (isVertical)
        {

            //縦方向の場合(vct2)
            if (transform.position.y == vct2.y)
            {
                if (Up)
                {
                    Up = false;
                    Down = true;
                }
                if (Down)
                {
                    Down = false;
                    Up = true;
                }
                Go = false;
                RoundController.instance.MasRiset();
            }
            else if (transform.position.y == vct1.y)
            {
                if (Up)
                {
                    Up = false;
                    Down = true;
                }
                if (Down)
                {
                    Down = false;
                    Up = true;
                }
                Go = true;
                RoundController.instance.MasRiset();
            }
        }
        else
        {
            //横方向の場合(vct3)
            if (transform.position.x == vct3.x)
            {
                if (Right)
                {
                    Right = false;
                    Left = true;
                }
                if (Left)
                {
                    Left = false;
                    Right = true;
                }
                Go = false;
                RoundController.instance.MasRiset();
            }
            else if (transform.position.x == vct1.x)
            {
                if (Right)
                {
                    Right = false;
                    Left = true;
                }
                if (Left)
                {
                    Left = false;
                    Right = true;
                }
                Go = true;
                RoundController.instance.MasRiset();
            }
        }

    }

    public bool Discover()
    {
        if(Up)
        {
            if (player.transform.position.y - transform.position.y < 0 ||  4 < player.transform.position.y - transform.position.y) { animator.SetBool("isDiscover", false); return false;}
            if (player.transform.position.x - transform.position.x < -1 || 1 < player.transform.position.x - transform.position.x) { animator.SetBool("isDiscover", false); return false; }
            //Debug.Log("発見！");
            return true;
        }
        if(Down)
        {
            if (transform.position.y - player.transform.position.y < 0 || 4 < transform.position.y - player.transform.position.y) { animator.SetBool("isDiscover", false); return false; }
            if (transform.position.x - player.transform.position.x < -1 || 1 < transform.position.x - player.transform.position.x) { animator.SetBool("isDiscover", false); return false; }
            //Debug.Log("発見！");
            return true;
        }
        if(Right)
        {
            if (player.transform.position.x - transform.position.x < 0f || 4 < player.transform.position.x - transform.position.x) { animator.SetBool("isDiscover", false); return false; }
            if (transform.position.y - player.transform.position.y < -1 || 1 < transform.position.y - player.transform.position.y) { animator.SetBool("isDiscover", false); return false; }
            return true;
        }
        if(Left)
        {
            if (transform.position.x - player.transform.position.x < 0f || 4 < transform.position.x - player.transform.position.x) { animator.SetBool("isDiscover", false); return false; }
            if (transform.position.y - player.transform.position.y < -1 || 1 < transform.position.y - player.transform.position.y) { animator.SetBool("isDiscover", false); return false; }
            return true;
        }
        return false;
    }
}