using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

[CreateAssetMenu(fileName = "Level", menuName = "LevelEditor/New level", order = 1)]
public class Level : ScriptableObject
{
    [JsonProperty]
    [SerializeField]
    public double bnc = 0.7;

    [JsonProperty]
    [SerializeField]
    public int color = 3;

    [SerializeField]
    public List<List<int>> layout = new List<List<int>>();

    [JsonProperty]
    [SerializeField]
    public string name;

    [JsonProperty]
    [SerializeField]
    public int sink = 0;

    [JsonProperty]
    [SerializeField]
    public int[] style = { 12, 3, 1, 6, 5, 8, 11, 16, 2, 10, 7, 4, 13, 15, 9, 14, 17, 18 };

    public void SetLayout(List<List<int>> Layout)
    {
        layout = Layout;
    }
}
