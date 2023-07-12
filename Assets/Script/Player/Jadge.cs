using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jadge : MonoBehaviour
{
    public bool South, North, West, East;
    GameObject player;

    private void Start()
    {
        player = GameObject.FindWithTag("Player");
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        //if (Player.instance.ismove) return;
        if(other.gameObject.CompareTag("OBJ") || other.gameObject.CompareTag("switch") || other.gameObject.CompareTag("Door"))
        {
            if (South && !player.GetComponent<Player>().South)
            {
                Player.instance.South = true;
                return;
            }
            if (North && !player.GetComponent<Player>().North)
            {
                Player.instance.North = true;
                return;
            }
            if (East && !player.GetComponent<Player>().East)
            {
                Player.instance.East = true;
                return;
            }
            if (West && !player.GetComponent<Player>().West)
            {
                Player.instance.West = true;
                return;
            }
        }
        //if (Player.instance.ismove) return;
        /*if ((Player.instance.East || Player.instance.West) && Player.instance.RLfirst)
        {
            Player.instance.RLfirst = false;
        }*/
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("OBJ") || other.gameObject.CompareTag("switch") || other.gameObject.CompareTag("Door"))
        {
                Player.instance.South = false;
            
                Player.instance.North = false;

                Player.instance.East = false;
      
                Player.instance.West = false;
            
        }
        
    }
}
