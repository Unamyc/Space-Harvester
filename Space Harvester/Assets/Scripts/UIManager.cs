using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager s_Singleton;

    public GameObject Menu;

    private GameManager _gameManager;

    private void Awake()
    {
        if(s_Singleton != null)
        {
            Destroy(this);
        }
        else
        {
            s_Singleton = this;
        }
    }

    public void Start()
    {
        _gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    public void RestartGame()
    {
        _gameManager.RestartGame();
        Menu.SetActive(false);
    }

    public void ShowMenu()
    {
        Menu.SetActive(true);
    }
}
