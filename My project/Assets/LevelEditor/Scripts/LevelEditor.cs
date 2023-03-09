using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEditor.Callbacks;
using UnityEngine;

public class AssetHandler
{
    [OnOpenAsset()]
    public static bool OpenEditor(int id, int line)
    {
        Level levelSet = EditorUtility.InstanceIDToObject(id) as Level;
        if (levelSet != null)
        {
            LevelEditor.Open(levelSet);
            return true;
        }
        return false;
    }
}

[CustomEditor(typeof(Level))]
public class LevelEditor : EditorWindow
{
    public List<SaveLevelmap> savelevel;
    List<List<Tile>> tiles;
    List<List<int>> layoutList;
    Level level;
    GUIStyle empty;
    Vector2 tilePos;
    Vector2 offset;
    bool earse;
    TileManager tilemanager;
    Rect Menubar;
    float oddRow = 0.85f;
    int xPos;
    int apindex;
    int count = 0;
    private GUIStyle currentStyle;

    public static void Open(Level levelSet)
    {
        LevelEditor window = EditorWindow.GetWindow<LevelEditor>("LevelMap Editor");
        window.setLevelset(levelSet);
    }

    public void setLevelset(Level levelset)
    {
        level = levelset;
    }

    private void OnEnable()
    {
        SetupStyles();
        empty = new GUIStyle();
        Texture2D icon = Resources.Load("LevelEditor/Emptyspot") as Texture2D;
        empty.normal.background = icon;
        SetUpNodes();
    }

   

    private void SetupStyles()
    {
        try
        {
            tilemanager = GameObject.FindGameObjectWithTag("TileManager").GetComponent<TileManager>();
            for (int i = 0; i < tilemanager.buttonstyles.Length; i++)
            {
                tilemanager.buttonstyles[i].TileStyle = new GUIStyle();
                tilemanager.buttonstyles[i].TileStyle.normal.background = tilemanager.buttonstyles[i].Icon;
            }
        }
        catch (Exception e) { }
    }
    private void SetUpNodes()
        {
            tiles = new List<List<Tile>>();
            for (int i = 0; i < 13; i++)
            {
                tiles.Add(new List<Tile>());

                for (int j = 0; j < 13; j++)
                {
                    if (j % 2 == 1)
                    {
                        tilePos.Set(i * 35 + 17, j * 35 * oddRow);

                    }
                    else
                    {
                        tilePos.Set(i * 35, j * 35 * oddRow);
                    }
                    tiles[i].Add(new Tile(tilePos, 42, 42, empty));
                }
            }
        }

    private void OnGUI()
    {
        DrawList();
        SavedNodes();
        DrawGrid();
        DrawNodes();
        DrawMenubar();
        ProcessNodes(Event.current);
        SetlayoutList();
        if (GUI.changed)
        {
            count++;
            Repaint();
            
        }
    }
    private void DrawList()
    {
        if(File.Exists(Application.dataPath + "/" + level.name + ".text"))
        {
            GetLevels();
        } 
        else
        {
            SetUpList();
        }
    }
    public void GetLevels()
    {
        if (count == 0 && File.Exists(Application.dataPath + "/" + level.name + ".text"))
        {
            string json = File.ReadAllText(Application.dataPath + "/" + level.name + ".text");
            savelevel = JsonConvert.DeserializeObject<List<SaveLevelmap>>(json);
        }
    }
    public void SetUpList()
    {
        if (count == 0)
        {
            savelevel = new List<SaveLevelmap>();
            for (int i = 4; i < 13; i++)
            {
                for (int j = 0; j < 10; j++)
                {

                    if (j % 2 == 0 && i < 13)
                    {
                        savelevel.Add(new SaveLevelmap(i, j, 0));
                    }
                    else if (j % 2 == 1 && i < 12)
                    {
                        savelevel.Add(new SaveLevelmap(i, j, 0));
                    }
                    else
                    {
                        savelevel.Add(new SaveLevelmap(i, j, 0));
                    }
                }
            }
        }
    }

    private void SavedNodes()
    {
        if (count == 0)
        {
            for (int i = 0; i < savelevel.Count; i++)
            {
                int ii = savelevel[i].row;
                int jj = savelevel[i].col;
                int val = savelevel[i].val;
                tiles[ii][jj].SetStyle(tilemanager.buttonstyles[val].TileStyle);

            }
        }
    }

    private void DrawMenubar()
    {
        Menubar = new Rect(0, 340, position.width, 300);
        GUILayout.BeginArea(Menubar, EditorStyles.toolbar);
        GUILayout.BeginHorizontal();

        for (int i = 0; i < tilemanager.buttonstyles.Length; i++)
        {
            if (GUILayout.Toggle((currentStyle == tilemanager.buttonstyles[i].TileStyle), new GUIContent(tilemanager.buttonstyles[i].ButtonTex), EditorStyles.toolbarButton, GUILayout.Width(80)))
            {
                currentStyle = tilemanager.buttonstyles[i].TileStyle;
            }
        }
        GUILayout.EndHorizontal();
        GUILayout.EndArea();
    }

    public void ProcessNodes(Event e)
    {
        int Col = (int)((e.mousePosition.y) / (35 * oddRow));

        if (Col % 2 == 1)
        {
            xPos = 17;
        }
        else
        {
            xPos = 0;
        }

        int Row = (int)((e.mousePosition.x - xPos) / 35);
        apindex = (Row - 4) * 10 + Col;

        if (e.type == EventType.MouseDown)
        {
            if (tiles[Row][Col].guistyle.normal.background.name == "Emptyspot")
            {
                earse = false;
            }
            else
            {
                earse = true;
            }
            if (earse == true)
            {
                tiles[Row][Col].SetStyle(empty);
                savelevel[apindex].val = 0;
                GUI.changed = true;
            }
            else
            {
                if (currentStyle == null)
                {
                    currentStyle = empty;
                }
                tiles[Row][Col].SetStyle(currentStyle);
                Debug.Log(savelevel.Count);
                SetMap(apindex);
                GUI.changed = true;
            }
        }
        if (e.type == EventType.MouseDrag)
        {
            PaintTiles(Row, Col);
            e.Use();
        }
    }
    private void PaintTiles(int Row, int Col)
    {
        if (earse)
        {
            tiles[Row][Col].SetStyle(empty);
            savelevel[apindex].val = 0;
            GUI.changed = true;
        }
        else
        {
            if (currentStyle == null)
            {
                currentStyle = empty;
            }
            tiles[Row][Col].SetStyle(currentStyle);
            SetMap(apindex);
            GUI.changed = true;
        }
    }

    private void SetMap(int index)
    {
        if (currentStyle == tilemanager.buttonstyles[1].TileStyle)
        {
            savelevel[index].val = 1;

        }
        else if (currentStyle == tilemanager.buttonstyles[2].TileStyle)
        {
            savelevel[index].val = 2;
        }
        else
        {
            savelevel[index].val = 0;
        }
    }

    private void DrawNodes()
    {
            for (int i = 4; i < 14; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    if (j % 2 == 0 && i < 13)
                    {
                        tiles[i][j].Draw();
                    }
                    else if (j % 2 == 1 && i < 12)
                    {
                        tiles[i][j].Draw();
                    }
                }
            }
    }

    private void DrawGrid()
    {
        int withdivider = Mathf.CeilToInt(position.width / 20);
        int highdivider = Mathf.CeilToInt(position.height / 20);
        Handles.BeginGUI();
        Handles.color = new Color(0.5f, 0.5f, 0.5f, 0.2f);
        Vector3 newOffset = new Vector3(offset.x % 20, offset.y % 20, 0);
        for (int i = 0; i < withdivider; i++)
        {
            Handles.DrawLine(new Vector3(20 * i, -20, 0) + newOffset, new Vector3(20 * i, position.height, 0) + newOffset);
        }
        for (int i = 0; i < highdivider; i++)
        {
            Handles.DrawLine(new Vector3(-20,i * 20, 0) + newOffset, new Vector3(position.width, 20*i, 0) + newOffset);
        }
        Handles.color = Color.black; 
        Handles.EndGUI();
    }

    public void SetlayoutList()
    {
        layoutList = new List<List<int>>();
        for (int i = 0; i < 10; i++)
        {
            layoutList.Add(new List<int>());
            for (int j = 0; j < 9; j++)
            {
                if (i % 2 == 0 && j == 8)
                {
                    int index = (j * 10) + (i / 2);
                    int va = savelevel[index].val;
                    layoutList[i].Add(va);
                }
                else if (i % 2 == 1 && j == 8)
                {
                    layoutList[i].Add(3);
                }
                else
                {
                    int index = j * 10 + i;
                    int va = savelevel[index].val;
                    layoutList[i].Add(va);
                }
            }
        }
        level.SetLayout(layoutList);
    }

    public void OnDisable()
    {
        SaveLevel();
    }

    public void SaveLevel()
    {
        {
            string json = JsonConvert.SerializeObject(savelevel);
            Debug.Log(json);
            if (File.Exists(Application.dataPath + "/" + level.name + ".text"))
            {
                File.Delete(Application.dataPath + "/" + level.name + ".text");
            }
            File.AppendAllText(Application.dataPath + "/" + level.name + ".text", json);
        }
    }
}

