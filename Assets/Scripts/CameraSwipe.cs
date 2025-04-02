using UnityEngine;

public class CameraSwipe : MonoBehaviour
{
    public float swipeSpeed = 0.1f; // Adjust how fast the swipe moves the camera
    public float leftLimit = -5f; // Set the left boundary
    public float rightLimit = 5f; // Set the right boundary

    private Vector2 startTouchPosition;
    private Vector2 currentTouchPosition;
    private bool isSwiping = false;

    void Update()
    {
        // Handle touch input
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            HandleSwipe(touch.phase, touch.position);
        }

        // Handle mouse input (for testing on a laptop)
        if (Input.GetMouseButtonDown(0)) // Left mouse button pressed
        {
            startTouchPosition = Input.mousePosition;
            isSwiping = true;
        }
        else if (Input.GetMouseButton(0) && isSwiping) // Mouse drag
        {
            currentTouchPosition = (Vector2)Input.mousePosition;
            float difference = (startTouchPosition.x - currentTouchPosition.x) * swipeSpeed;
            
            float newX = Mathf.Clamp(transform.position.x + difference, leftLimit, rightLimit);
            transform.position = new Vector3(newX, transform.position.y, transform.position.z);

            startTouchPosition = currentTouchPosition;
        }
        else if (Input.GetMouseButtonUp(0)) // Mouse button released
        {
            isSwiping = false;
        }
    }

    private void HandleSwipe(TouchPhase phase, Vector2 position)
    {
        if (phase == TouchPhase.Began)
        {
            startTouchPosition = position;
            isSwiping = true;
        }
        else if (phase == TouchPhase.Moved && isSwiping)
        {
            currentTouchPosition = position;
            float difference = (startTouchPosition.x - currentTouchPosition.x) * swipeSpeed;
            
            float newX = Mathf.Clamp(transform.position.x + difference, leftLimit, rightLimit);
            transform.position = new Vector3(newX, transform.position.y, transform.position.z);

            startTouchPosition = currentTouchPosition;
        }
        else if (phase == TouchPhase.Ended)
        {
            isSwiping = false;
        }
    }
}
