using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseManager : MonoBehaviour
{
    [Header("Mouse Info")]
    public Vector3 clickStartLocation;

    [Header("Physics")]
    public Vector3 launchVector;

    public float launchForce;

    [Header("Slime")]
    public Transform slimeTransform;
    public Rigidbody slimeRigidbody;

    public Vector3 originalSlimePosition;
    public Quaternion SlimeRotation;
    // Start is called before the first frame update
    void Start()
    {
        originalSlimePosition = slimeTransform.position;
        SlimeRotation = slimeTransform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            clickStartLocation = Input.mousePosition;
            //slimeTransform.position = originalSlimePosition - launchVector;

        }
        if (Input.GetMouseButton(0))
        {
            slimeRigidbody.isKinematic = true;
            Vector3 mouseDifference = clickStartLocation - Input.mousePosition;
            launchVector = new Vector3(
                mouseDifference.y * 1f,
                mouseDifference.y * 1.2f,
                mouseDifference.x * -1.5f
            );
            slimeTransform.position = originalSlimePosition - launchVector / 1000; //2000
            launchVector.Normalize();

            //Vector2 launchForce = new Vector3(50000, 1000, 50000);
            //slimeRigidbody.AddForce(mouseDifference * 10);
        }
        /*if (Input.GetMouseButtonUp(0))
        {
            slimeRigidbody.isKinematic = false;
            Vector2 launchForce = new Vector3(50000, 1000, 50000);
            slimeRigidbody.AddForce(launchForce);
        }*/
        if (Input.GetMouseButtonUp(0))
        {
            slimeRigidbody.isKinematic = false;
            //slimeRigidbody.AddForce(launchVector * launchForce);
           slimeRigidbody.AddForce(launchVector * launchForce, ForceMode.Impulse);
            Debug.Log(launchVector * launchForce);
        }
        if (Input.GetMouseButtonDown(1))
        {
            slimeTransform.position = originalSlimePosition;
            slimeTransform.rotation = SlimeRotation;
        }
    }
}
