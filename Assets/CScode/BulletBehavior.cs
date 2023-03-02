using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehavior : MonoBehaviour
{
    public float onscreenDelay = 3f;//ÑÓ³Ù3ÃëÏú»Ù

    void Update()
    {
        Destroy(this.gameObject, onscreenDelay);
    }
}
