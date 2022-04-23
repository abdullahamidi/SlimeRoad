using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHorizontalMovement : MonoBehaviour
{
    [SerializeField]
    private float horSpeed = 5.0f;
    [SerializeField]
    DynamicJoystick joystick;
    [SerializeField]
    ObjectBoundaries objectBoundaries;
    float leftPlatformBound = 0f;
    float rightPlatformBound = 0f;
    // Start is called before the first frame update
    void Start()
    {
        leftPlatformBound = -objectBoundaries.PlatformBoundarySize.z / 2 + transform.localScale.z / 2;
        rightPlatformBound = objectBoundaries.PlatformBoundarySize.z / 2 - transform.localScale.z / 2;
        enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        var direction = joystick.Horizontal;
        var horizontal = direction * horSpeed * Time.deltaTime * Vector3.forward;
        if (transform.position.z + horizontal.z < rightPlatformBound && transform.position.z + horizontal.z > leftPlatformBound)
        {
            transform.position += horizontal;
        }
    }
}
