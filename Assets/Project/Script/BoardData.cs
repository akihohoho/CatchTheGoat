using UnityEngine;

[CreateAssetMenu(fileName = "BoardData", menuName = "ScriptableObject/Board")]
public class BoardData : ScriptableObject
{
    [SerializeField] private Vector2 boardSize;
    [SerializeField] private Vector2 cellDistance;

    public Vector2 BoardSize => boardSize;
    public Vector2 CellDistance => cellDistance;
}
