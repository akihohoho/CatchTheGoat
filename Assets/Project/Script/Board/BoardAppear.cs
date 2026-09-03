using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;

public class BoardAppear : MonoBehaviour
{
    private BoardData boardData;
    private List<GameObject> boardList = new List<GameObject>();
    [SerializeField] GameObject ground;

    public void DrawBoard(BoardData board)
    {
        DeleteBoard();
        boardData = board;
        for (int x = 0; x < board.BoardSize.x; x++)
        {
            for (int y = 0; y < board.BoardSize.y; y++)
            {
                Instantiate(ground, GetWorldPosition(x, y), Quaternion.identity, transform);
            }
        }
    }

    public void DeleteBoard()
    {
        for(int i = boardList.Count - 1; i >= 0; i--)
        {
            Destroy(boardList[i]);
            boardList.RemoveAt(i);
        }
    }
    public Vector3 GetWorldPosition(int x, int y)
    {
        float posX = (x - (boardData.BoardSize.x - 1) / 2) * boardData.CellDistance.x;
        float posY = (y - (boardData.BoardSize.y - 1) / 2) * boardData.CellDistance.y;

        return new Vector3(posX, 0, posY);
    }
}
