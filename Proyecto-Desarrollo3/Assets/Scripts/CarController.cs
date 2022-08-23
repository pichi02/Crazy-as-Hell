using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    [SerializeField] private Rigidbody sphereRb;

    [SerializeField] private float forwardAccel = 8f, reverseAccel = 4f, maxSpeed = 50f, turnStrength = 180f, gravityForce = 10f, dragOnground = 3f;

    private float speedInput;

    private bool grounded;

    [SerializeField] private LayerMask whaIsGround;

    [SerializeField] private float groundRayLength = 1f;

    [SerializeField] private Transform groundRayPoint;

    private void Start()
    {
        sphereRb.transform.parent = null;
    }
    private void Update()
    {
        Debug.DrawRay(groundRayPoint.position, -transform.up, Color.red);

        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        speedInput = 0f;
        if (verticalInput > 0)
        {
            speedInput = verticalInput * forwardAccel * 4000;
        }
        else
        {
            if (verticalInput < 0)
            {
                speedInput = verticalInput * reverseAccel * 2000;
            }
        }

        if (grounded)
        {
            transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles + new Vector3(0, horizontalInput * turnStrength * Time.deltaTime * verticalInput, 0f));
        }


        transform.position = sphereRb.transform.position;
    }

    private void FixedUpdate()
    {
        grounded = false;
        RaycastHit hit;

        if (Physics.Raycast(groundRayPoint.position, -transform.up, out hit, groundRayLength, whaIsGround))
        {
            grounded = true;
            transform.rotation = Quaternion.FromToRotation(transform.up, hit.normal) * transform.rotation;
        }

        if (grounded)
        {
            sphereRb.drag = dragOnground;
            if (Mathf.Abs(speedInput) > 0)
            {
                sphereRb.AddForce(transform.forward * speedInput);
            }
        }
        else
        {
            //sphereRb.drag = 0.1f;
            //sphereRb.AddForce(Vector3.up * -gravityForce * 100f);
        }


    }
}
