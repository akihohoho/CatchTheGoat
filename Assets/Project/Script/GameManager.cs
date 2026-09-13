using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;
    public static GameManager Instance => instance;
    private Vector2Int playerPos;
    private Vector2Int endPos;
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
    private void WinHandle()
    {
        Debug.Log("Win");
    }
}
