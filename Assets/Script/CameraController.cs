using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    //========================================================================================
    // Variables
    //========================================================================================
    public Transform _target;
    public Vector3 _offset;
    public float _smoothSpeed = 0.125f;

    //========================================================================================
    // Methods
    //========================================================================================
    private void LateUpdate()
    {
        if (_target)
        {
            Vector3 desiredPosition = _target.position + _offset;
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, _smoothSpeed);
            smoothedPosition.z = -10;
            transform.position = smoothedPosition;
        }
    }
    //========================================================================================
}
