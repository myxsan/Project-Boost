using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    Rigidbody rb;
    [SerializeField] float thrustPower;
    [SerializeField] float rotateAmount;
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }
    void Start()
    {
    }

    void Update()
    {
        ProcessThrust();
        ProcessRotation();
    }

    private void ProcessThrust()
    {
        if(Input.GetKey(KeyCode.Space))
        {
            Debug.Log("Thrust");
            rb.AddRelativeForce(Vector3.up * thrustPower * Time.deltaTime);
        }
    }
    private void ProcessRotation()
    {
        if(Input.GetKey(KeyCode.A))
        {
            ApplyRotation(rotateAmount);

            Debug.Log("Left Rotated");
        }
        else if(Input.GetKey(KeyCode.D))
        {
            ApplyRotation(-rotateAmount);
            Debug.Log("Right Rotated");
        }
    }

    private void ApplyRotation(float rotationThisFrame)
    {
        rb.freezeRotation = true; // freeze rotation so we can manually rotate
        transform.Rotate(Vector3.forward * rotationThisFrame * Time.deltaTime);
        rb.freezeRotation = false; // unfreezing rotation so the physics system can take over
    }
}
