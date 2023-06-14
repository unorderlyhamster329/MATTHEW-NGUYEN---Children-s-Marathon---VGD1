using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RestartButtonManager : MonoBehaviour
{
    public MenuManager menuManager;

    private void Start()
    {
        //Reference the MenuManager
        menuManager = FindObjectOfType<MenuManager>();
        GetComponent<Button>().onClick.AddListener(RestartGame);
    }

    private void RestartGame()
    {
        //Game resets 
        menuManager.RestartGame();
    }
}