using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using CustomExtensions;

public class GameBehavior : MonoBehaviour, IManager
{
    public string labelText = "Collect all 4items and win your freedom !";
    public int maxItems = 4;
    public delegate void DebugDelegate(string newText);//声明委托
    public DebugDelegate debug = Print;//分配给委托方法

    public bool showWinScreen = false;
    public bool showLossScreen = false;

    private int _itemsCollected = 0;
    private int _playerLives = 3;
    private string _state;

    public string State
    {
        get { return _state; }
        set { _state = value; }
    }

    void Start()
    {
        Initialize();

        InventoryList<string> inventoryList = new InventoryList<string>();

        // InventoryList<int> addInventoryList = new InventoryList<int> ();//

        inventoryList.SetItem("positon");

        // addInventoryList.SetItem(999); //测试泛型的使用
        Debug.Log(inventoryList.item);
        // Debug.Log(addInventoryList.item);//



    }
    public void Initialize()//接口所需要实现的功能
    {
        _state = "Manager initialized";

        _state.FancyDebug();
        Debug.Log(_state);

        debug(_state);//通过委托调用

        LogWithDelegate(debug);

        GameObject player = GameObject.Find("Player");
        PlayerBehavior playerBehavior = player.GetComponent<PlayerBehavior>();
        playerBehavior.playerJump += HandlePlayerJump;

    }

    public void HandlePlayerJump()
    {
        debug("player has jumped!!!");
    }

    public int Items//声明收集数量的公共变量
    {
        get { return _itemsCollected; }

        set {
            _itemsCollected = value;
            Debug.LogFormat("Items : {0}", _itemsCollected);

            if (_itemsCollected >= maxItems)
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

        set
        {
            _playerLives = value;
            Debug.LogFormat("HP : {0}", _playerLives);


            if (_playerLives <= 0)
            {
                labelText = "You want another life with that?";
                showLossScreen = true;
                Time.timeScale = 0;
            }
            else
            {
                labelText = "ouch... that's got hurt";
            }
        }

    }

    public static void Print(string newText)
    {
        Debug.Log(newText);
    }

    public void LogWithDelegate(DebugDelegate @delegate)//这里的delegate是C#的关键字必须要加上@才行
    {
        @delegate("Delegating the debug task...");
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
                //SceneManager.LoadScene(0);
                //Time.timeScale = 1f;
                Utilities.RestarLevel();
                
            }
        }

        if(showLossScreen)
        {
            if(GUI.Button(new Rect(Screen.width / 2 - 100, Screen.height / 2 - 50, 200, 100), "you Lose!!"))
            {
                //SceneManager.LoadScene(0);
                //Time.timeScale = 1.0f;

                try
                {
                    Utilities.RestarLevel(-1);
                    debug("Level restarted successfully!!!");

                }
                catch(System.ArgumentException e)//当出现异常就调用默认的场景索引
                {
                    Utilities.RestarLevel(0);
                    debug("Reverting to scene 0: " + e.ToString());
                }
                finally
                {
                    debug("REstart handled....");
                }


                
            }
        }
    }

    
}
