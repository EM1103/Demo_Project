using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Vector2 minOffset, maxOffset; // Limits relative to the anchor
    private Transform currentAnchor;

    public float swipeSpeed = 0.5f;
    private Vector3 touchStart;
    private bool isDragging = false;

    void Start()
    {
        if (currentAnchor == null)
        {
            currentAnchor = transform; // Default to itself
        }

        // Apply the initial position and limits
        ApplyLimits();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            touchStart = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            isDragging = true;
        }

        if (Input.GetMouseButton(0) && isDragging)
        {
            Vector3 touchEnd = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector3 movement = touchStart - touchEnd;
            Vector3 newPosition = transform.position + movement * swipeSpeed;

            // Apply limits relative to the current anchor
            newPosition.x = Mathf.Clamp(newPosition.x, currentAnchor.position.x + minOffset.x, currentAnchor.position.x + maxOffset.x);
            newPosition.y = Mathf.Clamp(newPosition.y, currentAnchor.position.y + minOffset.y, currentAnchor.position.y + maxOffset.y);

            transform.position = newPosition;
        }

        if (Input.GetMouseButtonUp(0))
        {
            isDragging = false;
        }
    }

    // Method to change the anchor and update limits
    public void SetAnchor(Transform newAnchor, Vector2 newMinOffset, Vector2 newMaxOffset)
    {
        currentAnchor = newAnchor;
        minOffset = newMinOffset;
        maxOffset = newMaxOffset;
        transform.position = currentAnchor.position; // Snap to new anchor
        ApplyLimits();
    }

    // Ensures limits are applied correctly
    private void ApplyLimits()
    {
        Vector3 clampedPosition = transform.position;

        clampedPosition.x = Mathf.Clamp(clampedPosition.x, currentAnchor.position.x + minOffset.x, currentAnchor.position.x + maxOffset.x);
        clampedPosition.y = Mathf.Clamp(clampedPosition.y, currentAnchor.position.y + minOffset.y, currentAnchor.position.y + maxOffset.y);

        transform.position = clampedPosition;
    }
}
