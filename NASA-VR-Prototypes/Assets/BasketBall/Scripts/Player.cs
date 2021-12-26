using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Ball ball;
    public GameObject playerCamera;

    public float ballDistance = 1f;
    public float ballThrowingForce = 5f;

    public bool holdingBall = true;
    public Vector3 ballPosition;

    // Start is called before the first frame update
    void Start()
    {
        ball.GetComponent<Rigidbody>().useGravity = false;
    }

    // Update is called once per frame
    void Update()
    {
        //ballPosition = playerCamera.transform.position
        //        + playerCamera.transform.forward * ballDistance;
        //if (holdingBall)
        //{
        //    ball.transform.position = ballPosition;

        //    if (Input.GetMouseButtonDown(0))
        //    {
        //        holdingBall = false;
        //        ball.GetComponent<Rigidbody>().useGravity = true;
        //        ball.GetComponent<Rigidbody>().AddForce(playerCamera.transform.forward * ballThrowingForce);
        //    }
        //}
    }
}
