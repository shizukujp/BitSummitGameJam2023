using UnityEngine;

public class FacingCamera : MonoBehaviour
{
    public Transform[] childs;
    int childCount;
    // Start is called before the first frame update
    void Start()
    {
        childCount = transform.childCount;
        ChildSearch();
    }

    // Update is called once per frame
    void Update()
    {
        if(childCount != transform.childCount) ChildSearch();
        for (int i = 0; i < childs.Length; i++)
        {
            childs[i].rotation = Camera.main.transform.rotation;
        }
    }

    void ChildSearch()
    {
        childs = new Transform[transform.childCount];
        for (int i = 0; i < transform.childCount; i++)
        {
            childs[i] = transform.GetChild(i);
        }
    }
}
