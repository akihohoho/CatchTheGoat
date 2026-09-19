using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;
    public static GameManager Instance => instance;
    private Vector2Int playerPos;
    private Vector2Int endPos;
    private GameState currentState = GameState.NotGoing;

    public GameState CurrentState => currentState;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject); // Bắt buộc phải có để diệt bản sao lỗi khi chơi lại màn
        }
    }

    public void SetEndPos(Vector2Int pos)
    {
        endPos = pos;
    }
    public void SetPlayerPos(Vector2Int pos)
    {
        playerPos = pos;
        if(playerPos == endPos)
        {
            WinHandle();
        }
    }

    public void ChangeStateGame(bool isPlay)
    {
        currentState = isPlay ? GameState.OnGoing : GameState.NotGoing;
    }    
    private void WinHandle()
    {
        Debug.Log("Win");
    }
}
