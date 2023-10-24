using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private bool moveOnX, moveOnY;
    [SerializeField] private bool moveLeft;
    [SerializeField] private bool moveUp = false;
    [SerializeField] private float moveSpeed = 8f;
    [SerializeField] private float horizontalMovementThreshold = 8f;
    [SerializeField] private float verticalMovementThreshold = 6f;

    private float minX, maxX;
    private float minY, maxY;

    private Vector3 tempMovementHorizontal, tempMovementVertical;

    private void Start()
    {
        minX = transform.position.x - horizontalMovementThreshold;
        maxX = transform.position.x + horizontalMovementThreshold;

        minY = transform.position.y - verticalMovementThreshold;
        maxY = transform.position.y;

        if (Random.Range(0, 2) > 0)
        {
            moveLeft = true;
        }
    }

    private void Update()
    {
        HandleEnemyHorizontalMovement();
        HandleEnemyVerticalMovement();
    }

    void HandleEnemyHorizontalMovement()
    {
        if (!moveOnX)
            return;

        if (moveLeft)
        {
            tempMovementHorizontal = transform.position;
            tempMovementHorizontal.x -= moveSpeed * Time.deltaTime;
            transform.position = tempMovementHorizontal;

            if (tempMovementHorizontal.x < minX)
            {
                moveLeft = false;
            }
        }
        else
        {
            tempMovementHorizontal = transform.position;
            tempMovementHorizontal.x += moveSpeed * Time.deltaTime;
            transform.position = tempMovementHorizontal;

            if (tempMovementHorizontal.x > maxX)
            {
                moveLeft = true;
            }
        }
    }

    void HandleEnemyVerticalMovement()
    {

    }
}
