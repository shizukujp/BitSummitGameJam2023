using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameObject player;   //①移動させたいオブジェクト
    Vector3 touchWorldPosition;　//②マウスでタッチした箇所の座標を取得
    public int speed = 5;
    GameObject clickedGameObject;//クリックされたゲームオブジェクトを代入する変数

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))  //左クリックでif分起動
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit2D hit2d = Physics2D.Raycast((Vector2)ray.origin, (Vector2)ray.direction);
            //Vector3 touchScreenPosition = Input.mousePosition;  //②マウスでタッチした座標をtouchScreenPositionに。
            //touchScreenPosition.z = 5.0f;  //②奥行を手前に来るように5.0fを指定。
            //Camera camera = Camera.main;  //②
            //touchWorldPosition = camera.ScreenToWorldPoint(touchScreenPosition);  //②
            if (hit2d)
            {
                clickedGameObject = hit2d.transform.gameObject;
                Debug.Log(clickedGameObject);//ゲームオブジェクトの名前を出力
            }
        }
        if(clickedGameObject)
            player.transform.position = Vector2.MoveTowards(player.transform.position, clickedGameObject.transform.position, speed * Time.deltaTime); //playerオブジェクトが, 目的地に移動, 移動速度
    }
}
