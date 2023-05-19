using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public GameObject player;   //①移動させたいオブジェクト
    public int speed = 5; //移動スピード
    GameObject clickedGameObject;//クリックされたゲームオブジェクトを代入する変数
    Vector2 RL;//移動する場所のX座標
    Vector2 UD;//移動する場所のY座標
    bool First = false;
    bool Second = false;
    float CurrentY;//現在のプレイヤーのY座標
    float CurrentX;//現在のプレイヤーのX座標

    // Start is called before the first frame update
    public GameObject countText;
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetMouseButtonDown(0) && Second==false)  //左クリックでif分起動
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            //RaycastHit2D hit2d = Physics2D.Raycast((Vector2)ray.origin, (Vector2)ray.direction);
            RaycastHit2D hit2d = Physics2D.GetRayIntersection(ray, Mathf.Infinity);
            Debug.DrawRay(ray.origin, ray.direction * 30, Color.red, 20f);
            if (hit2d)
            {
                Debug.Log(hit2d.transform.position);
                CurrentY = player.transform.position.y;
                CurrentX = player.transform.position.x;
                clickedGameObject = hit2d.transform.gameObject;
                Debug.Log(clickedGameObject);//ゲームオブジェクトの名前を出力
                RL = new Vector2(clickedGameObject.transform.position.x, player.transform.position.y);

                if (clickedGameObject.transform.position==player.transform.position)
                {
                    clickedGameObject = null;
                    First = Second = false;
                }else
                {
                    First = Second = true;
                    clickedGameObject.GetComponent<SpriteRenderer>().color = new Color(255, 0, 0, 255);
                }
            }
        }
      
        if (clickedGameObject)
        {   
            if (clickedGameObject.transform.position.x != player.transform.position.x && First)
            {
                player.transform.position = Vector2.MoveTowards(player.transform.position, RL, speed * Time.deltaTime);
                if(player.transform.position.x > CurrentX)
                {
                    if (Mathf.Abs(player.transform.position.x - CurrentX)/1 >= 1)
                    {
                        countText.GetComponent<Count>().score = countText.GetComponent<Count>().score + 1;
                        CurrentX = Mathf.Floor(player.transform.position.x);
                    }
                }else if(player.transform.position.x < CurrentX)
                {
                    if (Mathf.Abs(CurrentX - player.transform.position.x)/1 >= 1)
                    {
                        countText.GetComponent<Count>().score = countText.GetComponent<Count>().score + 1;
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
                        countText.GetComponent<Count>().score = countText.GetComponent<Count>().score + 1;
                        CurrentY = Mathf.Floor(player.transform.position.y);
                    }
                }
                else if (player.transform.position.y < CurrentY)
                {
                    if (Mathf.Abs(CurrentY - player.transform.position.y) / 1 >= 1)
                    {
                        countText.GetComponent<Count>().score = countText.GetComponent<Count>().score + 1;
                        CurrentY = Mathf.Ceil(player.transform.position.y);
                    }
                }

                if (clickedGameObject.transform.position.y == player.transform.position.y)
                {
                    Second = false;
                    clickedGameObject = null;
                    Debug.Log("移動完了");
                }
            }
        }
    }
}
