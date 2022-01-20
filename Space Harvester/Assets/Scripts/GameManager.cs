using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager s_Singleton;
    private bool _gameIsOver = false;

    void Awake()
    {
        if(s_Singleton = null)
        {
            s_Singleton = this;
        }
        else
        {
            Destroy(this);
        }
    }

    public void DeclareAWinner(string playerName)
    {
        if (!_gameIsOver)
        {
            _gameIsOver = true;
            Debug.Log(playerName + " a gagné !");
        }
    }
}
