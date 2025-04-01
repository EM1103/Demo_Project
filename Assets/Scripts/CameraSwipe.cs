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
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                startTouchPosition = touch.position;
                isSwiping = true;
            }
            else if (touch.phase == TouchPhase.Moved && isSwiping)
            {
                currentTouchPosition = touch.position;
                float difference = (startTouchPosition.x - currentTouchPosition.x) * swipeSpeed;
                
                float newX = Mathf.Clamp(transform.position.x + difference, leftLimit, rightLimit);
                transform.position = new Vector3(newX, transform.position.y, transform.position.z);

                startTouchPosition = currentTouchPosition;
            }
            else if (touch.phase == TouchPhase.Ended)
            {
                isSwiping = false;
            }
        }
    }
}
