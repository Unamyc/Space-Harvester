using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager s_Singleton;

    void awake()
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
}
