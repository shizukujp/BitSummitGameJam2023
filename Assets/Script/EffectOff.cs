using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectOff : MonoBehaviour
{
    public GameObject clock;
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        clock.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnMouseOver()
    {
        //Debug.Log("これはアイテムです");
        if (Input.GetMouseButtonDown(0) && player.transform.position.x == 8 && player.transform.position.y == 5)
        {
            clock.SetActive(true);
            //this.gameObject.SetActive(false);

        }
        GetComponent<SpriteRenderer>().color = new Color(1f, 0.2f, 0.2f, 1f);
    }
    /*private void OnMouseExit()
    {
        GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 1f);
    }*/

}
