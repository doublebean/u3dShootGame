using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StudyTest : MonoBehaviour
{

    private Transform camTransform;//定义一个变量存储transform
    public GameObject directionLight;
    private Transform lightTransform;
    void Awake()
    {
        Debug.Log("Awake");
        
    }

    void Start()
    {
        //Character hero = new Character("tdd123"); 
        //Character heroTwo = hero;

        //heroTwo.name = "tqq";

        //hero.PrintStatsInfo();

        //heroTwo.PrintStatsInfo();


        //Weapon huntingbow = new Weapon("huozhigaoxing", 999);
        //Weapon huntingbowTwo = huntingbow;

        //huntingbowTwo.damage = 100;

        //huntingbow.PrintWeaponStatsInfo();
        //huntingbowTwo.PrintWeaponStatsInfo();

        //Paladin knight = new Paladin("alagong",huntingbow);
        //knight.PrintStatsInfo();
        camTransform = this.GetComponent<Transform>();

        Debug.Log(camTransform.localPosition);

       // directionLight = GameObject.Find("Directional Light");

        lightTransform = directionLight.GetComponent<Transform>();
        Debug.Log(lightTransform.localPosition);

    }
  

    
}
