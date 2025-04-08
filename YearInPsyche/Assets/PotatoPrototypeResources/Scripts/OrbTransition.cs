using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class OrbTransition : MonoBehaviour
{
    public Button triggerButton;
    public GameObject orb;
    public GameObject psycheAsteroid;
    public GameObject potato;
    public Button backButton;

    public GameObject introText;
    public GameObject questionText;
    public GameObject headerText;
    public GameObject infoText;
    public GameObject simpleText;
    public GameObject disclaimerText;

    public Transform cameraPivot;
    public float orbitSpeed = 20f;

    public float orbScaleFactor = 10f;
    public float orbScaleTime = 1.5f;
    public float startDelay = 1f;
    public float pauseDuration = 1f;

    public float spinUpSpeed = 720f; // degrees per second
    public float spinStartSpeed = 90f;
    public float spinUpTime = 2f;
    public float spinDownTime = 2f;

    private float currentSpinSpeed = 1f;
    private bool spinPsyche = false;
    private bool spinPotato = false;
    private bool spinCamera = false;

    void Start()
    {
        headerText.SetActive(false);
        infoText.SetActive(false);
        simpleText.SetActive(false);
        disclaimerText.SetActive(false);
        spinCamera = true; // Move this around to change when the camera should start spinning
        triggerButton.onClick.AddListener(() => StartCoroutine(DoEffect()));
        potato.SetActive(false); // Hide potato at the start
    }

    IEnumerator DoEffect()
    {
        // Hide UI
        triggerButton.gameObject.SetActive(false);
        introText.SetActive(false);
        questionText.SetActive(false);
        backButton.gameObject.SetActive(false);

        StartCoroutine(GrowShrinkOrb());
        StartCoroutine(SpinAndDisappearPsyche());
        
        yield return null;
    }

    IEnumerator GrowShrinkOrb()
    {
        Vector3 originalScale = orb.transform.localScale;
        Vector3 targetScale = originalScale * orbScaleFactor;

        // Delay
        yield return new WaitForSeconds(startDelay);

        // Grow
        float t = 0;
        while (t < orbScaleTime)
        {
            orb.transform.localScale = Vector3.Lerp(originalScale, targetScale, t / orbScaleTime);
            t += Time.deltaTime;
            yield return null;
        }
        orb.transform.localScale = targetScale;

        // Pause
        yield return new WaitForSeconds(pauseDuration);

        // Shrink
        t = 0;
        while (t < orbScaleTime)
        {
            orb.transform.localScale = Vector3.Lerp(targetScale, originalScale, t / orbScaleTime);
            t += Time.deltaTime;
            yield return null;
        }
        orb.transform.localScale = originalScale;
    }

    IEnumerator SpinAndDisappearPsyche()
    {
        float t = 0;
        spinPsyche = true;
        headerText.SetActive(true);

        while (t < spinUpTime)
        {
            currentSpinSpeed = Mathf.Lerp(spinStartSpeed, spinUpSpeed, t / spinUpTime);
            t += Time.deltaTime;
            yield return null;
        }
        currentSpinSpeed = spinUpSpeed;

        // Disappear
        spinPsyche = false;
        psycheAsteroid.SetActive(false);

        // Trigger object2
        potato.SetActive(true);
        spinPotato = true;

        // Decelerate
        t = 0;
        while (t < spinDownTime)
        {
            currentSpinSpeed = Mathf.Lerp(spinUpSpeed, spinStartSpeed, t / spinDownTime);
            t += Time.deltaTime;
            yield return null;
        }
        currentSpinSpeed = spinStartSpeed;
        spinPotato = false;
        // Activate new UI
        infoText.SetActive(true);
        simpleText.SetActive(true);
        disclaimerText.SetActive(true);
        backButton.gameObject.SetActive(true);
    }

    void Update()
    {
        if (spinPsyche && psycheAsteroid.activeSelf)
        {
            psycheAsteroid.transform.Rotate(Vector3.up, currentSpinSpeed * Time.deltaTime);
        }

        if (spinPotato && potato.activeSelf)
        {
            potato.transform.Rotate(Vector3.up, currentSpinSpeed * Time.deltaTime);
        }
        if (spinCamera)
        {
            cameraPivot.Rotate(Vector3.up, orbitSpeed * Time.deltaTime);
        }
    }
}
