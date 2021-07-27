using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 2021.7.27
/// </summary>

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed;

    Vector3 movementVector = Vector3.right;

    // Update is called once per frame
    void Update()
    {
        MoveMentControl();
    }

    private void MoveMentControl()
    {
        if(Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.UpArrow))
        if(movementVector == Vector3.right)
        {
            movementVector = Vector3.forward;
        }
        else
        {
            movementVector = Vector3.right;
        }
        transform.position = transform.position + movementVector * moveSpeed * Time.deltaTime;
    }
}
