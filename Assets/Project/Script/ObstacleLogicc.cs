using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ObstacleLogicc : MonoBehaviour, IInteractable
{
    [SerializeField] private GameObject obstacle_pref;
     private List<GameObject> obsList;
    [SerializeField] private Obstacle obsSO;
    [SerializeField] private float duration;
    private GameObject gameobject;
    private Tween tweenRotate;

    private void Start()
    {
        obsList = new List<GameObject>();

    }
    [ContextMenu("Spawn")]
    private void SpawnChild()
    {
        ClearChild();

        if (obsSO == null && obsSO.Child == null && obsSO.Child.Count == 0) return;

        for(int i = 0; i < obsSO.Child.Count; i++)
        {
            Vector3 position = new Vector3(obsSO.Child[i].x + transform.position.x, 0, obsSO.Child[i].y + transform.position.y);

            gameobject = Instantiate(obstacle_pref, position, Quaternion.identity, transform);
            obsList.Add(gameobject);

        }
    }

    [ContextMenu("Rotate")]

    private void Rotate()
    {
        if (tweenRotate != null && tweenRotate.IsActive() && tweenRotate.IsPlaying()) return; 

        tweenRotate = transform.DOLocalRotate(new Vector3(0f, 90f, 0f), duration, RotateMode.LocalAxisAdd).SetEase(Ease.OutQuad);
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
