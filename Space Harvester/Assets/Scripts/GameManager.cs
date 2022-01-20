using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager s_Singleton;
    public List<GameObject> listOfCemetry;

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

            UIManager.s_Singleton.ShowMenu();

            Debug.Log(playerName + " a gagné !");
        }
    }

    public void RestartGame()
    {
        for (int i = 0; i < listOfCemetry.Count; i++)
        {
            listOfCemetry[i].GetComponent<Cemetery>().Respawn();
        }
    }
}
