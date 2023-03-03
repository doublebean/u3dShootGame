using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBehavior : MonoBehaviour
{
    public Vector3 camOffset = new Vector3( 0 ,  2.4f , -5.2f );//��������֮���ƫ����

    private Transform target;//����player�ı仯��Ϣ

    

    void Start()
    {
        

        target = GameObject.Find("Player").transform;//�ҵ���ҵ��ƶ�
    }

    // Update is called once per frame
    void LateUpdate()
    {
        this.transform.position = target.TransformPoint(camOffset);//��ǰ��λ�ô�����ҵ�λ��������������֮���ƫ����

        this.transform.LookAt(target);//������תֵ
    }
}
