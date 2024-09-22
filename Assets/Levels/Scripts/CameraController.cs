using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private float cameraSpeed;
    private float currentPositionX;
    private Vector3 velocity = Vector3.zero;

    private void Update()
    {
        transform.position = Vector3.SmoothDamp(transform.position, new Vector3(currentPositionX, transform.position.y, transform.position.z),
            ref velocity, cameraSpeed);
    }

    public void MoveCamera(Transform _newRoom)
    {
        currentPositionX = _newRoom.position.x;
    }
}
