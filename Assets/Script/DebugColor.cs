using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugColor : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(GetComponent<SpriteRenderer>().color);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
