using UnityEngine;

public class MenuCamera : MonoBehaviour
{
    public Animator cameraAnimator;
    public string animationTrigger = "PlayIntro";

    // This flag persists across scenes for this session
    private static bool hasPlayedIntro = false;

    void Start()
    {
        if (!hasPlayedIntro)
        {
            //if (cameraAnimator != null)
            //{
            //    cameraAnimator.SetTrigger(animationTrigger);
            //}
            cameraAnimator.enabled = true;
            hasPlayedIntro = true;
        }
        else
        {
            // Optionally, disable the Animator component so it doesn’t loop or restart
            if (cameraAnimator != null)
            {
                cameraAnimator.enabled = false;
            }
        }
    }
}
