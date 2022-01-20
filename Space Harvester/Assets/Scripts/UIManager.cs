using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager s_Singleton;

    public GameObject Menu;

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

    public void RestartGame()
    {
        GameManager.s_Singleton.RestartGame();
        Menu.SetActive(false);
    }

    public void ShowMenu()
    {
        Menu.SetActive(true);
    }
}
