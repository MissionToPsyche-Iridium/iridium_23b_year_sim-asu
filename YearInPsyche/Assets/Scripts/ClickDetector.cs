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
                

                if (hit.collider.gameObject.name == "Psyche")
                {
                    OnPsycheClicked();
                }
                else if (hit.collider.gameObject.name == "Jet")
                {
                    OnF22Clicked();
                }
            }
        }
    }

    void OnPsycheClicked()
    {
        //Debug.Log("Psyche asteroid selected!");
        if (jet != null)
        {
            jet.SetTrigger("OrbitRace");
        }
        if (cam != null)
        {
            cam.enabled = true;
        }
    }

    void OnF22Clicked()
    {
        // Debug.Log("F-22 Raptor selected!");
        if (jet != null)
        {
            jet.SetTrigger("OrbitRace");
        }
        if (cam != null)
        {
            cam.enabled = true;
        }
    }
    }
