using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ObstacleLogic : MonoBehaviour, IInteractable
{
    [SerializeField] private GameObject obstacle_pref;
    private List<GameObject> obsList = new List<GameObject>();
    [SerializeField] private float duration;
    private RotateType currentRotation = RotateType.Deg0;
    private List<Vector2Int> currentOccupiedCells;
    private GameObject gameobject;
    private Tween tweenRotate;
    private Vector2Int root;
    private List<Vector2Int> childPosition;

    public void Spawn(Vector3 positionInWorld, Vector2Int root, RotateType currentRotate, List<Vector2Int> child)
    {
        transform.position = positionInWorld;
        this.root = root;
        currentRotation = currentRotate;
        this.childPosition = new List<Vector2Int>(child);

        SpawnChild();
    }

    public void SpawnChild()
    {
        ClearChild();

        if (childPosition == null) return;

        for(int i = 0; i < childPosition.Count; i++)
        {
            Vector2 rotateOffset = RotateOffset(childPosition[i], currentRotation); // Cap nhat child theo curentRotation
            Vector3 position = new Vector3(rotateOffset.x + transform.position.x, transform.position.y, rotateOffset.y + transform.position.z);

            currentOccupiedCells = GetOccupiedCells(childPosition, root, currentRotation);
            GridManager.Instance.RegisterCells(currentOccupiedCells);

            gameobject = Instantiate(obstacle_pref, position, Quaternion.identity, transform);
            obsList.Add(gameobject);
        }
    }
    private List<Vector2Int> GetOccupiedCells(List<Vector2Int> childPos, Vector2Int root, RotateType currentRotate)
    {
        List<Vector2Int> result = new List<Vector2Int>();
        result.Add(root);
        foreach(Vector2Int cell in childPos)
        {
            Vector2Int newChild = RotateOffset(cell, currentRotate);
            result.Add(newChild + root);
        }
        return result;
    }

    [ContextMenu("Rotate")]

    public void Rotate()
    {
        if (tweenRotate != null && tweenRotate.IsActive() && tweenRotate.IsPlaying()) return;
        GridManager.Instance.UnregisterCells(currentOccupiedCells);
        tweenRotate = transform.DOLocalRotate(new Vector3(0f, 90f, 0f), duration, RotateMode.LocalAxisAdd).SetEase(Ease.OutQuad);

        currentRotation = (RotateType)(((float)currentRotation + 90f) % 360);
        currentOccupiedCells = GetOccupiedCells(childPosition, root, currentRotation);
        GridManager.Instance.RegisterCells(currentOccupiedCells);
    }

    private Vector2Int RotateOffset(Vector2Int childOffset, RotateType currentRotation)
    {
        int x = childOffset.x;
        int y = childOffset.y;
        Vector2Int childUpdate = currentRotation switch
        {
            // Moi lan xoay 90 do se doi toa do theo quy luat (x, -y)
            RotateType.Deg0 => new Vector2Int(x, y),
            RotateType.Deg90 => new Vector2Int (y, -x),
            RotateType.Deg180 =>  new Vector2Int(-x, -y),
            RotateType.Deg270 => new Vector2Int(-y, x),
            _=> Vector2Int.zero
        };
        return childUpdate;
    }


    private void ClearChild()
    {
        for(int i = obsList.Count - 1; i >= 0; i--)
        {
            Destroy(obsList[i]);
            obsList.RemoveAt(i);
        }
    }

    public void Interact()
    {
        Rotate();
    }
}
