using UnityEngine;

public class CreditsScrolling : MonoBehaviour
{
    public float scrollSpeed = 1000f; // Speed
    public float minY = -800f; // Lowest point credits can scroll to
    public float maxY = 1000f; // Highest point credits can scroll to

    private RectTransform rect;

    void Start()
    {
        rect = GetComponent<RectTransform>();
    }

    void Update()
    {
        float move = 0f;

        if (Input.GetKey(KeyCode.UpArrow))
        {
            move = -scrollSpeed * Time.deltaTime;
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            move = scrollSpeed * Time.deltaTime;
        }

        if (Mathf.Abs(move) > 0f)
        {
            Vector2 pos = rect.anchoredPosition;
            pos.y += move;
            pos.y = Mathf.Clamp(pos.y, minY, maxY);
            rect.anchoredPosition = pos;
        }
    }
}
