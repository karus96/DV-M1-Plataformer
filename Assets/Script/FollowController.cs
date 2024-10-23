using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowController : MonoBehaviour
{
    //========================================================================================
    // Variables
    //========================================================================================
    public Transform _target;
    public Vector3 _offset;
    public float _smoothSpeed = 0.125f;
    public bool _setZ;

    //========================================================================================
    // Methods
    //========================================================================================
    private void LateUpdate()
    {
        if (_target)
        {
            Vector3 desiredPosition = _target.position + _offset;
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, _smoothSpeed);
            if (_setZ)
            {
                smoothedPosition.z = -10;
            }
            else
            {
                smoothedPosition.z = 0;
            }
            transform.position = smoothedPosition;
        }
    }
    //========================================================================================
}
