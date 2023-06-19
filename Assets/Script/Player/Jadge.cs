using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jadge : MonoBehaviour
{
    public bool South, North, West, East;


    private void OnTriggerStay2D(Collider2D other)
    {
        //if (Player.instance.ismove) return;
        if(other.gameObject.CompareTag("OBJ") || other.gameObject.CompareTag("switch"))
        {
            if (South && !Player.instance.South)
            {
                Player.instance.South = true;
                return;
            }
            if (North && !Player.instance.North)
            {
                Player.instance.North = true;
                return;
            }
            if ((East && !Player.instance.East && Player.instance.player.transform.localScale.x == 1.25) || (West && Player.instance.player.transform.localScale.x == -1.25 && !Player.instance.West))
            {
                Player.instance.East = true;
                return;
            }
            if ((West && !Player.instance.West && Player.instance.player.transform.localScale.x == 1.25) || (East && Player.instance.player.transform.localScale.x == -1.25 && !Player.instance.East))
            {
                Player.instance.West = true;
                return;
            }
        }
        if (Player.instance.ismove) return;
        if ((Player.instance.East || Player.instance.West) && !Player.instance.RLfirst)
        {
            Player.instance.RLfirst = true;
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("OBJ"))
        {
                Player.instance.South = false;
            
                Player.instance.North = false;

                Player.instance.East = false;
      
                Player.instance.West = false;
            
        }
        
    }
}
