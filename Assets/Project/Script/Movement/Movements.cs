using UnityEngine;
using UnityEngine.InputSystem;

public class Movements : MonoBehaviour
{
    private Vector2 startPos;
    private InputActions playerControls;
    [SerializeField] private float holdDistance = 20f;
    [SerializeField] private float startTime;
    //[SerializeField] ObstacleLogic obsLogic;

    //private InputAction pressAction;
    //private InputAction positionAction;

    private MoveDirection currentSwipe = MoveDirection.none;

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
        startTime = Time.time;
        Debug.Log("Bắt đầu Tap tại tọa độ: " + startPos);
    }

    private void CancelTap(InputAction.CallbackContext cxt)
    {
        Vector2 endPos = playerControls.Touch.PrimaryPosition.ReadValue<Vector2>();
        Debug.Log("Thả tay tại tọa độ: " + endPos);
        CalculateSwipe(endPos);
    }

    //private enum SwipeDirection{
    //    none,
    //    up,
    //    down,
    //    left,
    //    right
    //};
    private void CalculateSwipe(Vector2 endPos)
    {
        Vector2 delta = endPos - startPos;
        if (delta.magnitude > holdDistance)
        {

            if (Mathf.Abs(delta.x) > Mathf.Abs(delta.y))
            {
                currentSwipe = delta.x > 0 ? MoveDirection.right : MoveDirection.left;
            }
            else
            {
                currentSwipe = delta.y > 0 ? MoveDirection.up : MoveDirection.down;
            }
            Debug.Log("Đang vuốt hướng " + currentSwipe);
        }
        else if(Time.time - startTime <= 0.2f)
        {
            // TODO: transform.postition hay startPos/endPos?
            Ray ray = Camera.main.ScreenPointToRay(endPos);
            // TODO: Xem lai
            if (Physics.Raycast(ray, out RaycastHit raycastHit))
            {
                IInteractable interac = raycastHit.collider.gameObject.GetComponent<IInteractable>();
                if (interac != null)
                {
                    interac.Interact();
                }
            }
        }
        else
        {
            currentSwipe = MoveDirection.none;
            Debug.Log("Không đủ khoảng cách để tính là Swipe!!!");
        }

    }
}
