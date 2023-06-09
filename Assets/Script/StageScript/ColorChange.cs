using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChange : MonoBehaviour
{
    public bool isAttack;
    public bool A = true;
    GameObject player;
    //public GameObject[] Enemy;
    public static ColorChange instance;
    //

    [SerializeField] public bool _isDanger;
    public bool ColorChangeOn = true;
    public void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    void Start()
    {
        player = GameObject.FindWithTag("Player");

        if(CanPlayerMoveColor())
        {
            GetComponent<SpriteRenderer>().color = new Color(0.566f, 0.556f, 0.556f, 0.475f);
        }
        if(isDanger())
        {
            this.GetComponent<SpriteRenderer>().color = new Color(1f, 0.667f, 0.667f, 0.475f);
        }
        //Enemy = GameObject.FindGameObjectsWithTag("Enemy");
    }

    // Update is called once per frame
    void Update()
    {
        _isDanger = isDanger();
        //敵が動いている時
        //if (Player.instance.enemys.Length != 0) RisetColor();
        if(Player.instance.enemys.Length != 0)
        {
            if (!ColorChangeOn) return;
            if (EnemyMove.instance.isEneMove && !RoundController.OnOff_Enemy)
            {
                if (!_isDanger)
                {
                    CanPlayerMove();
                    return;
                }

                if (CanPlayerMoveColor())
                {
                    GetComponent<SpriteRenderer>().color = new Color(1f, 0.2f, 0.2f, 0.475f);
                    return;
                }
                GetComponent<SpriteRenderer>().color = new Color(1f, 0.667f, 0.667f, 0.475f);
                //DangerColor(EnemyMove.instance.Enem, EnemyMove.instance.Up, EnemyMove.instance.Down, EnemyMove.instance.Right, EnemyMove.instance.Left);
            }
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
        _isDanger = isDanger();
        if (!ColorChangeOn) return;
        if (!Player.isPlayerTurn) return;
        if (Player.instance.ismove) return;
            //プレイヤーが移動可能なマスだったら
        
        if (CanPlayerMoveColor())
        {
            if (_isDanger || isAttack)
            {
                //さらに危険な色
                if (EnemyMove.Deathcount == 0)
                {
                    GetComponent<SpriteRenderer>().color = new Color(1f, 0.1f, 0.1f, 0.475f);
                    return;
                }
            }
            //濃い鼠色
            GetComponent<SpriteRenderer>().color = new Color(0.157f, 0.157f, 0.157f, 0.475f);
        }
        else//それ以外
        {
            if (_isDanger || isAttack)
            {
                //危険な色
                if (EnemyMove.Deathcount == 0)
                {
                    GetComponent<SpriteRenderer>().color = new Color(1f, 0.2f, 0.2f, 0.475f);
                    return;
                }
            }
            //薄い鼠色
            GetComponent<SpriteRenderer>().color = new Color(0.566f, 0.556f, 0.556f, 0.475f);
        }
    }


    //マウスカーソルを離したとき
    void OnMouseExit()
    {
        _isDanger = isDanger();
        if (!Player.isPlayerTurn) return;
        if (Player.instance.ismove) return;
        if (!ColorChangeOn) return;
        //プレイヤーが移動可能な範囲のマスだったら
        /*if (Vector2.Distance(player.transform.position, transform.position) == 0)
        {
            //プレイヤーの上
            GetComponent<SpriteRenderer>().color = new Color(0.157f, 0.157f, 0.157f, 0.475f);
        }*/
        else if (CanPlayerMoveColor())
        {
            if(_isDanger || isAttack)
            {
                if (EnemyMove.Deathcount == 0)
                {
                    //2番目に危険な色
                    GetComponent<SpriteRenderer>().color = new Color(1f, 0.2f, 0.2f, 0.475f);
                    return;
                }
            }
            //プレイヤーの周囲
            GetComponent<SpriteRenderer>().color = new Color(0.566f, 0.556f, 0.556f, 0.475f);
        }
        else
        {
            if ((_isDanger || isAttack) && EnemyMove.Deathcount == 0)
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
        _isDanger = isDanger();
        if (CanPlayerMoveColor()/*Vector2.Distance(player.transform.position, transform.position) <= 2f*/)
        {
            //Debug.Log("移動可能です");
            if (_isDanger || isAttack)
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

    bool IsDangerColor(GameObject enemy, bool up, bool down, bool right, bool left)
    {
        //上に動く場合
        if (up)
        {
            if (-0.5f <= (transform.position.y - enemy.transform.position.y) && (transform.position.y - enemy.transform.position.y) <= 3.5f)
            {
                if (-1 <= (enemy.transform.position.x - transform.position.x) && (enemy.transform.position.x - transform.position.x) <= 1)
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
            if (-0.5f <= (enemy.transform.position.y - transform.position.y) && (enemy.transform.position.y - transform.position.y) <= 3.5f)
            {
                if (1 >= (enemy.transform.position.x - transform.position.x) && (enemy.transform.position.x - transform.position.x) >= -1)
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
            if (-0.5 <= (transform.position.x - enemy.transform.position.x) && (transform.position.x - enemy.transform.position.x) <= 3.5f)
            {
                if (-1 <= transform.position.y - enemy.transform.position.y && transform.position.y - enemy.transform.position.y <= 1)
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
            if (-0.5 <= (enemy.transform.position.x - transform.position.x) && (enemy.transform.position.x - transform.position.x) <= 3.5f)
            {
                if (-1 <= transform.position.y - enemy.transform.position.y && transform.position.y - enemy.transform.position.y <= 1)
                {
                    //this.GetComponent<SpriteRenderer>().color = new Color(1f, 0.667f, 0.667f, 0.475f);
                    return true;
                }
                return false;
            }
            return false;
        }
        return false;
    }
    public bool isDanger()
    {
        if (RoundController.OnOff_Enemy) return false;
        GameObject[] Enemys = GameObject.FindGameObjectsWithTag("Enemy");
        for(int i = 0; i < Enemys.Length; i++)
        {
            EnemyMove enemy =  Enemys[i].GetComponent<EnemyMove>();
            if (enemy.isAlerm) return false;
            if (IsDangerColor(Enemys[i], enemy.Up, enemy.Down, enemy.Right, enemy.Left)) return true;
        }
        return false;
    }


    public bool CanPlayerMoveColor()
    {
        if (RoundController.OnOff_Player) return false;
        if (Vector2.Distance(player.transform.position, transform.position) > 2f) return false;
        if (transform.position.x - player.transform.position.x == 2 && Player.instance.East) return false;
        if (transform.position.x - player.transform.position.x == -2 && Player.instance.West) return false;
        if (transform.position.y - player.transform.position.y == 2 && Player.instance.North) return false;
        if (transform.position.y - player.transform.position.y == -2 && Player.instance.South) return false;
        if (!ColorChangeOn) return false;
        return true;
    }

    public void RisetColor()
    {
        _isDanger = isDanger();
        if(!ColorChangeOn) return;
        if ((_isDanger || isAttack) && CanPlayerMoveColor())
        {
            GetComponent<SpriteRenderer>().color = new Color(1f, 0.2f, 0.2f, 0.475f);
        }else if(_isDanger || isAttack)
        {
            this.GetComponent<SpriteRenderer>().color = new Color(1f, 0.667f, 0.667f, 0.475f);
        }else if(CanPlayerMoveColor())
        {
            GetComponent<SpriteRenderer>().color = new Color(0.566f, 0.556f, 0.556f, 0.475f);
        }else
        {
            GetComponent<SpriteRenderer>().color = new Color(0.943f, 0.943f, 0.943f, 0.475f);
        }
    }
}
