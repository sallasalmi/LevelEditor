using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileManager : MonoBehaviour
{
    public ButtonStyle[] buttonstyles;

}
[System.Serializable]
public struct ButtonStyle
{
    public Texture2D Icon;
    public string ButtonTex;
    [HideInInspector]
    public GUIStyle TileStyle;
}
