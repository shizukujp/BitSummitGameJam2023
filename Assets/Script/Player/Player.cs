using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using static Unity.VisualScripting.Metadata;
using TMPro;

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
    bool MotionCheck = false;
    //先に縦に移動するかどうか
    public bool RLfirst = true;
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

    public GameObject[] enemys;
    [SerializeField] private GameObject boss;
    GameObject[] Doors;

    public bool Comp = true;//移動完了したかどうか
    bool Can = true;
    //ターン関連
    public static bool isPlayerTurn;
    public bool NotInWatch = true;

    Vector2 pos;

    public bool South, North, West, East;

    bool one = true;
    void Start()
    {
        isPlayerTurn = true;
        animator = player.GetComponent<Animator>();
        pos = transform.localScale;//(1.25, 1.25, 1.25)
        enemys = GameObject.FindGameObjectsWithTag("Enemy");
        Doors = GameObject.FindGameObjectsWithTag("Door");
    }

    // Update is called once per frame
    void Update()
    {
        //ボスがいたら一度だけボスを取得する
        if ((boss = GameObject.Find("BOSS")) && one) { boss = GameObject.Find("BOSS"); one = false; }
        if (!one && !boss.GetComponent<Boss>().playerTurn) return;

        //プレイヤーのターンじゃない場合は動かないようにする
        if (isPlayerTurn && !MotionCheck && NotInWatch)
        {
            if (EventSystem.current.IsPointerOverGameObject()) return;
            if (Input.GetMouseButtonDown(0) && Second == false)  //左クリックでif分起動
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                //RaycastHit2D hit2d = Physics2D.Raycast((Vector2)ray.origin, (Vector2)ray.direction);
                RaycastHit2D hit2d = Physics2D.GetRayIntersection(ray, Mathf.Infinity);
                //デバッグ用のレイの描画
                //Debug.DrawRay(ray.origin, ray.direction * 30, Color.red, 20f);
                if (hit2d)
                {
                    CurrentY = player.transform.position.y;
                    CurrentX = player.transform.position.x;
                    clickedGameObject = hit2d.transform.gameObject;
                    //Debug.Log(clickedGameObject);//ゲームオブジェクトの名前を出力
                    RL = new Vector2(clickedGameObject.transform.position.x, player.transform.position.y);
                    UD = new Vector2(player.transform.position.x, clickedGameObject.transform.position.y);
                    if (clickedGameObject.transform.position == player.transform.position)
                    {
                        clickedGameObject = null;
                        //First = Second = false;
                    }
                    else if (clickedGameObject.CompareTag("switch") && Vector2.Distance(transform.position, clickedGameObject.transform.position) <= 1)
                    {
                        if (clickedGameObject.transform.position.x - transform.position.x > 0 && pos.x > 0)
                        {
                            pos.x *= -1;
                        }
                        if (clickedGameObject.transform.position.x - transform.position.x < 0 && pos.x < 0)
                        {
                            pos.x *= -1;
                        }
                        transform.localScale = pos;
                        Motion();
                        clickedGameObject = null;
                    }
                    else if ((clickedGameObject.CompareTag("Effect") || clickedGameObject.CompareTag("Clock")) && Vector2.Distance(transform.position, clickedGameObject.transform.position) <= 1)
                    {
                        if (clickedGameObject.transform.position.x - transform.position.x > 0 && pos.x > 0)
                        {
                            pos.x *= -1;
                        }
                        if (clickedGameObject.transform.position.x - transform.position.x < 0 && pos.x < 0)
                        {
                            pos.x *= -1;
                        }
                        transform.localScale = pos;
                        Motion();
                        if (clickedGameObject.CompareTag("Clock"))
                        {
                            GetComponent<PocketWatch>().enabled = true;
                        }

                        clickedGameObject.SetActive(false);
                        clickedGameObject = null;
                    }
                    else if ((clickedGameObject.CompareTag("Effect") || clickedGameObject.CompareTag("Message")) && Vector2.Distance(transform.position, clickedGameObject.transform.position) <= 1)
                    {
                        if (clickedGameObject.transform.position.x - transform.position.x > 0 && pos.x > 0)
                        {
                            pos.x *= -1;
                        }
                        if (clickedGameObject.transform.position.x - transform.position.x < 0 && pos.x < 0)
                        {
                            pos.x *= -1;
                        }
                        transform.localScale = pos;
                        Motion();
                        if (clickedGameObject.CompareTag("Message"))
                        {
                            var messageTitle = MessageManager.instance.getTitle();
                            var messageText = MessageManager.instance.getMessage();
                            GameObject.Find("GameManager/PlayerUI/MessagePanel").SetActive(true);
                            GameObject.Find("GameManager/PlayerUI/MessagePanel").GetComponentInChildren<Text>().text = messageTitle + "\n" + messageText;
                            MessageManager.instance.indexplus();
                        }
                        clickedGameObject.SetActive(false);
                        clickedGameObject = null;
                    }
                    else if (Vector2.Distance(player.transform.position, clickedGameObject.transform.position) > 2f || OntheDoor(clickedGameObject) || !clickedGameObject.CompareTag("Tile") || (East && (clickedGameObject.transform.position.x - transform.position.x == 2)) || (West && (clickedGameObject.transform.position.x - transform.position.x == -2)) || (North && (clickedGameObject.transform.position.y - transform.position.y == 2)) || (South && (clickedGameObject.transform.position.y - transform.position.y == -2)))
                    {
                        Debug.Log("移動できません");
                        clickedGameObject = null;
                    }
                    else
                    {
                        if((transform.position.y - clickedGameObject.transform.position.y == 1 && South) || (transform.position.y - clickedGameObject.transform.position.y == -1 && North))
                        {
                            RLfirst = true;
                        }else if(Mathf.Abs(transform.position.x - clickedGameObject.transform.position.x) == 1 && (East || West))
                        {
                            RLfirst = false;
                        }
                        Comp = false;
                        First = Second = true;
                        currentPos = player.transform.position;
                        ismove = true;
                        animator.SetBool("isRunning", true);
                        South = North = West = East = false;
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
        if (clickedGameObject && RLfirst)//横に移動→縦に移動
        {
            //RL = new Vector2(clickedGameObject.transform.position.x, player.transform.position.y);
            if (clickedGameObject.transform.position.x != player.transform.position.x && First)
            {
                player.transform.position = Vector2.MoveTowards(player.transform.position, RL, speed * Time.deltaTime);
                if (player.transform.position.x > CurrentX)
                {
                    if (Mathf.Abs(player.transform.position.x - CurrentX) / 1 >= 1)
                    {
                        playerwalkcount++;
                        CurrentX = Mathf.Floor(player.transform.position.x);
                    }
                }
                else if (player.transform.position.x < CurrentX)
                {
                    if (Mathf.Abs(CurrentX - player.transform.position.x) / 1 >= 1)
                    {
                        playerwalkcount++;
                        CurrentX = Mathf.Ceil(player.transform.position.x);
                    }
                }
                if (clickedGameObject.transform.position.x == player.transform.position.x)
                {
                    First = false;
                }
            }
            else
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
                    Comp = true;
                    PocketWatch.SameTime = false;
                    isPlayerTurn = false;
                    ismove = false;
                    Can = true;
                    animator.SetBool("isRunning", false);
                    //CanMoveMas.instance.CanMove();
                    
                    if (EnemyMove.Deathcount == 1)
                    {
                        EnemyMove.Deathcount = 2;
                    }
                    else
                    {
                        enemys = GameObject.FindGameObjectsWithTag("Enemy");
                        boss = GameObject.Find("BOSS");
                        if (enemys.Length != 0 || boss != null)
                        {
                            if(enemys.Length != 0){
                                EnemyMove.IsEnemyMove = true;
                                RoundController.instance.EnemyTurn();
                            }
                            if(boss != null){
                                boss.GetComponent<Boss>().isTurn = true;
                                boss.GetComponent<Boss>().playerTurn = false;
                                RoundController.instance.BossTurn();
                            }
                            RoundController.instance.MasRiset();
                            South = North = West = East = false;
                        }
                        else
                        {
                            RoundController.instance.MasRiset();
                            South = North = West = East = false;
                            //isPlayerTurn = true;
                        }
                    }
                    clickedGameObject = null;

                }
            }
        }
        else if(clickedGameObject && !RLfirst)//縦に移動→横に移動
        {
            if (clickedGameObject.transform.position.y != player.transform.position.y && First)
            {

                player.transform.position = Vector2.MoveTowards(player.transform.position, UD, speed * Time.deltaTime);
                /*if (player.transform.position.y > CurrentY)
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
                }*/
                if (clickedGameObject.transform.position.y == player.transform.position.y)
                {
                    First = false;
                }
            }
            else
            {
                RL = new Vector2(clickedGameObject.transform.position.x, player.transform.position.y);
                player.transform.position = Vector2.MoveTowards(player.transform.position, RL, speed * Time.deltaTime);
                /*if (player.transform.position.x > CurrentX)
                {
                    if (Mathf.Abs(player.transform.position.x - CurrentX) / 1 >= 1)
                    {
                        playerwalkcount++;
                        CurrentX = Mathf.Floor(player.transform.position.x);
                    }
                }
                else if (player.transform.position.x < CurrentX)
                {
                    if (Mathf.Abs(CurrentX - player.transform.position.x) / 1 >= 1)
                    {
                        playerwalkcount++;
                        CurrentX = Mathf.Ceil(player.transform.position.x);
                    }
                }*/

                if (clickedGameObject.transform.position.x == player.transform.position.x)
                {
                    Second = false;

                    RoundController.instance.SetTurn(RoundController.instance.GetTurn() + 1);
                    Debug.Log("移動完了");
                    
                    Comp = true;
                    RLfirst = true;
                    PocketWatch.SameTime = false;
                    isPlayerTurn = false;
                    ismove = false;
                    Can = true;
                    animator.SetBool("isRunning", false);
                    //CanMoveMas.instance.CanMove();
                    clickedGameObject = null;
                    if (EnemyMove.Deathcount == 1)
                    {
                        EnemyMove.Deathcount = 2;
                    }
                    else
                    {
                        enemys = GameObject.FindGameObjectsWithTag("Enemy");
                        boss = GameObject.Find("BOSS");
                        if (enemys.Length != 0 || boss != null)
                        {
                            if (enemys.Length != 0)
                            {
                                EnemyMove.IsEnemyMove = true;
                                RoundController.instance.EnemyTurn();
                            }
                            if (boss != null)
                            {
                                boss.GetComponent<Boss>().isTurn = true;
                                boss.GetComponent<Boss>().playerTurn = false;
                                RoundController.instance.BossTurn();
                            }
                        }
                        else
                        {
                            RoundController.instance.MasRiset();
                            South = North = West = East = false;
                            //isPlayerTurn = true;
                        }
                    }

                }
            }
        }
    }
    public void Motion()
    {
        if (!MotionCheck)
        {
            MotionCheck = true;
            StartCoroutine(MotionCoolDown());
            animator.SetBool("IsMotion", true);
        }
    }

    IEnumerator MotionCoolDown()
    {
        yield return new WaitForSeconds(0.40f);
        MotionCheck = false;
        animator.SetBool("IsMotion", false);
    }

    /*void OnTriggerStay2D(Collider2D other)
    {
        if (ismove) return;
        if (other.gameObject.CompareTag("OBJ") && !RLfirst)
        {
            Debug.Log("した方向");
            
            RLfirst = true;
        }
    }*/
    bool OntheDoor(GameObject obj)
    {
        foreach(GameObject door in Doors)
        {
            if (obj.transform.position.x == door.transform.position.x && obj.transform.position.y == door.transform.position.y) return true;
        }
        foreach (GameObject door in Doors)
        {
            Vector2 diff = (transform.position + obj.transform.position) / 2;
            if (diff.x == door.transform.position.x && diff.y == door.transform.position.y) return true;
        }
        return false;
    }
}
