using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour {
    private CharacterController controller;

    [SerializeField] private float movementSpeed = 5.0f;
    [SerializeField] private AnimationCurve jumpCurve; // used to control upward force
    [SerializeField] private float jumpFactor = 5.0f;

    private bool isJumping;

    private void Awake() {
        controller = GetComponent<CharacterController>();
    }

    private void Update() {
        // movement
        float horizontal = Input.GetAxis("Horizontal") * movementSpeed;
        float vertical = Input.GetAxis("Vertical") * movementSpeed;

        Vector3 forwardMovement = transform.forward * vertical;
        Vector3 rightMovement = transform.right * horizontal;

        controller.SimpleMove(forwardMovement + rightMovement);

        // jumping
        /*if (Input.GetButtonDown("Shoot")) {
            //isJumping = true;
            StartCoroutine(Shoot());
        }*/
    }

    //private IEnumerator Shoot() {
//
  //  }
}
