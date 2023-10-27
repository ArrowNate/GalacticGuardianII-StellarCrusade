using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorMovement : MonoBehaviour
{
    [SerializeField] private float minSpeed = 4f, maxSpeed = 10f;
    [SerializeField] private float speedX, speedY;
    [SerializeField] private float minRotationSpeed = 15f, maxRoatationSpeed = 50f;
    [SerializeField] private float rotationSpeed;
    [SerializeField] private float zRotation;
    [SerializeField] private bool moveOnX, moveOnY = true;

    private Vector3 tempMovement;

    private void Awake()
    {
        rotationSpeed = Random.Range(minRotationSpeed, maxRoatationSpeed);

        speedX = Random.Range(minSpeed, maxSpeed);
        speedY = speedX;

        if (Random.Range(0, 2) > 0)
        {
            speedX *= -1f;
        }

        if (Random.Range(0, 2) > 0)
        {
            rotationSpeed *= -1f;
        }

        if (Random.Range(0, 2) > 0)
        {
            moveOnX = true;
        }
    }

    private void Update()
    {
        HandleMovementX();
        HandleMovementY();

        RotateMeteor();
    }

    void HandleMovementX()
    {
        if (!moveOnX)
            return;

        tempMovement = transform.position;
        tempMovement.x += speedX * Time.deltaTime;
        transform.position = tempMovement;
    }

    void HandleMovementY()
    {
        if (!moveOnY)
            return;

        tempMovement = transform.position;
        tempMovement.y -= speedY * Time.deltaTime;
        transform.position = tempMovement;
    }

    void RotateMeteor()
    {
        zRotation += rotationSpeed * Time.deltaTime;
        transform.rotation = Quaternion.AngleAxis(zRotation, Vector3.forward);
    }
}