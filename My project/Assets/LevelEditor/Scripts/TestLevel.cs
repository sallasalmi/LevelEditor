using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "filename", menuName = "TestLevel" )]
public class TestLevel : ScriptableObject
{
    [SerializeField]
    public string LevelSet;

    [SerializeField]
    public int Level;

    [SerializeField]
    public bool testmode;

}
