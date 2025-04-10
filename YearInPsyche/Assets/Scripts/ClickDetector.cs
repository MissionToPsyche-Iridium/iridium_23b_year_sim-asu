using UnityEngine;
using System;
//using System.Diagnostics;

public class ClickDetector : MonoBehaviour
{
    public Animator jet;
    public Animator cam;

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
                GameObject canvas = GameObject.Find("Canvas");
                Animator canvasAnimator = canvas.GetComponent<Animator>();

                if (hit.collider.gameObject.name == "Psyche")
                {
                    OnPsycheClicked(psyche, f22_raptor, earth, canvasAnimator);
                }
                else if (hit.collider.gameObject.name == "Jet")
                {
                    OnF22Clicked(psyche, f22_raptor, earth, canvasAnimator);
                }
            }
        }
    }

    void OnPsycheClicked(GameObject psyche, GameObject f22_raptor, GameObject earth, Animator canvasAnimator)
    {
        //Debug.Log("Psyche asteroid selected!");

        var psycheOrbit = psyche.GetComponent<OrbitalMotion>();
        var psychePath = psyche.GetComponent<PathRenderer>();

        var f22Orbit = f22_raptor.GetComponent<OrbitalMotion>();
        var f22Path = f22_raptor.GetComponent<PathRenderer>();

        var earthOrbit = earth.GetComponent<OrbitalMotion>();
        var earthPath = earth.GetComponent<PathRenderer>();

        // Enable Psyche orbit and path
        psycheOrbit.enabled = true;
        psychePath.enabled = true;

        // Enable F-22 orbit and path
        f22Orbit.enabled = true;
        f22Path.enabled = true;

        // Enable Earth orbit and path
        earthOrbit.enabled = true;
        earthPath.enabled = true;

        if (jet != null)
        {
            jet.enabled = false;
        }
        if (cam != null)
        {
            cam.enabled = true;
        }
        if (canvasAnimator != null)
        {
            canvasAnimator.SetTrigger("RaceOrbit");
        }
    }

    void OnF22Clicked(GameObject psyche, GameObject f22_raptor, GameObject earth, Animator canvasAnimator)
    {
        // Debug.Log("F-22 Raptor selected!");
        if (jet != null)
        {
            jet.enabled = false;
        }
        if (cam != null)
        {
            cam.enabled = true;
        }
    }
    }
