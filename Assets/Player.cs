using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
public class Player : MonoBehaviour
{
    [Tooltip("In meters per sec")][SerializeField] float xRange = 4f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float timeDeltaTime = Time.deltaTime;

        float xThrow = CrossPlatformInputManager.GetAxis("Horizontal");
        float xOffset = xThrow * xRange * timeDeltaTime;
        float rawXpos = transform.localPosition.x + xOffset;
        float clampedXpos = Mathf.Clamp(rawXpos, -xRange, xRange);

       // print("xOffsetThisFrame = "+ xOffset + " = xThrow: " + xThrow + " * xSpeed: "+ xSpeed + " * Time.deltaTime: " + timeDeltaTime);


        transform.localPosition = new Vector3(clampedXpos, transform.localPosition.y, transform.localPosition.z);

    }
}
