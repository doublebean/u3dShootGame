using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StudySingleton : MonoBehaviour
{
    private static StudySingleton instance;//创造的静态变量来保存单例的实例

    private StudySingleton() { }//必须先将构造函数进行私有化，防止外部创建类的实例

    public static StudySingleton Instance//创建一个公共的，静态属性来获取单例的实例。逻辑上的判断是
                                         //，先检查实例是否为空，如果为空就创建一个新的实例并且返回，否则返回现有的实例
    {
        get
        {
            if(instance == null)
            {
                instance = new StudySingleton();
            }
            return instance;
        }
    }

    void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
