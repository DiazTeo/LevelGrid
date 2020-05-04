using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace TeoDiaz.LevelGrid
{
    [Serializable]
    public class GridWindow : EditorWindow
    {
        public static float cellSize = 4;
        public static bool differentSize = false;
        public static bool staticGrid = false;
        public static bool snap = false;
        public static Vector2 cellSizes = new Vector2(4,4);

        public void OnGUI()
        {
            GUILayout.Label("Grid", EditorStyles.boldLabel);
            staticGrid = EditorGUILayout.Toggle("Static Grid", staticGrid);
            snap = EditorGUILayout.Toggle("Snap Grid", snap);
            if (differentSize)
            {
                cellSizes = EditorGUILayout.Vector2Field("Size", cellSizes);
            }
            else
            {
                cellSize = EditorGUILayout.FloatField("Size", cellSize);
            }
        }

        [MenuItem("Tools/LevelGrid")]
        public static void ShowWindow()
        {
            GetWindow<GridWindow>("Level Grid");
        }
    }
}
