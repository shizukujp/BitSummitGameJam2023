using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridFiledManager : MonoBehaviour
{
    [SerializeField] private int _rows, _cols;
    [SerializeField] private GameObject _gridtile;
    void Start()
    {
        MakeGridFiled();
        Transform myTransform = this.transform;
        Vector2 pos = myTransform.position;
        pos.x -= 2f;    // x座標へ0.01加算
        pos.y -= 2.8f;    // y座標へ0.01加算

        myTransform.position = pos;
    }

    private void MakeGridFiled()
    {
        for (int row = 0; row < _rows; row++)
        {
            for (int col = 0; col < _cols; col++)
            {
                _gridtile = Instantiate(_gridtile, new Vector3(row, col * 1.414f), Quaternion.identity, transform);
                if ((row + col) % 2 != 0)
                {
                    _gridtile.GetComponent<SpriteRenderer>().color = Color.black;
                }else
                {
                    _gridtile.GetComponent<SpriteRenderer>().color = Color.white;
                }
            }
        }
    }
}
