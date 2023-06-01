using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChange : MonoBehaviour
{
    public Material MyColor;//一番薄い色
    public Material MyColor2;//2番目に濃い色
    public Material MyColor3;//一番濃い色

    // Start is called before the first frame update
    public bool A = true;
    GameObject player;
    public GameObject Enemy;
    public static ColorChange instance;
    public int Arpha = 0;
    public void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    void Start()
    {
        player = Player.instance.player;
        CanPlayerMove();
        if (0 <= (Enemy.transform.position.y - transform.position.y) && (Enemy.transform.position.y - transform.position.y) <= 3)
        {
            if(1 >= (Enemy.transform.position.x - transform.position.x) && (Enemy.transform.position.x - transform.position.x) >= -1)
            {
                this.GetComponent<SpriteRenderer>().color = new Color(1f, 0.667f, 0.667f, 0.475f);
            }
            //Dangermat.color = new Color(255, 167, 167, 121);
        }
    }

    // Update is called once per frame
    void Update()
    {
        //プレイヤーが動いていない間
        if (A && !Player.instance.ismove)
        {
            //Debug.Log("生成");
            CanPlayerMove();
        }
        if(Player.instance.ismove)
        {
            if (Vector2.Distance(player.transform.position, transform.position) < 0.5f)
            {
                GetComponent<Renderer>().material = MyColor3;
            }else if (Vector2.Distance(Player.instance.currentPos, transform.position) <= 2f && Player.instance.clickPos != transform.position)
            {
                GetComponent<Renderer>().material = MyColor2;
            }
        }
        if(EnemyMove.instance.isEneMove)
        {
            DangerColor(EnemyMove.instance.Enem, EnemyMove.instance.Up, EnemyMove.instance.Down, EnemyMove.instance.Right, EnemyMove.instance.Left);
        }
    }

    void OnMouseEnter()
    {
        if(!Player.instance.ismove)
        {
            //プレイヤーが移動可能なマスだったら
            if(Vector2.Distance(player.transform.position, transform.position) / 1f <= 2f)
            {
                GetComponent<Renderer>().material = MyColor3;
            }else//それ以外
            {
                GetComponent<Renderer>().material = MyColor2;
            }
        }
            
    }

    //マウスカーソルを離したとき
    void OnMouseExit()
    {
        if (!Player.instance.ismove)
        {
            //プレイヤーが移動可能な範囲のマスだったら
            if(Vector2.Distance(player.transform.position, transform.position) == 0)
            {
                GetComponent<Renderer>().material = MyColor3;
            }else if (Vector2.Distance(player.transform.position, transform.position) / 1f <= 2f)
            {
                GetComponent<Renderer>().material = MyColor2;
            }else
            {
                GetComponent<Renderer>().material = MyColor;
            }
        }
    }
    //プレイヤーが移動可能なマスを表示する
    public void CanPlayerMove()
    {
        if (Vector2.Distance(player.transform.position, transform.position) == 0)
        {
            GetComponent<Renderer>().material = MyColor3;
        }
        else if (Vector2.Distance(player.transform.position, transform.position) / 1f <= 2f)
        {
            //Debug.Log("移動可能です");
            GetComponent<Renderer>().material = MyColor2;
        }
        else
        {
            GetComponent<Renderer>().material = MyColor;
        }
        A = false;
    }

    public void DangerColor(GameObject enemy, bool up, bool down, bool right, bool left)
    {
        //上に動く場合
        
        if (up)
        {
            if (-0.5f <= (transform.position.y - enemy.transform.position.y) && (transform.position.y - enemy.transform.position.y) <= 3.5f)
            {
                if (-1 <= (enemy.transform.position.x - transform.position.x) && (enemy.transform.position.x - transform.position.x) <= 1)
                {
                    GetComponent<SpriteRenderer>().color = new Color(1f, 0.667f, 0.667f, 0.475f);
                }
            }
            else
            {
                this.GetComponent<SpriteRenderer>().color = new Color(0.943f, 0.943f, 0.943f, 0.475f);
            }

        }
        //下に動く場合
        else if (down)
        {
            //Debug.Log("した");
            if (-0.5f <= (enemy.transform.position.y - transform.position.y) && (enemy.transform.position.y - transform.position.y) <= 3.5f)
            {
                if (1 >= (enemy.transform.position.x - transform.position.x) && (enemy.transform.position.x - transform.position.x) >= -1)
                {
                    this.GetComponent<SpriteRenderer>().color = new Color(1f, 0.667f, 0.667f, 0.475f);
                }
            }
            else
            {
                this.GetComponent<SpriteRenderer>().color = new Color(0.943f, 0.943f, 0.943f, 0.475f);
            }

        }

        //右に動く場合
        if (right)
        {
            if (1 >= (enemy.transform.position.y - transform.position.y) && (enemy.transform.position.y - transform.position.y) >= -1)
            {
                if (0 <= transform.position.x - enemy.transform.position.x && transform.position.x - enemy.transform.position.x <= 3)
                {
                    GetComponent<SpriteRenderer>().color = new Color(1f, 0.667f, 0.667f, 0.475f);
                }
            }else
            {
                this.GetComponent<SpriteRenderer>().color = new Color(0.943f, 0.943f, 0.943f, 0.475f);
            }
        }
        //左に動く場合
        else if (left)
        {
            if (1 >= (enemy.transform.position.y - transform.position.y) && (enemy.transform.position.y - transform.position.y) >= -1)
            {
                if (0 <= (enemy.transform.position.x - transform.position.x) && (enemy.transform.position.x - transform.position.x) <= 3)
                {
                    this.GetComponent<SpriteRenderer>().color = new Color(1f, 0.667f, 0.667f, 0.475f);
                }
            }else
            {
                this.GetComponent<SpriteRenderer>().color = new Color(0.943f, 0.943f, 0.943f, 0.475f);
            }
        }



    }


}
