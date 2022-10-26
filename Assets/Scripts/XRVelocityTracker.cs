using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class XRVelocityTracker : MonoBehaviour
{
    [SerializeField] private InputActionProperty velocityInput;

    // Update is called once per frame
    void Update()
    {
        Debug.Log(velocityInput.action.ReadValue<Vector3>());
    }
}
