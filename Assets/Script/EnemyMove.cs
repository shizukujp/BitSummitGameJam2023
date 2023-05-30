using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    Animator animator;
    public float speed = 1f;
    Vector2 vct1;
    Vector2 vct2;
    // Start is called before the first frame update
    void Start()
    {
        vct1 = new Vector2(transform.position.x, transform.position.y);
        vct1 = new Vector2(5f, 0f);
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
    }

    void Move()
    {
        //if(transform.position.y > 0)
        //Vector2 MovePos = new Vector2(transform.position.x, transform.position.y);
        //transform.position = Vector2.MoveTowards(transform.position, MovePos, speed * Time.deltaTime);
    }
}
