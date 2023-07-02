using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GUIOption : MonoBehaviour
{
    public static GUIOption Instance;
    [SerializeField]
    GUIOptionFade guiOptionFade;

    private void Awake()
    {
        if(Instance == null)
        {
            DontDestroyOnLoad(this);
            Instance = this;
        }
        else
        {
            Destroy(this);
        }
    }

    public GUIOptionFade GetGUIOptionFade()
    {
        return guiOptionFade;
    }
}
