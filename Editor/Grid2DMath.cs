using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TeoDiaz.LevelGrid
{
    public static class Grid2DMath
    {
        /// <summary>
        /// Arrondis des coordonne�s selon une grille 2D
        /// </summary>
        /// <param name="position"></param>
        /// <param name="cellSize"></param>
        /// <returns></returns>
        public static Vector3 RoundToCell2DY(Vector3 position, float cellSize)
        {
            position.x = Mathf.Floor(position.x / cellSize) * cellSize + cellSize / 2;
            position.z = Mathf.Floor(position.z / cellSize) * cellSize + cellSize / 2;
            return position;
        }
        public static Vector3 RoundToCell2DX(Vector3 position, float cellSize)
        {
            position.y = Mathf.Floor(position.y / cellSize) * cellSize + cellSize / 2;
            position.z = Mathf.Floor(position.z / cellSize) * cellSize + cellSize / 2;
            return position;
        }

        public static Vector3 RoundToCell2DZ(Vector3 position, float cellSize)
        {
            position.y = Mathf.Floor(position.y / cellSize) * cellSize + cellSize / 2;
            position.x = Mathf.Floor(position.x / cellSize) * cellSize + cellSize / 2;
            return position;
        }

        public static Vector3 RoundToCell2DY(Vector3 position, Vector3 cellSize)
        {
            position.x = Mathf.Floor(position.x / cellSize.x) * cellSize.x + cellSize.x / 2;
            position.z = Mathf.Floor(position.z / cellSize.z) * cellSize.z + cellSize.z / 2;
            return position;
        }
        public static Vector3 RoundToCell2DX(Vector3 position, Vector3 cellSize)
        {
            position.y = Mathf.Floor(position.y / cellSize.y) * cellSize.y + cellSize.y / 2;
            position.z = Mathf.Floor(position.z / cellSize.z) * cellSize.z + cellSize.z / 2;
            return position;
        }

        public static Vector3 RoundToCell2DZ(Vector3 position, Vector3 cellSize)
        {
            position.y = Mathf.Floor(position.y / cellSize.y) * cellSize.y + cellSize.y / 2;
            position.x = Mathf.Floor(position.x / cellSize.x) * cellSize.x + cellSize.x / 2;
            return position;
        }
    }
}
