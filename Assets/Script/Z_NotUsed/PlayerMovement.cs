using UnityEngine;
using System.Collections;
using static UnityEngine.GraphicsBuffer;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    [Tooltip("追従させたいターゲット")]
    private GameObject target;

    private Vector3 offset;
    void Start()
    {
        offset = gameObject.transform.position - target.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.position = target.transform.position + offset;

        /*if (input != Vector2.zero)
        {
            animator.SetBool("isMoving", true);
            stopX = inputX;
            stopY = inputY;
        }
        else
        {
            animator.SetBool("isMoving", false);
        }
        animator.SetFloat("InputX", stopX);
        animator.SetFloat("InputY", stopY);*/

    }
}
