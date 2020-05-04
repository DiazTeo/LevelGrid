using System;
using UnityEditor;
using UnityEngine;

namespace TeoDiaz.LevelGrid
{
    
    [CustomEditor(typeof(Transform)), Serializable]
    public class GridEditor : Editor
    {
        Transform lastGameObject;
        Vector3 pos;
        Vector3 cameraPos;
        float size = GridWindow.cellSize;

        protected void OnSceneGUI()
        {
            lastGameObject = target as Transform;
            pos = lastGameObject == null ? Vector3.zero : lastGameObject.position;
            if (GridWindow.staticGrid)
            {
                pos = Vector3.zero;
            }
            if (EditorApplication.isPlaying)
            {
                return;
            }
            CreateGrid();
            if (GridWindow.snap)
            {
                Snap(); 
            }
        }

        private void Snap()
        {
            Vector3 newPosition = Grid2DMath.RoundToCell2DY(lastGameObject.position, GridWindow.cellSize);
            lastGameObject.position = newPosition;
        }

        private void CreateGrid()
        {
            Handles.color = Defaults.GridColorY;
            cameraPos = Camera.current.transform.position;
            GridY();
        }

        private void GridY()
        {
            float xSize;
            float zSize;
            xSize = zSize = GridWindow.cellSize;
            for (float z = cameraPos.z - 200; z < cameraPos.z + 200; z += size)
            {
                Handles.DrawLine(new Vector3(-200 + cameraPos.x, pos.y, Mathf.Floor(z / zSize) * zSize),
                                new Vector3(200f + cameraPos.x, pos.y, Mathf.Floor(z / zSize) * zSize));
            }

            for (float x = cameraPos.x - 200; x < cameraPos.x + 200; x += size)
            {
                Handles.DrawLine(new Vector3(Mathf.Floor(x / xSize) * xSize, pos.y, -200 + cameraPos.z),
                                new Vector3(Mathf.Floor(x / xSize) * xSize, pos.y, 200 + cameraPos.z));
            }
        }
    }
}
