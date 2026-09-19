using UnityEngine;

public class GoatController : MonoBehaviour
{
    [SerializeField] private LevelManager levelManager;
    [SerializeField] private GameObject goatPref;
    [SerializeField] private BoardAppear boardAppear;

    public void SetUpGoat(LevelDataSO levelSO)
    {
        Vector3 goatPos = boardAppear.GetWorldPosition((int)levelSO.GoatPosition.x, (int)levelSO.GoatPosition.y);
        goatPos.y = 1; 
        Instantiate(goatPref, goatPos, Quaternion.identity, transform);
    }

}
