using System;
//using System.Diagnostics;
using UnityEngine;

public class CameraFollowObj : MonoBehaviour
{
    public Transform obj;  
    public float distance = 10f;  
    public float rotationSpeed = 50f;  
    public float smoothSpeed = 5f;  
    public float minDistance = 0.1f; 
    public float maxDistance = 20f;  
    public bool move = false;  

    private Vector3 offset;  
    private float currentHorizontalAngle = 0f;  
    private float currentVerticalAngle = 0f;  

    void Start()
    {
        if (obj != null)
        {
            offset = new Vector3(0, 0, -distance);  
        }
        else
        {
            Debug.LogError("Object is not assigned!");
        }
    }

    void Update()
    {
        if (obj == null) return;

        if (move)
        {
            float horizontal = Input.GetAxis("Horizontal") * rotationSpeed * Time.deltaTime;
            float vertical = Input.GetAxis("Vertical") * rotationSpeed * Time.deltaTime;

            currentHorizontalAngle += horizontal;
            currentVerticalAngle -= vertical;

            currentVerticalAngle = Mathf.Clamp(currentVerticalAngle, -80f, 80f);

            float scroll = Input.GetAxis("Mouse ScrollWheel");
            if (scroll != 0f)
            {
                distance = Mathf.Clamp(distance - scroll * 5f, minDistance, maxDistance);
            }

            Quaternion rotation = Quaternion.Euler(currentVerticalAngle, currentHorizontalAngle, 0);

            offset = rotation * new Vector3(0, 0, -distance);

            Vector3 desiredPosition = obj.position + offset;

            transform.position = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed * Time.deltaTime);

            transform.LookAt(obj.position);
        }
        else
        {

            offset = obj.rotation * new Vector3(0, 0, -distance);

            Vector3 desiredPosition = obj.position + offset;

            transform.position = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed * Time.deltaTime);

            transform.LookAt(obj.position);
        }
    }
}
