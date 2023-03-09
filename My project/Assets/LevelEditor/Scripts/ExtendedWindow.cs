using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class ExtendedWindow : EditorWindow
{
    protected SerializedObject serializedObject;
    protected SerializedProperty current;
    Level level;
    TileManager tilemanager;

    private string selectedPropertyPath;
    protected SerializedProperty selectedProperty;

    //protected void LevelList(SerializedProperty prop, bool drawChildren)
    //{
    //    string lastPropPath = string.Empty;
    //    foreach(SerializedProperty p in prop)
    //    {
    //        if (GUILayout.Button("Add New Item"))
    //        {
    //            prop.arraySize++;
    //        }

    //        if (p.isArray && p.propertyType == SerializedPropertyType.Generic)
    //        {
    //            lastPropPath = p.propertyPath;

    //            EditorGUILayout.BeginHorizontal();
    //            p.isExpanded = EditorGUILayout.Foldout(p.isExpanded, p.displayName);
    //            EditorGUILayout.EndHorizontal();

    //            if (p.isExpanded)
    //            {
    //                EditorGUI.indentLevel++;
    //                LevelList(p, drawChildren);
    //                EditorGUI.indentLevel--;
    //            }
    //            else
    //            {
    //                if(!string.IsNullOrEmpty(lastPropPath) && p.propertyPath.Contains(lastPropPath)) { continue; }
    //                lastPropPath = p.propertyPath;
    //                EditorGUILayout.PropertyField(p, drawChildren);
    //            }
    //        }
    //    }
    //}

    //protected void DrawSidebar(LevelSet levelSet)
    //{
    //    foreach(Level p in levelSet.levels)
    //    {
            
    //        if (GUILayout.Button(p.name))
    //        {
    //            if (p.savelevel.Count == 0)
    //            {
    //                p.SetUpList();
                    
    //            }
    //            p.savelevel[24].val = 1;
                
    //        }
    //    }

    //    if (!string.IsNullOrEmpty(selectedPropertyPath))
    //    {
    //        selectedProperty = serializedObject.FindProperty(selectedPropertyPath);
    //    }
    //}

    //protected int Tiles(int i, int j)
    //{
    //    level.savelevel.
    //    return i;
    //}

}
