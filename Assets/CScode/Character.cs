using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct Weapon//�ṹ��,ֵ����
{
    public string name;
    public int damage;

    public Weapon(string name , int damage)
    {
        this.name = name;
        this.damage = damage;
    }

    public  void PrintWeaponStatsInfo()//��̬���麯��
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

public class Paladin: Character//һ���̳���Character���������
{
    public Weapon weapon;//���е����ԣ�����

    public Paladin(string name):base(name)//�̳л���Ĺ��캯��
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
