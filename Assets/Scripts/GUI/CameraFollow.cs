using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {
    public Transform Follow;

    private Vector3 _offsetFromFollowToCamera;
    private float _initialY;

    void Awake() {
        _offsetFromFollowToCamera = transform.position - Follow.position;
        _initialY = transform.position.y;
    }

    void LateUpdate() {
        var position = Follow.position + _offsetFromFollowToCamera;
        position.y = _initialY;
        transform.position = position;
    }
}
