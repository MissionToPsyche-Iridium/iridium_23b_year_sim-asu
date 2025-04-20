using System.Diagnostics;
using UnityEngine;
using UnityEngine.EventSystems;

public class MenuCamera : MonoBehaviour
{
    public Animator cameraAnimator;
    public GameObject clickablePanel;

    private static bool hasPlayedIntro = false;

    void Start()
    {
        if (hasPlayedIntro)
        {
            transform.position = new Vector3(1132f, 0f, -5.5f);
        }
    }

    void Update()
    {
        if (!hasPlayedIntro && Input.GetMouseButtonDown(0))
        {
            PointerEventData pointerData = new PointerEventData(EventSystem.current)
            {
                position = Input.mousePosition
            };

            var raycastResults = new System.Collections.Generic.List<RaycastResult>();

            EventSystem.current.RaycastAll(pointerData, raycastResults);

            foreach (var result in raycastResults)
            {
                if (result.gameObject == clickablePanel)
                {
                    PlayIntro();
                    break;
                }
            }
        }
    }

    void PlayIntro()
    {
        if (cameraAnimator != null)
        {
            cameraAnimator.enabled = true;
        }

        hasPlayedIntro = true;
    }
}
