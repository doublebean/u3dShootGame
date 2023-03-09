using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public static class Utilities
{
    public static int playerDeaths = 0;

    public static void RestarLevel()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1.0f;

        Debug.Log("Player deaths:" + playerDeaths);
        string message = UpdateDeathCount( ref playerDeaths);//试用一下ref关键字，将参数转化为引用类型
        Debug.Log("Player deaths:" + playerDeaths);
    }

    public static bool RestarLevel(int sceneIndex)
    {
        
        if(sceneIndex < 0)//抛出异常
        {
            throw new System.ArgumentOutOfRangeException("Scene index can not be negative!!!");
        }
        
        SceneManager.LoadScene(sceneIndex);
        Time.timeScale = 1.0f;

        return true;
    }

    public static string UpdateDeathCount(ref int countReference)
    {
        countReference++;

        return "Next time you'll be at number " + countReference;
    }

}

   

