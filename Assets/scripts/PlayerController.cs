using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Transform bottomBar; // Reference to the bottom bar's transform
    public Transform upperBar; // Reference to the upper bar's transform
    private Vector2 touchStartPosition;
    private Vector2 currentPosition;
    private Rigidbody2D bottomBarRb;
    private Rigidbody2D upperBarRb;

    public float movementSpeed = 5f;

    private void Start()
    {
        bottomBarRb = bottomBar.GetComponent<Rigidbody2D>();
        upperBarRb = upperBar.GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Handle touches on the bottom bar
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            switch (touch.phase)
            {
                case TouchPhase.Began:
                    touchStartPosition = touch.position;
                    currentPosition = bottomBarRb.position;
                    break;

                case TouchPhase.Moved:
                    if (UIControl.Instance.isDraggingBottom)
                    {
                        Vector2 touchOffset = touch.position - touchStartPosition;
                        Vector2 targetPosition = currentPosition + touchOffset * movementSpeed * Time.deltaTime;
                        bottomBarRb.MovePosition(targetPosition);
                    }
                    else if (UIControl.Instance.isDraggingUpper)
                    {
                        Vector2 touchOffset = touch.position - touchStartPosition;
                        Vector2 targetPosition = currentPosition + touchOffset * movementSpeed * Time.deltaTime;
                        upperBarRb.MovePosition(targetPosition);
                    }
                    break;

                case TouchPhase.Ended:
                    break;
            }
        }
    }
}