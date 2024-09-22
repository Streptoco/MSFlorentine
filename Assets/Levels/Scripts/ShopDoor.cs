using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopDoor : MonoBehaviour
{
    [SerializeField] private Transform previousRoom;
    [SerializeField] private Transform nextRoom;
    [SerializeField] private CameraController cameraController;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            if(other.transform.position.x < transform.position.x) {
                cameraController.MoveCamera(nextRoom);
            }
            else
            {
                cameraController.MoveCamera(previousRoom);
            }
        }
    }
}
