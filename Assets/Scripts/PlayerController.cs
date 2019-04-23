using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerController : MonoBehaviour
{

    float xThrow;
    float yThrow;
    bool isControlEnabled = true;
    [Header("General")]
    [Tooltip("In meters per sec")][SerializeField] float controlSpeed = 4f;
    [Tooltip("In meters per sec")] [SerializeField] float xRange = 4f;
    [Tooltip("In meters per sec")] [SerializeField] float yRange = 2f;
    [SerializeField] GameObject[] guns;

    [Header("Screen-Position Based")]
    [SerializeField] float positionPitchFactor = -5f;
    [SerializeField] float positionYawFactor = 5f;

    [Header("Control-throw Based")]
    [SerializeField] float controlPitchFactor = -20f;
    [SerializeField] float controlRollFactor = -20f;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(isControlEnabled)
        {
            ProcessTranslation();
            ProcessRotation();
            ProcessFiring();
        }


    }

    void ProcessRotation()
    {
        float pitchDueToPosition = transform.localPosition.y * positionPitchFactor ;
        float pitchDueToControlThrow = yThrow * controlPitchFactor;
        float pitch = pitchDueToPosition + pitchDueToControlThrow;


        float yaw = (transform.localPosition.x * positionYawFactor); 
        float roll = xThrow * controlRollFactor;

        transform.localRotation = Quaternion.Euler(pitch, yaw, roll);
    }

    void ProcessTranslation()
    {
        float timeDeltaTime = Time.deltaTime;

        xThrow = CrossPlatformInputManager.GetAxis("Horizontal");
        //The xOffset is the spaceship movement per frame
        float xOffset = xThrow * controlSpeed * timeDeltaTime;
        float rawXpos = transform.localPosition.x + xOffset;
        float clampedXpos = Mathf.Clamp(rawXpos, -xRange, xRange);


        yThrow = CrossPlatformInputManager.GetAxis("Vertical");
        float yOffset = yThrow * controlSpeed * timeDeltaTime;
        float rawYpos = transform.localPosition.y + yOffset;
        float clampedYpos = Mathf.Clamp(rawYpos, -yRange, yRange);

        // print("xOffsetThisFrame = "+ xOffset + " = xThrow: " + xThrow + " * xSpeed: "+ xSpeed + " * Time.deltaTime: " + timeDeltaTime);


        transform.localPosition = new Vector3(clampedXpos, clampedYpos, transform.localPosition.z);
    }


    //Call by string reference
    void OnPlayerDeath()
    {
        print("Control frozen");
        isControlEnabled = false;
    }


    void ProcessFiring()
    {
        if(CrossPlatformInputManager.GetButton("Fire"))
            SetGunActive(true);
        else
            SetGunActive(false);
    }

    void SetGunActive(bool isActive)
    {
        foreach (GameObject gun in guns)
        {
           var emissionModule = gun.GetComponent<ParticleSystem>().emission;
            emissionModule.enabled = isActive;
        }
    }

}
