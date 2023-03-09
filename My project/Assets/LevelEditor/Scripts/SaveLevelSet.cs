using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;
using Newtonsoft.Json;

[CustomEditor(typeof(LevelSet))]
public class SaveLevelSet : Editor
{

   
    public override void OnInspectorGUI()
    {
        if (GUILayout.Button("Save LevelSet"))
        {
            SaveLevelset((LevelSet)target);
        }

        DrawDefaultInspector();
       

    }

    public void SaveLevelset(LevelSet levelSet)
    {
        levelSet.SetLevel();
        if (File.Exists(Application.dataPath + "/" + levelSet.name + ".json"))
        {
            File.Delete(Application.dataPath + "/" + levelSet.name + ".json");
        }

        for (int i = 0; i < levelSet.allLevels.Count; i++)
        {
            string json = JsonConvert.SerializeObject(levelSet.levelsave[i]);
            Debug.Log(json);
            if (i == 0)
            {
                File.AppendAllText(Application.dataPath + "/" + levelSet.name + ".json", "[" + json + "," );

            }else if (i == levelSet.allLevels.Count - 1)
            {
                File.AppendAllText(Application.dataPath + "/" + levelSet.name + ".json", json + "]");
            }else
            {
                File.AppendAllText(Application.dataPath + "/" + levelSet.name + ".json", json + ",");
            }
            
        }
    }




}
