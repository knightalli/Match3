using UnityEngine;

public class AngleChecker : MonoBehaviour
{
    public Vector2 firstMousePosition;
    public Vector2 currentMousePosition;
    public float angleBetween;
    public bool isControlling;
    public string swipeDirection;

    // Start is called before the first frame update
    void Start()
    {
        isControlling = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            firstMousePosition = Camera.main.ScreenToViewportPoint(Input.mousePosition);
            isControlling = true;
        }
        if (Input.GetMouseButtonUp(0))
        {
            isControlling = false;
        }
    }
}
