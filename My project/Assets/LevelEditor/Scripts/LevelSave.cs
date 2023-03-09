using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class LevelSave 
{
    public double bnc;
    public int colors;
    public List<List<int>> layout;
    public string name;
    public int sink;
    public int[] style;

    public LevelSave(double Bnc, int Color, List<List<int>> Layout, string Name, int Sink, int[] Style)
    {
        bnc = Bnc;
        colors = Color;
        layout = Layout;
        name = Name;
        sink = Sink;
        style = Style;
    }
}
