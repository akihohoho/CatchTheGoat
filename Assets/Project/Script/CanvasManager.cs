using TMPro;
using UnityEngine;

public class CanvasManager : MonoBehaviour
{
    [SerializeField] private Transform gameplayPanel;
    [SerializeField] private Transform mainPanel;

    public void OnClickStart()
    {
        mainPanel.gameObject.SetActive(false);
        GameManager.Instance.ChangeStateGame(true);
        gameplayPanel.gameObject.SetActive(true);
    }
    public void OnClickBack()
    {
        gameplayPanel.gameObject.SetActive(false);
        GameManager.Instance.ChangeStateGame(false);
        mainPanel.gameObject.SetActive(true);
    }
}
