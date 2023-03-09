using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

[CreateAssetMenu(fileName = "LevelSet", menuName = "LevelEditor/New levelSet", order = 1)]
public class LevelSet : ScriptableObject
{
   
    [SerializeField]
    public List<Level> allLevels;

    [HideInInspector]
    public List<LevelSave> levelsave;

    public void SetLevel()
    {
        levelsave = new List<LevelSave>();
        for (int i = 0; i < allLevels.Count; i++)
        {
            levelsave.Add(new LevelSave(allLevels[i].bnc, allLevels[i].color, allLevels[i].layout, allLevels[i].name, allLevels[i].sink, allLevels[i].style));
        }

    }

}
