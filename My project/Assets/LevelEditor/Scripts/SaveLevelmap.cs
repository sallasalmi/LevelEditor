using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SaveLevelmap
{
    public int row, col;
    public int val;

    public SaveLevelmap(int Row, int Col, int Val)
    {
        row = Row;
        col = Col;
        val = Val;
    }

    public void SetVal(int Val)
    {
        val = Val;
    }

}
