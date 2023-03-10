using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StudySingleton : MonoBehaviour
{
    private static StudySingleton instance;//����ľ�̬���������浥����ʵ��

    private StudySingleton() { }//�����Ƚ����캯������˽�л�����ֹ�ⲿ�������ʵ��

    public static StudySingleton Instance//����һ�������ģ���̬��������ȡ������ʵ�����߼��ϵ��ж���
                                         //���ȼ��ʵ���Ƿ�Ϊ�գ����Ϊ�վʹ���һ���µ�ʵ�����ҷ��أ����򷵻����е�ʵ��
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
