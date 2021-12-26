using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

[RequireComponent(typeof(XRRig), typeof(CharacterController))]
public class ContinuousMovement : MonoBehaviour
{
    [SerializeField] private XRNode inputSource;
    [SerializeField] [Range(0, 50)] private float moveSpeed = 1;
    [SerializeField] private float gravityStrength = -9.81f;
    [Tooltip("The character controller gets the height to the player's eyes, not the top of their head." +
        "This is basically how tall the player's forehead is, in meters (roughly).")]
    [SerializeField] private float extraHeight = 0.2f;

    private Vector2 inputAxis;
    private Vector3 moveDir;
    private Vector3 centerEstimate;
    private float currentFallSpeed;
    private InputDevice sourceDevice;
    private CharacterController playerController;
    private XRRig playerRig;

    private void Start()
    {
        playerController = GetComponent<CharacterController>();
        playerRig = GetComponent<XRRig>();
    }

    private void Update()
    {
        sourceDevice = InputDevices.GetDeviceAtXRNode(inputSource);
        sourceDevice.TryGetFeatureValue(CommonUsages.primary2DAxis, out inputAxis);
    }

    private void FixedUpdate()
    {
        playerController.height = playerRig.cameraInRigSpaceHeight + extraHeight;

        //Estimate the player's "center" by locating their camera's position on the XZ, then halve their current height to find the Y.
        centerEstimate = transform.InverseTransformPoint(playerRig.cameraGameObject.transform.position);
        centerEstimate.y = playerController.height / 2 + playerController.skinWidth;
        playerController.center = centerEstimate;

        //inputAxis returns normalized/local directions. Use the player's camera to turn that direction into a world space direction, so
        //if axis = (0,1), moveDir = playercam.transform.forward.
        moveDir = playerRig.cameraGameObject.transform.TransformDirection(inputAxis.x, 0, inputAxis.y).normalized;
        playerController.Move(moveDir * moveSpeed * Time.fixedDeltaTime);

        //If grounded, set current fall speed to 0. Otherwise, make it speed up over time.
        currentFallSpeed = playerController.isGrounded ? 0 : currentFallSpeed + gravityStrength * Time.fixedDeltaTime;
        playerController.Move(Vector3.up * currentFallSpeed * Time.fixedDeltaTime);
    }
}
