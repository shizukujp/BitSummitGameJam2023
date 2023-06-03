using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChange : MonoBehaviour
{
    //public Material MyColor;//一番薄い色
    //public Material MyColor2;//2番目に濃い色
    //public Material MyColor3;//一番濃い色

    // Start is called before the first frame update
    public bool A = true;
    GameObject player;
    public GameObject Enemy;
    public static ColorChange instance;
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
        //CanPlayerMove();
        if (Vector2.Distance(player.transform.position, transform.position) == 0)
        {
            GetComponent<SpriteRenderer>().color = new Color(0.157f, 0.157f, 0.157f, 0.475f);
        }else if (Vector2.Distance(player.transform.position, transform.position) <= 2f)
        {
            GetComponent<SpriteRenderer>().color = new Color(0.566f, 0.556f, 0.556f, 0.475f);
        }
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
            //CanPlayerMove();
        }
        if(Player.instance.ismove)
        {
            if (Vector2.Distance(player.transform.position, transform.position) < 0.5f)
            {
                if(isDanger())
                {
                    //最も危険
                    GetComponent<SpriteRenderer>().color = new Color(1f, 0.1f, 0.1f, 0.475f);
                    return;
                }
                GetComponent<SpriteRenderer>().color = new Color(0.157f, 0.157f, 0.157f, 0.475f);
            }
            else if (Vector2.Distance(Player.instance.currentPos, transform.position) <= 2f && Player.instance.clickPos != transform.position)
            {
                if(isDanger())
                {
                    //危険な色
                    GetComponent<SpriteRenderer>().color = new Color(1f, 0.2f, 0.2f, 0.475f);
                    return;
                }
                GetComponent<SpriteRenderer>().color = new Color(0.566f, 0.556f, 0.556f, 0.475f);
            }
        }

        if(EnemyMove.instance.isEneMove || EnemyMove.instance.Deathcount == 1)
        {
            if (!isDanger())
            {
                CanPlayerMove();
                return;
            }
            if (Vector2.Distance(player.transform.position, transform.position) < 0.5f)
            {
                //最も危険
                GetComponent<SpriteRenderer>().color = new Color(1f, 0.1f, 0.1f, 0.475f);
                return;
            }
            else if (CanPlayerMoveColor())
            {
                GetComponent<SpriteRenderer>().color = new Color(1f, 0.2f, 0.2f, 0.475f);
                return;
            }
            GetComponent<SpriteRenderer>().color = new Color(1f, 0.667f, 0.667f, 0.475f);
            //DangerColor(EnemyMove.instance.Enem, EnemyMove.instance.Up, EnemyMove.instance.Down, EnemyMove.instance.Right, EnemyMove.instance.Left);
        }
    }

    /*void OnMouseEnter()
    {
        if(!Player.instance.ismove)
        {
            //プレイヤーが移動可能なマスだったら
            if(Vector2.Distance(player.transform.position, transform.position) / 1f <= 2f)
            {
                //濃い鼠色
                GetComponent<SpriteRenderer>().color = new Color(0.157f, 0.157f, 0.157f, 0.475f);
            }
            else//それ以外
            {
                if(GetComponent<SpriteRenderer>().color == new Color(1f, 0.667f, 0.667f, 0.475f))
                {
                    //危険な色
                    GetComponent<SpriteRenderer>().color = new Color(1f, 0.2f, 0.2f, 0.475f);
                }else
                {
                    //薄い鼠色
                    GetComponent<SpriteRenderer>().color = new Color(0.566f, 0.556f, 0.556f, 0.475f);
                }
            }
        }    
    }*/
    void OnMouseOver()
    {
        if (!Player.instance.isPlayerTurn) return;
        if (Player.instance.ismove) return;
            //プレイヤーが移動可能なマスだったら
        
        if (CanPlayerMoveColor())
        {
            if (isDanger())
            {
                //さらに危険な色
                GetComponent<SpriteRenderer>().color = new Color(1f, 0.1f, 0.1f, 0.475f);
                return;
            }
            //濃い鼠色
            GetComponent<SpriteRenderer>().color = new Color(0.157f, 0.157f, 0.157f, 0.475f);
        }
        else//それ以外
        {
            if (isDanger())
            {
                //危険な色
                GetComponent<SpriteRenderer>().color = new Color(1f, 0.2f, 0.2f, 0.475f);
                return;
            }
            //薄い鼠色
            GetComponent<SpriteRenderer>().color = new Color(0.566f, 0.556f, 0.556f, 0.475f);
        }
    }


    //マウスカーソルを離したとき
    void OnMouseExit()
    {
        if (!Player.instance.isPlayerTurn) return;
        if (Player.instance.ismove) return;
        //プレイヤーが移動可能な範囲のマスだったら
        if (Vector2.Distance(player.transform.position, transform.position) == 0)
        {
            //プレイヤーの上
            GetComponent<SpriteRenderer>().color = new Color(0.157f, 0.157f, 0.157f, 0.475f);
        }
        else if (CanPlayerMoveColor())
        {
            if(isDanger())
            {
                //2番目に危険な色
                GetComponent<SpriteRenderer>().color = new Color(1f, 0.2f, 0.2f, 0.475f);
                return;
            }
            //プレイヤーの周囲
            GetComponent<SpriteRenderer>().color = new Color(0.566f, 0.556f, 0.556f, 0.475f);
        }
        else
        {
            if (isDanger())
            {
                //危険な色
                GetComponent<SpriteRenderer>().color = new Color(1f, 0.667f, 0.667f, 0.475f);
            }
            else
            {
                //それ以外
                GetComponent<SpriteRenderer>().color = new Color(0.943f, 0.943f, 0.943f, 0.475f);
            }
        }
    }

    //プレイヤーが移動可能なマスを表示する
    public void CanPlayerMove()
    {
        if (Vector2.Distance(player.transform.position, transform.position) == 0)
        {
            if(isDanger())
            {
                //さらに危険な色
                GetComponent<SpriteRenderer>().color = new Color(1f, 0.1f, 0.1f, 0.475f);
                return;
            }
            GetComponent<SpriteRenderer>().color = new Color(0.157f, 0.157f, 0.157f, 0.475f);
        }
        else if (Vector2.Distance(player.transform.position, transform.position) <= 2f)
        {
            //Debug.Log("移動可能です");
            if (isDanger())
            {
                //危険な色
                GetComponent<SpriteRenderer>().color = new Color(1f, 0.2f, 0.2f, 0.475f);
                return;
            }
            GetComponent<SpriteRenderer>().color = new Color(0.566f, 0.556f, 0.556f, 0.475f);
        }
        else
        {
            GetComponent<SpriteRenderer>().color = new Color(0.943f, 0.943f, 0.943f, 0.475f);
        }
        A = false;
    }


    /*public void DangerColor(GameObject enemy, bool up, bool down, bool right, bool left)
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
                if (Vector2.Distance(player.transform.position, transform.position) == 0)
                {
                    GetComponent<SpriteRenderer>().color = new Color(0.157f, 0.157f, 0.157f, 0.475f);
                }
                else if (Vector2.Distance(player.transform.position, transform.position) <= 2f)
                {
                    //Debug.Log("移動可能です");
                    GetComponent<SpriteRenderer>().color = new Color(0.566f, 0.556f, 0.556f, 0.475f);
                }
                else
                {
                    GetComponent<SpriteRenderer>().color = new Color(0.943f, 0.943f, 0.943f, 0.475f);
                }
            }

        }
        //下に動く場合
        if (down)
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
                if (Vector2.Distance(player.transform.position, transform.position) == 0)
                {
                    GetComponent<SpriteRenderer>().color = new Color(0.157f, 0.157f, 0.157f, 0.475f);
                }
                else if (Vector2.Distance(player.transform.position, transform.position) <= 2f)
                {
                    //Debug.Log("移動可能です");
                    GetComponent<SpriteRenderer>().color = new Color(0.566f, 0.556f, 0.556f, 0.475f);
                }
                else
                {
                    GetComponent<SpriteRenderer>().color = new Color(0.943f, 0.943f, 0.943f, 0.475f);
                }
            }

        }

        //右に動く場合
        if(right)
        {
            if (-0.5f >= (enemy.transform.position.x - transform.position.x) && (enemy.transform.position.x - transform.position.x) <= 3.5f)
            {
                if (-1 <= enemy.transform.position.y - transform.position.y && enemy.transform.position.y - transform.position.y <= 1)
                {
                    GetComponent<SpriteRenderer>().color = new Color(1f, 0.667f, 0.667f, 0.475f);
                }
            }else
            {
                this.GetComponent<SpriteRenderer>().color = new Color(0.943f, 0.943f, 0.943f, 0.475f);
            }
        }
        //左に動く場合
        if (left)
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
    }*/

    bool IsDangerColor(GameObject[] enemy, bool up, bool down, bool right, bool left)
    {
        //上に動く場合
        for(int a = 0; a < enemy.Length; a++)
        {
            if (up)
            {
                if (-0.5f <= (transform.position.y - enemy[a].transform.position.y) && (transform.position.y - enemy[a].transform.position.y) <= 3.5f)
                {
                    if (-1 <= (enemy[a].transform.position.x - transform.position.x) && (enemy[a].transform.position.x - transform.position.x) <= 1)
                    {
                        //GetComponent<SpriteRenderer>().color = new Color(1f, 0.667f, 0.667f, 0.475f);
                        return true;
                    }
                    return false;
                }
                return false;
            }
            //下に動く場合
            if (down)
            {
                //Debug.Log("した");
                if (-0.5f <= (enemy[a].transform.position.y - transform.position.y) && (enemy[a].transform.position.y - transform.position.y) <= 3.5f)
                {
                    if (1 >= (enemy[a].transform.position.x - transform.position.x) && (enemy[a].transform.position.x - transform.position.x) >= -1)
                    {
                        //this.GetComponent<SpriteRenderer>().color = new Color(1f, 0.667f, 0.667f, 0.475f);
                        return true;
                    }
                    return false;
                }
                return false;
            }

            //右に動く場合
            if (right)
            {
                if (-0.5 <= (transform.position.x - enemy[a].transform.position.x) && (transform.position.x - enemy[a].transform.position.x) <= 3.5f)
                {
                    if (-1 <= transform.position.y - enemy[a].transform.position.y && transform.position.y - enemy[a].transform.position.y <= 1)
                    {
                        //GetComponent<SpriteRenderer>().color = new Color(1f, 0.667f, 0.667f, 0.475f);
                        return true;
                    }
                    return false;
                }
                return false;
            }
            //左に動く場合
            if (left)
            {
                if (-0.5 <= (enemy[a].transform.position.x - transform.position.x) && (enemy[a].transform.position.x - transform.position.x) <= 3.5f)
                {
                    if (-1 <= transform.position.y - enemy[a].transform.position.y && transform.position.y - enemy[a].transform.position.y <= 1)
                    {
                        //this.GetComponent<SpriteRenderer>().color = new Color(1f, 0.667f, 0.667f, 0.475f);
                        return true;
                    }
                    return false;
                }
                return false;
            }
        }
        return false;
    }
    public bool isDanger()
    {
        if (IsDangerColor(GameObject.FindGameObjectsWithTag("Enemy"), EnemyMove.instance.Up, EnemyMove.instance.Down, EnemyMove.instance.Right, EnemyMove.instance.Left)) return true ;
        return false;
    }


    bool CanPlayerMoveColor()
    {
        if (Vector2.Distance(player.transform.position, transform.position) > 2f) return false;
        return true;
    }

}
