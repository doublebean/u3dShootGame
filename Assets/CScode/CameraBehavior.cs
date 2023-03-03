using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBehavior : MonoBehaviour
{
    public Vector3 camOffset = new Vector3( 0 ,  2.4f , -5.2f );//相机和玩家之间的偏移量

    private Transform target;//保存player的变化信息

    

    void Start()
    {
        

        target = GameObject.Find("Player").transform;//找到玩家的移动
    }

    // Update is called once per frame
    void LateUpdate()
    {
        this.transform.position = target.TransformPoint(camOffset);//当前的位置处在玩家的位置算上相机和玩家之间的偏移量

        this.transform.LookAt(target);//更新旋转值
    }
}
