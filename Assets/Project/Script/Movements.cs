using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.InputSystem;

public class Movements : MonoBehaviour
{
    private Vector2 startPos;
    private InputActions playerControls;
    [SerializeField] private float holdDistance = 20f;

    //private InputAction pressAction;
    //private InputAction positionAction;

    private SwipeDirection currentSwipe = SwipeDirection.none;

    private void Awake()
    { 
        playerControls = new InputActions();
        //pressAction = new InputAction("Press", binding: "<Pointer>/press");
        //positionAction = new InputAction("Position", binding: "<Pointer>/position");

        //pressAction.started += 
        //pressAction.canceled += 

        playerControls.Touch.PrimaryContact.started += StartTap;
        playerControls.Touch.PrimaryContact.canceled += CancelTap;
    }

    private void OnEnable()
    {
        playerControls.Enable();
        //pressAction.Enable();
        //positionAction.Enable();
    }

    private void OnDisable()
    {
        playerControls.Disable();
        //pressAction.Disable();
        //positionAction.Disable();
    }

    private void StartTap(InputAction.CallbackContext cxt)
    {
        startPos = playerControls.Touch.PrimaryPosition.ReadValue<Vector2>();
        Debug.Log("Bắt đầu Tap tại tọa độ: " + startPos);
    }

    private void CancelTap(InputAction.CallbackContext cxt)
    {
        Vector2 endPos = playerControls.Touch.PrimaryPosition.ReadValue<Vector2>();
        Debug.Log("Thả tay tại tọa độ: " + endPos);
        CalculateSwipe(endPos);
    }

    private enum SwipeDirection{
        none,
        up,
        down,
        left,
        right
    };
    private void CalculateSwipe(Vector2 endPos)
    {
        Vector2 delta = endPos - startPos;
        if (delta.magnitude > holdDistance)
        {

            if (Mathf.Abs(delta.x) > Mathf.Abs(delta.y))
            {
                currentSwipe = delta.x > 0 ? SwipeDirection.right : SwipeDirection.left;
            }
            else
            {
                currentSwipe = delta.y > 0 ? SwipeDirection.up : SwipeDirection.down;
            }
            Debug.Log("Đang vuốt hướng " + currentSwipe);
        }
        else
        {
            currentSwipe = SwipeDirection.none;
            Debug.Log("Không đủ khoảng cách để tính là Swipe!!!");
        }

    }
}
