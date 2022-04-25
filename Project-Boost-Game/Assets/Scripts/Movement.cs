using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    Rigidbody rb;
    [SerializeField] float thrustPower;
    [SerializeField] float rotateAmount;
    [SerializeField] ParticleSystem leftSideParticle;
    [SerializeField] ParticleSystem rightSideParticle;
    [SerializeField] ParticleSystem boosterParticle;
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
            if(!boosterParticle.isPlaying){
                boosterParticle.Play();
            }
        }
        else
        {
            if(boosterParticle.isPlaying){
                boosterParticle.Stop();
            }
        }
    }
    private void ProcessRotation()
    {
        if(Input.GetKey(KeyCode.A))
        {
            ApplyRotation(rotateAmount);
            
            if(!rightSideParticle.isPlaying){
                rightSideParticle.Play();
            }
            leftSideParticle.Stop();

            Debug.Log("Left Rotated");
        }

        else if(Input.GetKey(KeyCode.D))
        {
            ApplyRotation(-rotateAmount);
            
            if(!leftSideParticle.isPlaying){
              leftSideParticle.Play();
            }
            rightSideParticle.Stop();

            Debug.Log("Right Rotated");
        }
        else
        {
            leftSideParticle.Stop();
            rightSideParticle.Stop();
        }
    }

    private void ApplyRotation(float rotationThisFrame)
    {
        rb.freezeRotation = true; // freeze rotation so we can manually rotate
        transform.Rotate(Vector3.forward * rotationThisFrame * Time.deltaTime);
        rb.freezeRotation = false; // unfreezing rotation so the physics system can take over
    }
}
