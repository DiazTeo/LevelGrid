using System;
using UnityEditor;
using UnityEngine;

namespace TeoDiaz.LevelGrid
{

    [Serializable,CustomEditor(typeof(Transform))]
    public class GridEditor : Editor
    {
        Transform lastGameObject = null;
        Vector3 pos;
        Vector3 cameraPos;
        private readonly float size = GridWindow.cellSize;

        private void OnSceneGUI()
        {
            lastGameObject = target as Transform;
            pos = lastGameObject == null ? Vector3.zero : lastGameObject.position;
            if (GridWindow.staticGrid)
            {
                pos = Vector3.zero;
            }
            if (EditorApplication.isPlaying || GridWindow.cellSize <= 0 || GridWindow.cellSizes.x <= 0 || GridWindow.cellSizes.y <= 0 || GridWindow.cellSizes.z <= 0)
            {
                return;
            }
            if (GridWindow.showGrid)
            {
                CreateGrid();
            }
            if (GridWindow.snap)
            {
                Snap();
            }
        }

        private void Snap()
        {
            Vector3 newPosition = lastGameObject.position;
            if (!GridWindow.differentSize)
            {
                if (GridWindow.gridY)
                {
                    newPosition = Grid2DMath.RoundToCell2DY(newPosition, GridWindow.cellSize);
                }
                if (GridWindow.gridX)
                {
                    newPosition = Grid2DMath.RoundToCell2DX(newPosition, GridWindow.cellSize);
                }
                if (GridWindow.gridZ)
                {
                    newPosition = Grid2DMath.RoundToCell2DZ(newPosition, GridWindow.cellSize);
                }
            } else
            {
                if (GridWindow.gridY)
                {
                    newPosition = Grid2DMath.RoundToCell2DY(newPosition, GridWindow.cellSizes);
                }
                if (GridWindow.gridX)
                {
                    newPosition = Grid2DMath.RoundToCell2DX(newPosition, GridWindow.cellSizes);
                }
                if (GridWindow.gridZ)
                {
                    newPosition = Grid2DMath.RoundToCell2DZ(newPosition, GridWindow.cellSizes);
                }
            }
            
            lastGameObject.position = newPosition;
        }

        private void CreateGrid()
        {
            cameraPos = Camera.current.transform.position;
            if (GridWindow.gridY)
            {
                Handles.color = Defaults.GridColorY;
                GridY();
            }
            if (GridWindow.gridX)
            {
                Handles.color = Defaults.GridColorX;
                GridX();
            }
            if (GridWindow.gridZ)
            {
                Handles.color = Defaults.GridColorZ;
                GridZ();
            }
        }

        private void GridY()
        {
            float xSize;
            float zSize;
            xSize = zSize = GridWindow.cellSize;
            if (GridWindow.differentSize)
            {
                xSize = GridWindow.cellSizes.x;
                zSize = GridWindow.cellSizes.z;
            }
            for (float z = cameraPos.z - 200; z < cameraPos.z + 200; z += zSize)
            {
                Handles.DrawLine(new Vector3(-200 + cameraPos.x, pos.y, Mathf.Floor(z / zSize) * zSize),
                                new Vector3(200f + cameraPos.x, pos.y, Mathf.Floor(z / zSize) * zSize));
            }

            for (float x = cameraPos.x - 200; x < cameraPos.x + 200; x += xSize)
            {
                Handles.DrawLine(new Vector3(Mathf.Floor(x / xSize) * xSize, pos.y, -200 + cameraPos.z),
                                new Vector3(Mathf.Floor(x / xSize) * xSize, pos.y, 200 + cameraPos.z));
            }
        }

        private void GridX()
        {
            float ySize;
            float zSize;
            ySize = zSize = GridWindow.cellSize;
            if (GridWindow.differentSize)
            {
                ySize = GridWindow.cellSizes.y;
                zSize = GridWindow.cellSizes.z;
            }
            for (float z = cameraPos.z - 200; z < cameraPos.z + 200; z += zSize)
            {
                Handles.DrawLine(new Vector3( pos.x, -200 + cameraPos.y, Mathf.Floor(z / zSize) * zSize),
                                new Vector3(pos.x, 200f + cameraPos.y, Mathf.Floor(z / zSize) * zSize));
            }

            for (float y = cameraPos.y - 200; y < cameraPos.y + 200; y += ySize)
            {
                Handles.DrawLine(new Vector3(pos.x, Mathf.Floor(y / ySize) * ySize, -200 + cameraPos.z),
                                new Vector3(pos.x, Mathf.Floor(y / ySize) * ySize, 200 + cameraPos.z));
            }
        }

        private void GridZ()
        {
            float ySize;
            float xSize;
            ySize = xSize = GridWindow.cellSize;
            if (GridWindow.differentSize)
            {
                ySize = GridWindow.cellSizes.y;
                xSize = GridWindow.cellSizes.x;
            }
            for (float x = cameraPos.z - 200; x < cameraPos.z + 200; x += xSize)
            {
                Handles.DrawLine(new Vector3(Mathf.Floor(x / xSize) * xSize, -200 + cameraPos.y, pos.z),
                                new Vector3(Mathf.Floor(x / xSize) * xSize, 200f + cameraPos.y, pos.z));
            }

            for (float y = cameraPos.y - 200; y < cameraPos.y + 200; y += ySize)
            {
                Handles.DrawLine(new Vector3(-200 + cameraPos.x,Mathf.Floor(y / ySize) * ySize, pos.z),
                                new Vector3(200 + cameraPos.x, Mathf.Floor(y / ySize) * ySize, pos.z));
            }
        }
    }
}
