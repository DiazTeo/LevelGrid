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
        public static bool showGrid = true;
        public static float cellSize = 4;
        public static bool differentSize = false;
        public static bool staticGrid = false;
        public static bool snap = false;
        public static bool gridY = true;
        public static bool gridX = false;
        public static bool gridZ = false;
        public static Vector3 cellSizes = new Vector3(4,4,4);

        public void OnGUI()
        {
            GUILayout.Label("Grid", EditorStyles.boldLabel);
            showGrid = EditorGUILayout.Toggle("Show Grid", showGrid);

            if (showGrid)
            {
                staticGrid = EditorGUILayout.Toggle("Static Grid", staticGrid);
                snap = EditorGUILayout.Toggle("Snap Grid", snap);
                gridX = EditorGUILayout.Toggle("Show GridX", gridX);
                gridY = EditorGUILayout.Toggle("Show GridY", gridY);
                gridZ = EditorGUILayout.Toggle("Show GridZ", gridZ);
                differentSize= EditorGUILayout.Toggle("DifferentSize", differentSize);
                if (differentSize)
                {
                    cellSizes = EditorGUILayout.Vector3Field("Size", cellSizes);
                }
                else
                {
                    cellSize = EditorGUILayout.FloatField("Size", cellSize);
                }
            }
        }

        [MenuItem("Tools/LevelGrid")]
        public static void ShowWindow()
        {
            GetWindow<GridWindow>("Level Grid");
        }
    }
}
