using System.Collections;
using System.Collections.Generic;

#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;

public class CarController : MonoBehaviour
{
    [SerializeField] private Rigidbody motorRB;

    [SerializeField] private float forwardAccel = 8f, reverseAccel = 4f, maxSpeed = 50f, turnStrength = 180f, gravityForce = 10f, dragOnGround = 3f;

    public float speedInput, turnInput;

    private bool grounded;

    [SerializeField] private float safeZone = 20f;

    [SerializeField] private LayerMask whatIsGround;
    [SerializeField] private float groundRayLength = 0.5f;
    [SerializeField] private Transform groundRayPoint;

    [SerializeField] private Transform leftFrontWheel, rightFrontWheel;
    [SerializeField] private float maxWheelTurn = 25f;

    // Start is called before the first frame update
    void Start()
    {
        motorRB.transform.parent = null;
    }

    // Update is called once per frame
    void Update()
    {
        speedInput = 0f;

        if (Input.GetAxis("Vertical") > 0)
        {
            speedInput = Input.GetAxis("Vertical") * forwardAccel * 1000f;
        }
        else if (Input.GetAxis("Vertical") < 0)
        {
            //speedInput = Input.GetAxis("Vertical") * reverseAccel * 1000f;
        }

        turnInput = Input.GetAxis("Horizontal");

        if (grounded)
        {
            transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles + new Vector3(0f, turnInput * turnStrength * Time.deltaTime * Input.GetAxis("Vertical"), 0f));
        }

        leftFrontWheel.localRotation = Quaternion.Euler(leftFrontWheel.localRotation.eulerAngles.x, (turnInput * maxWheelTurn) - 180, leftFrontWheel.localRotation.eulerAngles.z);
        rightFrontWheel.localRotation = Quaternion.Euler(rightFrontWheel.localRotation.eulerAngles.x, turnInput * maxWheelTurn, rightFrontWheel.localRotation.eulerAngles.z);

        Vector3 newPos = motorRB.transform.position - transform.forward * 1.5f;
        newPos.y -= 0.7f;
        transform.position = newPos;

    }

    private void FixedUpdate()
    {
        grounded = false;
        RaycastHit hit;

        if (Physics.Raycast(groundRayPoint.position, Vector3.down, out hit, groundRayLength, whatIsGround))
        {
            grounded = true;

            transform.rotation = Quaternion.FromToRotation(transform.up, hit.normal) * transform.rotation;
        }

        if (grounded)
        {
            motorRB.drag = dragOnGround;

            if (Mathf.Abs(speedInput) > 0)
            {
                motorRB.AddForce(transform.forward * speedInput);
            }
        }
        else
        {
            motorRB.drag = 0.1f;

            motorRB.AddForce(Vector3.up * -gravityForce * 100f);
        }
    }
    public float SafeZone => safeZone;

#if UNITY_EDITOR
    private void OnDrawGizmosSelected()
    {
        Handles.color = Color.red;

        Handles.DrawWireDisc(transform.position, Vector3.up, safeZone);
    }
#endif
}
