using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct Weapon//结构体,值传递
{
    public string name;
    public int damage;

    public Weapon(string name , int damage)
    {
        this.name = name;
        this.damage = damage;
    }

    public  void PrintWeaponStatsInfo()//多态，虚函数
    {
        Debug.LogFormat("Weapon:{0}: {1}", name, damage);
    }
}

public class Character
{
    public int exp = 0;
    public string name;

    public Character()
    {
        name = "initName";
    }

    public Character(string name)
    {
        this.name = name;
    }

    public Character(int exp)
    {
        this.exp = exp;
    }

    public virtual void PrintStatsInfo()
    {
        Debug.LogFormat("{0}: {1}", name, exp);
    }

    private void Reset()
    {
        this.name = "initName";
        this.exp = 0;
    }
}

public class Paladin: Character//一个继承自Character类的新子类
{
    public Weapon weapon;//独有的属性，武器

    public Paladin(string name):base(name)//继承基类的构造函数
    {
        
    }
    public Paladin(string name , Weapon weapon) : base(name)
    {
        this.weapon = weapon;
    }

    public override void PrintStatsInfo()
    {
        Debug.LogFormat("Paladin:{0}: {1} {2}", name, weapon.name , weapon.damage);
    }
}
