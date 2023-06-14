using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
  public Transform target; //Reference to the player object
    public Vector3 offset = new Vector3(0f, 2f, -5f); //Offset values to position the camera relative to the player
    public float rotationSpeed = 5f; //Speed of camera rotation
    public float damping = 1f; //Smoothness of camera movement

    private void LateUpdate()
    {
        if (target != null)
        {
            //Calculate the desired position and rotation of the camera
            Vector3 desiredPosition = target.position + offset;
            Quaternion desiredRotation = Quaternion.LookRotation(target.position - transform.position, target.up);

            //Smoothly move the camera towards the desired position and rotation
            transform.position = Vector3.Lerp(transform.position, desiredPosition, Time.deltaTime * damping);
            transform.rotation = Quaternion.Slerp(transform.rotation, desiredRotation, Time.deltaTime * rotationSpeed);
        }
    }
}