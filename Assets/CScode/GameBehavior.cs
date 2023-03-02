using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameBehavior : MonoBehaviour
{
    public string labelText = "Collect all 4items and win your freedom !";
    public int maxItems = 4;

    public bool showWinScreen = false;

    private int _itemsCollected = 0;
    private int _playerLives = 3;

    public int Items//声明收集数量的公共变量
    {
        get { return _itemsCollected; }

        set { 
            _itemsCollected = value;
            Debug.LogFormat("Items : {0}", _itemsCollected);

            if(_itemsCollected >= maxItems)
            {
                showWinScreen = true;
                labelText = "You've found all the 4 items!";

                Time.timeScale = 0f;
            }
            else
            {
                labelText = "Item found , only" + (maxItems - _itemsCollected) + "more and go!";
            }

        }
    }

    public int Lives//声明剩下的血量的公共变量
    {
        get { return _playerLives; }

        set { _playerLives = value;
            Debug.LogFormat("HP : {0}", _playerLives);
        }
    }

    void OnGUI()
    {
        GUI.Box(new Rect(20, 20, 150, 25), "Player Health:" + _playerLives);
        GUI.Box(new Rect(20, 50, 150, 25), "Items Collected:" + _itemsCollected);
        GUI.Label(new Rect(Screen.width/3  , Screen.height - 50, 300, 50),labelText);

        if(showWinScreen)
        {
            if(GUI.Button(new Rect(Screen.width/2 - 100 , Screen.height/2 -50 , 200 , 100),"you win!!"))
                {
                SceneManager.LoadScene(0);
                Time.timeScale = 1f;
            }
        }
    }
}
