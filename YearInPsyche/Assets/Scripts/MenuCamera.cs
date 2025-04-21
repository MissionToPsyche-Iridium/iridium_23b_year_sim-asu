using System.Collections;
using System.Collections.Generic;
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
            cameraAnimator.enabled = false;

            GameObject menu = GameObject.Find("Main Camera")?.transform.Find("Menu")?.gameObject;
            if (menu != null)
            {
                menu.SetActive(true);
            }
            transform.position = new Vector3(1132f, 0f, -5.5f);

            transform.rotation = Quaternion.Euler(0f, 365f, 0f);
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

            var raycastResults = new List<RaycastResult>();
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
            StartCoroutine(DisableAnimatorAfterAnimation());
        }

        hasPlayedIntro = true;
    }

    IEnumerator DisableAnimatorAfterAnimation()
    {
        // Wait 1 frame to ensure Animator is playing
        yield return null;

        float waitTime = cameraAnimator.GetCurrentAnimatorStateInfo(0).length;
        if (waitTime <= 0f) waitTime = 5f; // Optional fallback
        yield return new WaitForSeconds(waitTime);

        cameraAnimator.enabled = false;

        GameObject menu = GameObject.Find("Main Camera")?.transform.Find("Menu")?.gameObject;
        if (menu != null)
        {
            menu.SetActive(true);
        }
    }

}
