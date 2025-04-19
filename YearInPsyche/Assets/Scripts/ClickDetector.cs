using UnityEngine;
using System;
using System.Runtime.InteropServices;
using System.Collections;
using TMPro;

//using System.Diagnostics;

public class ClickDetector : MonoBehaviour
{

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // Left-click
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                Debug.Log("Clicked on: " + hit.collider.gameObject.name);
               
                GameObject psyche = GameObject.Find("Psyche");
                GameObject f22_raptor = GameObject.Find("Jet");
                GameObject earth = GameObject.Find("Earth");
                //Canvas canvas = GetComponent<Canvas>();
                Canvas canvas = GetComponentInChildren<Canvas>();
                TextMeshProUGUI text = canvas.GetComponentInChildren<TextMeshProUGUI>();
                if (hit.collider.gameObject.name == "Psyche")
                {
                    OnPsycheClicked(psyche, f22_raptor, earth, canvas, text);
                }
                else if (hit.collider.gameObject.name == "Jet")
                {
                    OnF22Clicked(psyche, f22_raptor, earth, canvas, text);
                }
            }
        }
    }

   

    void OnPsycheClicked(GameObject psyche, GameObject f22_raptor, GameObject earth, Canvas canvas, TextMeshProUGUI text)
    {
        //Debug.Log("Psyche asteroid selected!");
        canvas.gameObject.SetActive(false);
        GetComponent<Animator>().enabled = true;
        f22_raptor.GetComponent<Animator>().enabled = false;

        var psycheOrbit = psyche.GetComponent<OrbitalMotion>();
        var psychePath = psyche.GetComponent<PathRenderer>();
        var psycheLine = psyche.GetComponent<LineRenderer>();

        var f22Orbit = f22_raptor.GetComponent<OrbitalMotion>();
        var f22Path = f22_raptor.GetComponent<PathRenderer>();
        var f22Line = f22_raptor.GetComponent<LineRenderer>();

        var earthOrbit = earth.GetComponent<OrbitalMotion>();
        var earthPath = earth.GetComponent<PathRenderer>();
        var earthLine = earth.GetComponent<LineRenderer>();


        // Enable Psyche orbit and path
        psycheOrbit.enabled = true;
        psychePath.enabled = true;

        // Enable F-22 orbit and path
        f22Orbit.enabled = true;
        f22Path.enabled = true;
        f22Line.enabled = true;

        // Enable Earth orbit and path
        earthOrbit.enabled = true;
        earthPath.enabled = true;

        StartCoroutine(textDisplay(canvas, text, earthLine, psycheLine));

    }

    void OnF22Clicked(GameObject psyche, GameObject f22_raptor, GameObject earth, Canvas canvas, TextMeshProUGUI text)
    {
        //Debug.Log("Psyche asteroid selected!");
        canvas.gameObject.SetActive(false);
        GetComponent<Animator>().enabled = true;

        f22_raptor.GetComponent<Animator>().enabled = false;

        var psycheOrbit = psyche.GetComponent<OrbitalMotion>();
        var psychePath = psyche.GetComponent<PathRenderer>();
        var psycheLine = psyche.GetComponent<LineRenderer>();

        var f22Orbit = f22_raptor.GetComponent<OrbitalMotion>();
        var f22Path = f22_raptor.GetComponent<PathRenderer>();
        var f22Line = f22_raptor.GetComponent<LineRenderer>();


        var earthOrbit = earth.GetComponent<OrbitalMotion>();
        var earthPath = earth.GetComponent<PathRenderer>();
        var earthLine = earth.GetComponent<LineRenderer>();

        // Enable Psyche orbit and path
        psycheOrbit.enabled = true;
        psychePath.enabled = true;

        // Enable F-22 orbit and path
        f22Orbit.enabled = true;
        f22Path.enabled = true;
        f22Line.enabled = true;

        // Enable Earth orbit and path
        earthOrbit.enabled = true;
        earthPath.enabled = true;

        StartCoroutine(textDisplay(canvas, text, earthLine, psycheLine));
    }

    String txt = "The Raptor F-22 reaches astonishing speeds exceeding Mach 2.0 with afterburners engaged,";
    String txt2 = "That’s equivalent to an impressive 340 meters per second.";
    String txt3 = "Yet, Psyche’s average orbital speed is around 17.34 kilometers per second — over six times the speed of sound in space.";
    String txt4 = "Even Earth moves faster, orbiting the Sun at approximately 29.78 kilometers per second — about 70% faster than Psyche.";
    String txt5 = "So, even if you come last in a race on Earth, take comfort: you’re still hurtling through space faster than an asteroid.";


    IEnumerator textDisplay(Canvas canvas, TextMeshProUGUI text, LineRenderer earth, LineRenderer psyche)
    {
        RectTransform rectTransform = text.GetComponent<RectTransform>();

        // Set text alignment to top-right
        text.alignment = TextAlignmentOptions.TopRight;
        text.fontSize = 10f;
        text.text = txt;
        canvas.gameObject.SetActive(true);  // 5 seconds into the animatio
        yield return new WaitForSeconds(10f);

        text.text = "";
        //canvas.gameObject.SetActive(false);
        yield return new WaitForSeconds(2f);

        text.text = txt2;
        //canvas.gameObject.SetActive(true);
        yield return new WaitForSeconds(5f);

        text.text = "";
        //canvas.gameObject.SetActive(false);
        yield return new WaitForSeconds(2f);

        text.text = txt3;
        GetComponent<Animator>().SetTrigger("OrbitRace");
        //canvas.gameObject.SetActive(true);
        yield return new WaitForSeconds(10f);

        //canvas.gameObject.SetActive(false);
        text.text = "";
        earth.startWidth = 2f;
        psyche.endWidth = 2f;
        yield return new WaitForSeconds(2f);

        text.alignment = TextAlignmentOptions.TopLeft;

        text.text = txt4;
        yield return new WaitForSeconds(10f);
        text.text = "";
        yield return new WaitForSeconds(2f);

        text.text = txt5;
        yield return new WaitForSeconds(10f);
        text.text = "";
        yield return new WaitForSeconds(2f);

    }


}
