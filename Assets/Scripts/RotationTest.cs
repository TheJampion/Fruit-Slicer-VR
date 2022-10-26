using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationTest : MonoBehaviour
{
    public Transform pointCube;
    void Start()
    {
        float yAxisAngle = Vector3.Angle(transform.up, pointCube.transform.right);
        pointCube.transform.up = transform.forward;
        pointCube.rotation = Quaternion.AngleAxis(-yAxisAngle, pointCube.transform.up);

    }
}
