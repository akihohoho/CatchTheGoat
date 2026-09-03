using System;
using UnityEngine;

public class NewMonoBehaviourScript : MonoBehaviour
{
    [SerializeField] private Vector2 boardSize;
    [SerializeField] private bool check = true;
    [SerializeField] Vector2 cellDistance;

    private void OnDrawGizmos()
    {
        if (check == false) return;
        
        for(float x = 0; x < boardSize.x; x++)
        {
            for(float y = 0; y < boardSize.y; y++)
            {
                float posX = (x - (boardSize.x - 1) / 2) * cellDistance.x;
                float posY = (y - (boardSize.y - 1) / 2) * cellDistance.y;

                Gizmos.DrawCube(new Vector3(posX, 0, posY), Vector3.one);
            }
        }
    }
}
