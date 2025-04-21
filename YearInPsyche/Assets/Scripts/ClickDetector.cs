using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
using System.Collections;
using System.Diagnostics;

public class ClickDetector : MonoBehaviour
{
    private GameObject psyche, f22_raptor, earth;
    private Canvas canvas;
    private Button homeButton;
    private TextMeshProUGUI text;
    private bool coroutinePlaying;

    private void Start()
    {
        psyche = GameObject.Find("Psyche");
        f22_raptor = GameObject.Find("Jet");
        earth = GameObject.Find("Earth");
        coroutinePlaying = false;

        canvas = GetComponentInChildren<Canvas>(true);
        text = canvas.GetComponentInChildren<TextMeshProUGUI>();
        homeButton = canvas.GetComponentInChildren<Button>();

        homeButton.onClick.AddListener(() =>
        {
            if (SceneManager.GetActiveScene().buildIndex != 0)
            {
                SceneManager.LoadScene(0);
            }
        });
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                //Debug.Log("Clicked on: " + hit.collider.gameObject.name);
                if (!coroutinePlaying)
                {
                    text.text = "";
                }
                if (hit.collider.gameObject.name == "Psyche")
                {
                    OnObjectClicked();
                }
                else if (hit.collider.gameObject.name == "Jet")
                {
                    OnObjectClicked();
                }
            }
        }
    }

    void OnObjectClicked()
    {
        if (!coroutinePlaying)
        {
            //canvas.gameObject.SetActive(false);
            GetComponent<Animator>().enabled = true;
            f22_raptor.GetComponent<Animator>().enabled = false;

            ToggleOrbit(psyche, true);
            ToggleOrbit(f22_raptor, true);
            ToggleOrbit(earth, true);

            LineRenderer earthLine = earth.GetComponent<LineRenderer>();
            LineRenderer psycheLine = psyche.GetComponent<LineRenderer>();
        
            coroutinePlaying = true;
            StartCoroutine(PlayNarrationSequence(earthLine, psycheLine));
        }
    }

    void ToggleOrbit(GameObject obj, bool enabled)
    {
        obj.GetComponent<OrbitalMotion>().enabled = enabled;
        obj.GetComponent<PathRenderer>().enabled = enabled;

        LineRenderer line = obj.GetComponent<LineRenderer>();
        if (line != null) line.enabled = enabled;
    }

    IEnumerator PlayNarrationSequence(LineRenderer earthLine, LineRenderer psycheLine)
    {
        text.alignment = TextAlignmentOptions.BottomLeft;
        text.fontSize = 10f;
        homeButton.interactable = true;
        canvas.gameObject.SetActive(true);

        yield return TypeAndWait("The Raptor F-22 reaches astonishing speeds exceeding Mach 2.0...");
        yield return TypeAndWait("That’s equivalent to an impressive 340 meters per second.");
        yield return TypeAndWait("Yet, Psyche’s average orbital speed is around 17.34 kilometers per second.");

        // Trigger animation and line width change at pan-out
        GetComponent<Animator>().SetTrigger("OrbitRace");
        earthLine.startWidth = 2f;
        earthLine.endWidth = 2f;
        psycheLine.startWidth = 2f;
        psycheLine.endWidth = 2f;

        yield return TypeAndWait("Even Earth moves faster, orbiting at approximately 29.78 kilometers per second.");
        yield return TypeAndWait("So, even if you come last in a race on Earth... you're still blazing through space!");
        

        text.alignment = TextAlignmentOptions.TopLeft;
        homeButton.interactable = true;
    }

    IEnumerator TypeAndWait(string line)
    {
        text.text = "";
        foreach (char c in line)
        {
            text.text += c;
            yield return new WaitForSeconds(0.02f);
        }
        yield return new WaitForSeconds(7f);
        text.text = "";
        yield return new WaitForSeconds(1.5f);
    }
}
