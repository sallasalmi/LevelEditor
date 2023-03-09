using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Tile
{
    Rect rect;
    public GUIStyle guistyle;

    public Tile(Vector2 position, float width, float hight, GUIStyle defaultstyle)
    {
        rect = new Rect(position.x, position.y, width, hight);
        guistyle = defaultstyle;
    }

    public void Draw()
    {
        GUI.Box(rect, "", guistyle);
    }

    public void SetStyle(GUIStyle Tilestyle)
    {
        guistyle = Tilestyle;
    }
}
