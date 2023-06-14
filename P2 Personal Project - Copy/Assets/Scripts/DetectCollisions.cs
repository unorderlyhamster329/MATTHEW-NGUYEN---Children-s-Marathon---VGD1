using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectCollisions : MonoBehaviour
{
    public MenuManager menuManager;

    private void Start()
    {
        //Reference the MenuManager
        menuManager = FindObjectOfType<MenuManager>();
    }

    private void OnCollisionEnter(Collision collision)
    {     
        //If player dies, Call a function to handle player death
        if (collision.gameObject.CompareTag("Car"))
        {
          
            PlayerDied();
        }
    }

    private void PlayerDied()
    {
        //Disable or destroy the player object
        gameObject.SetActive(false);

        //Call the PlayerDied method in the MenuManager
        menuManager.PlayerDied();
    }
}