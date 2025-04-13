using UnityEngine;

public class CameraController : MonoBehaviour
{
    private Anchor currentAnchor;

    public float swipeSpeed = 0.5f;
    private Vector3 touchStart;
    private bool isDragging = false;

    void Start()
    {
        if (currentAnchor == null)
        {
            currentAnchor = GetComponentInParent<Anchor>(); 
        }

        if (currentAnchor != null)
        {
            SnapToAnchor(currentAnchor);
        }
    }

    void Update()
    {
        if (currentAnchor == null) return;

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

            
            Vector2 minOffset = currentAnchor.minOffset;
            Vector2 maxOffset = currentAnchor.maxOffset;
            Vector3 anchorPos = currentAnchor.transform.position;

            newPosition.x = Mathf.Clamp(newPosition.x, anchorPos.x + minOffset.x, anchorPos.x + maxOffset.x);
            newPosition.y = Mathf.Clamp(newPosition.y, anchorPos.y + minOffset.y, anchorPos.y + maxOffset.y);

            transform.position = newPosition;
        }

        if (Input.GetMouseButtonUp(0))
        {
            isDragging = false;
        }
    }

    public void SnapToAnchor(Anchor newAnchor)
    {
        currentAnchor = newAnchor;
        transform.position = newAnchor.transform.position;
    }
}
