using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyMove : MonoBehaviour
{
    public static EnemyMove instance;
    static GameObject GameManager;
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

    public Animator animator;
    public float speed = 1f;

    Vector2 vct1;
    Vector2 vct2;//目的地
    //Vector2 vct3;
    public GameObject Enem;
    public GameObject player;
    //敵が次のターンに移動するポジション
    Vector2 MovePos;
    //敵がvct2.vct3まで向かっているか(falseの場合、元いた場所まで向かう)
    public bool Go = true;
    bool One = true;
    //縦方向に移動するかどうか(falseなら横方向)
    public bool isVertical = true;
    //敵が移動するポジションのy座標
    public int EnemyMovePos_y = 0;
    //敵が移動するポジションのx座標
    public int EnemyMovePos_x = 0;
    //敵が移動しているかどうか
    public bool isEneMove = false;

    public static bool IsEnemyMove = false;
    //敵が動いている方向
    public bool Up,Down, Right, Left;
    public bool FUp, FDown, FRight, FLeft;
    public static int Deathcount = 0;

    public bool isAlerm = false;
    void Start()
    {
        if(player == null) { player = GameObject.Find("Player"); }
        GameManager = GameObject.FindGameObjectWithTag("GameController");
        recordTurnPositon = GameManager.GetComponent<RecordTurnPosition>();
        //初めの敵のポジション
        vct1 = new Vector2(transform.position.x, transform.position.y);
        //敵が移動するポジション
        vct2 = new Vector2(EnemyMovePos_x, EnemyMovePos_y);
        animator = GetComponent<Animator>();

        Enem = this.gameObject;
        FUp = Up;
        FDown = Down;
        FRight = Right;
        FLeft = Left;
    }

    // Update is called once per frame
    void Update()
    {
        if (isEneMove && IsEnemyMove)
        {
            Move();
        }
        //Debug.Log(Discover());
        /*if (Player.instance.ismove || isEneMove)
            Discover(Up, Down, Right, Left);*/
    }

    void Move()
    {
        animator.SetBool("IsMove", !Player.isPlayerTurn);
        //アラームモードにはいったら
        if (Discover() && Deathcount == 0 && One)
        {
            //RoundController.instance.MasRiset();
            Invoke(nameof(Death), 0.25f);
            isEneMove = false;
            One = false;
            isAlerm = true;
        }
        /*if (isAlerm && Deathcount == 1)
        {
            //ループ
            Debug.Log("死に戻り");
            Go = true;
            Deathcount = 2;
            isEneMove = false;
            One = false;
            return;
        }*/

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
        }
        else if(Go && One && !isVertical)
        {
            //横方向への移動(vct3へ向かう)
            if (vct2.x < transform.position.x)
            {
                //左方向
                MovePos = new Vector2(transform.position.x - 1f, transform.position.y);
                Left = true;
                Up = Down = Right = false;
            }
            else if (vct2.x > transform.position.x)
            {
                //右方向
                MovePos = new Vector2(transform.position.x + 1f, transform.position.y);
                Right = true;
                Up = Left = Down = false;
            }
            One = false;
            isEneMove = true;
            //animator.SetBool("IsMove", !Player.isPlayerTurn);
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
            //animator.SetBool("IsMove", !Player.isPlayerTurn);
        } else if(!Go && One && !isVertical)
        {
            //自分が初めにいた場所へ向かう(横方向)
            if (vct1.x < transform.position.x)
            {
                MovePos = new Vector2(transform.position.x - 1f, transform.position.y);
                Left = true;
                Up = Down = Right = false;
            }
            else if (vct1.x > transform.position.x)
            {
                MovePos = new Vector2(transform.position.x + 1f, transform.position.y);
                Right = true;
                Up = Left = Down = false;
            }
            One = false;
            isEneMove = true;
            //animator.SetBool("IsMove", !Player.isPlayerTurn);
        }

        transform.position = Vector2.MoveTowards(transform.position, MovePos, speed * Time.deltaTime);
        if(transform.position.x == MovePos.x && transform.position.y == MovePos.y)
        {
            Debug.Log(gameObject + "の移動完了");
            //this.animator.SetBool("IsMove", !Player.isPlayerTurn);
            
            //RoundController.instance.MasRiset();
            if (Discover())
            {
                isAlerm = true;
                Invoke(nameof(Death), 0.25f);
            }
            Player.isPlayerTurn = true;
            isEneMove = false;
            One = true;
            RoundController.instance.EnemyTurnEnd();
        }

        // 敵がvct2かvct3、または元いた場所に到達したかどうか
        if (isVertical)
        {

            //縦方向の場合(vct2)
            if (transform.position.y == vct2.y)
            {
                int i = 0;
                if (Up && i == 0)
                {
                    Up = false;
                    Down = true;
                    i = 1;
                }
                if (Down && i == 0)
                {
                    Down = false;
                    Up = true;
                }
                Go = false;
                RoundController.instance.MasRiset();
                if (Discover())
                {
                    Invoke(nameof(Death), 0.5f);
                }
                
            }
            else if (transform.position.y == vct1.y)
            {
                int i = 0;
                if (Up && i == 0)
                {
                    Up = false;
                    Down = true;
                    i = 1;
                }
                if (Down && i == 0)
                {
                    Down = false;
                    Up = true;
                }
                Go = true;
                RoundController.instance.MasRiset();
                if (Discover())
                {
                    Invoke(nameof(Death), 0.5f);
                }
               
            }
        }
        else
        {
            //横方向の場合(vct3)
            if (transform.position.x == vct2.x)
            {
                int i = 0;
                if (Right && i == 0)
                {
                    Right = false;
                    Left = true;
                    i = 1;
                }
                if (Left && i == 0)
                {
                    Left = false;
                    Right = true;
                }
                Go = false;
                RoundController.instance.MasRiset();
                if (Discover())
                {
                    Invoke(nameof(Death), 0.5f);
                }
                
            }
            else if (transform.position.x == vct1.x)
            {
                int i = 0;
                if (Right && i == 0)
                {
                    Right = false;
                    Left = true;
                    i = 1;
                }
                if (Left && i == 0)
                {
                    Left = false;
                    Right = true;
                }
                Go = true;
                RoundController.instance.MasRiset();
                if (Discover())
                {
                    Invoke(nameof(Death), 0.5f);
                }
                
            }
        }

    }

    public bool Discover()
    {
        if(Up)
        {
            if (player.transform.position.y - transform.position.y < 0 ||  3 < player.transform.position.y - transform.position.y) { animator.SetBool("isDiscover", false); return false;}
            if (player.transform.position.x - transform.position.x < -1 || 1 < player.transform.position.x - transform.position.x) { animator.SetBool("isDiscover", false); return false; }
            //Debug.Log("発見！");
            return true;
        }
        if(Down)
        {
            if (transform.position.y - player.transform.position.y < 0 || 3 < transform.position.y - player.transform.position.y) { animator.SetBool("isDiscover", false); return false; }
            if (transform.position.x - player.transform.position.x < -1 || 1 < transform.position.x - player.transform.position.x) { animator.SetBool("isDiscover", false); return false; }
            //Debug.Log("発見！");
            return true;
        }
        if(Right)
        {
            if (player.transform.position.x - transform.position.x < 0f || 3 < player.transform.position.x - transform.position.x) { animator.SetBool("isDiscover", false); return false; }
            if (player.transform.position.y - transform.position.y < -1 || 1 < player.transform.position.y - transform.position.y) { animator.SetBool("isDiscover", false); return false; }
            return true;
        }
        if(Left)
        {
            if (transform.position.x - player.transform.position.x < 0f || 3 < transform.position.x - player.transform.position.x) { animator.SetBool("isDiscover", false); return false; }
            if (transform.position.y - player.transform.position.y < -1 || 1 < transform.position.y - player.transform.position.y) { animator.SetBool("isDiscover", false); return false; }
            return true;
        }
        return false;
    }

    void Death()
    {
        Deathcount = 1;
        //CanMoveMas.instance.CanMove();
        RoundController.instance.MasRiset();
        animator.SetBool("isDiscover", true);
    }
    /*void Death2()
    {
        Deathcount = 1;
        //CanMoveMas.instance.CanMove();
        animator.SetBool("isDiscover", true);
    }*/

    public void SetMovingDir(int movex, int movey, bool isver, bool lt, bool rt, bool up, bool dn)
    {
        EnemyMovePos_x = movex;
        EnemyMovePos_y = movey;
        isVertical = isver;
        Left = lt;
        Right = rt;
        Up = up;
        Down = dn;
    }
}
