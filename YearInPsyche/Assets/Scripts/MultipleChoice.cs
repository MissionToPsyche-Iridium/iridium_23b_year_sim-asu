using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MultipleChoice : MonoBehaviour
{
    public GameObject camera1;
    public GameObject camera2;
    public GameObject panel1;
    public GameObject panel2;
    public GameObject panel3;
    public void Start()
    {
        camera1.SetActive(true);
        camera2.SetActive(false);
        panel1.SetActive(true);
        panel2.SetActive(false);
        panel3.SetActive(false);
    }

    // Update is called once per frame
    public void correct()
    {
        camera1.SetActive(false);
        camera2.SetActive(true);
        panel1.SetActive(false);
        panel2.SetActive(true);
    }
    public void incorrect()
    {
        panel1.SetActive(false);
        panel2.SetActive(false);
        panel3.SetActive(true);
    }
}
