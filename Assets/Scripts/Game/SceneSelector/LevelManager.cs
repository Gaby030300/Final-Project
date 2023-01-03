using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public static LevelManager instance;

    [SerializeField] int goalToWin;
    public static int currentGoalToWin;

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            currentGoalToWin = 1;
            instance = this;
            DontDestroyOnLoad(this);
        }
    }    

    public void ChargeEasyLevel()
    {
        if (!CheckGlobalWin())
        {
            //Charge a easy level of the prefabs
        }
        else
        {
            //Charge The Level With the win screen
        }
    }

    public void ChargeHardLevel()
    {
        if (!CheckGlobalWin())
        {
            //Charge a hard level of the prefabs
        }
        else
        {
            //Charge The Level With the win screen
        }

    }

    public bool CheckGlobalWin()
    {
        bool PlayerWins;
        return PlayerWins = currentGoalToWin >= goalToWin ? true : false; 
    }

}
