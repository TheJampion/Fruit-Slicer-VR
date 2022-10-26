using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class SwordSwipeController : MonoBehaviour
{
    [SerializeField] private float horizontalVelocityMinimum;
    [SerializeField] private float verticalVelocityMinimum;
    [SerializeField] private InputActionProperty velocityInput;
    [SerializeField] private float horizontalAngle;
    [SerializeField] private Vector3 originalUpDirection;
    [SerializeField] private float velocityLeinency = 0.2f;

    private void Start()
    {
        originalUpDirection = transform.up;
    }

    public bool IsSwiping()
    {
        float rotationAngle = Vector3.Angle(originalUpDirection, transform.up);
        float horizontalVelocityValue = rotationAngle / horizontalAngle;
        float verticalVelocityValue = Mathf.Abs((rotationAngle - horizontalAngle)) / horizontalAngle;
        Vector3 controllerVelocity = velocityInput.action.ReadValue<Vector3>();
        if ((Mathf.Abs(controllerVelocity.x) >= horizontalVelocityMinimum * horizontalVelocityValue - velocityLeinency)
            && Mathf.Abs(controllerVelocity.y) > verticalVelocityMinimum * verticalVelocityValue - velocityLeinency)
        {
            return true;
        }
        return false;
    }

}
