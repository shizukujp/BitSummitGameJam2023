using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using static Unity.VisualScripting.Metadata;

public class Player : MonoBehaviour
{
    //他のスクリプトから参照できるようにする
    public static Player instance;

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

    public GameObject player;   //①移動させたいオブジェクト
    public int speed = 5;       //移動スピード
    public int playerwalkcount = 0;    //プレイヤー歩数のカウンター
    GameObject clickedGameObject;//クリックされたゲームオブジェクトを代入する変数
    Vector2 RL;//移動する場所のX座標
    Vector2 UD;//移動する場所のY座標
    public Vector3 currentPos;
    public Vector3 clickPos;
    bool First = false;
    bool Second = false;
    float CurrentY;//現在のプレイヤーのY座標
    float CurrentX;//現在のプレイヤーのX座標
    public bool ismove = false;
    
    //クリックした場所の色を変更する
    //public Material MyColor;
    //public Material MyColor2;


    //ターン関連
    public static bool isPlayerTurn;

    Vector2 pos;

    void Start()
    {
        isPlayerTurn = true;
        animator = player.GetComponent<Animator>();
        pos = transform.localScale;//(1.25, 1.25, 1.25)
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            Motion();
        }

        if (isPlayerTurn)
        {
            if (Input.GetMouseButtonDown(0) && Second == false)  //左クリックでif分起動
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                //RaycastHit2D hit2d = Physics2D.Raycast((Vector2)ray.origin, (Vector2)ray.direction);
                RaycastHit2D hit2d = Physics2D.GetRayIntersection(ray, Mathf.Infinity);
                //デバッグ用のレイの描画
                //Debug.DrawRay(ray.origin, ray.direction * 30, Color.red, 20f);
                if (hit2d)
                {
                    //Debug.Log(hit2d.transform.position);
                    CurrentY = player.transform.position.y;
                    CurrentX = player.transform.position.x;
                    clickedGameObject = hit2d.transform.gameObject;
                    //Debug.Log(clickedGameObject);//ゲームオブジェクトの名前を出力
                    RL = new Vector2(clickedGameObject.transform.position.x, player.transform.position.y);

                    if (clickedGameObject.transform.position == player.transform.position)
                    {
                        clickedGameObject = null;
                        //First = Second = false;
                    }
                    else if (Vector2.Distance(player.transform.position, clickedGameObject.transform.position) / 1f > 2f)
                    {
                        Debug.Log("移動できません");
                        
                        clickedGameObject = null;
                      
                    }
                    else
                    {
                        First = Second = true;
                        currentPos = player.transform.position;
                        ismove = true;
                        animator.SetBool("isRunning", true);
                        
                        //移動する場所のマスを変更する
                        clickPos = clickedGameObject.transform.position;
                        if (clickedGameObject.transform.position.x - transform.position.x > 0 && pos.x > 0)
                        {
                            pos.x *= -1;
                        }
                        if (clickedGameObject.transform.position.x - transform.position.x < 0 && pos.x < 0)
                        {
                            pos.x *= -1;
                        }
                        transform.localScale = pos;
                        //clickedGameObject.GetComponent<SpriteRenderer>().color = new Color(0.157f, 0.157f, 0.157f, 0.475f);


                    }
                }
            }
        }
        //プレイヤーの移動＋歩数・ターンカウント
        if (clickedGameObject)
        {   
            if (clickedGameObject.transform.position.x != player.transform.position.x && First)
            {
                player.transform.position = Vector2.MoveTowards(player.transform.position, RL, speed * Time.deltaTime);
                if(player.transform.position.x > CurrentX)
                {
                    if (Mathf.Abs(player.transform.position.x - CurrentX)/1 >= 1)
                    {
                        playerwalkcount++;
                        CurrentX = Mathf.Floor(player.transform.position.x);
                    }
                }else if(player.transform.position.x < CurrentX)
                {
                    if (Mathf.Abs(CurrentX - player.transform.position.x)/1 >= 1)
                    {
                        playerwalkcount++;
                        CurrentX = Mathf.Ceil(player.transform.position.x);
                    }
                }
                if (clickedGameObject.transform.position.x == player.transform.position.x)
                {
                    First = false;
                }
            }else
            {
                UD = new Vector2(player.transform.position.x, clickedGameObject.transform.position.y);
                player.transform.position = Vector2.MoveTowards(player.transform.position, UD, speed * Time.deltaTime);
                if (player.transform.position.y > CurrentY)
                {
                    if (Mathf.Abs(player.transform.position.y - CurrentY) / 1 >= 1)
                    {
                        playerwalkcount++;
                        CurrentY = Mathf.Floor(player.transform.position.y);
                    }
                }
                else if (player.transform.position.y < CurrentY)
                {
                    if (Mathf.Abs(CurrentY - player.transform.position.y) / 1 >= 1)
                    {
                        playerwalkcount++;
                        CurrentY = Mathf.Ceil(player.transform.position.y);
                    }
                }

                if (clickedGameObject.transform.position.y == player.transform.position.y)
                {
                    Second = false;

                    RoundController.instance.SetTurn(RoundController.instance.GetTurn() + 1);
                    Debug.Log("移動完了");
                    PocketWatch.SameTime = false;
                    isPlayerTurn = false;
                    ismove = false;
                    animator.SetBool("isRunning", false);
                    //CanMoveMas.instance.CanMove();
                    clickedGameObject = null;
                    if(EnemyMove.Deathcount == 1)
                    {
                        EnemyMove.Deathcount = 2;
                    }else
                    {
                        EnemyMove.IsEnemyMove = true;
                        RoundController.instance.EnemyTurn();
                    }
                    
                }
            }
        }
    }
    void Motion()
    {
        animator.SetTrigger("IsMotion");
    }
}
