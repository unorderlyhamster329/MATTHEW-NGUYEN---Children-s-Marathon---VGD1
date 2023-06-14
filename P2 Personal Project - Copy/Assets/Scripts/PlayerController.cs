using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public bool canMove = true;
    public GameObject restartButton;
    private float horizontalInput;
    private float verticalInput;
    public float speed = 10;
    public float xRange = 10;

    private void Start()
    {
        //When game starts, disable restart button
        restartButton.SetActive(false);
    }

    private void Update()
    {
        //Player won't move if 'canMove' is false
        if (!canMove)
            return;

        //Set boundary constraints for player
        if (transform.position.x < -xRange)
            transform.position = new Vector3(-xRange, transform.position.y,transform.position.z);
        if (transform.position.x > xRange)
            transform.position = new Vector3(xRange, transform.position.y, transform.position.z);

        //Player moves horizontally
        horizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.right * horizontalInput * Time.deltaTime * speed);
    }

    private void OnCollisionEnter(Collision collision)
    {   
        //Player can't move if collided with a car. Restart button is enabled
        if (collision.gameObject.CompareTag("Car"))
        {
            canMove = false;
            restartButton.SetActive(true);
        }
    }
}