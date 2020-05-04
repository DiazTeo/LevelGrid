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
    }
}
