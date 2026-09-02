using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Obstacle Data", menuName = "ScriptableObject/Obstacle")]
public class Obstacle : ScriptableObject
{
        [SerializeField] private List<Vector2Int> child;
        public List<Vector2Int> Child => child;
}
