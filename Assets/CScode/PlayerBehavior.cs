using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehavior : MonoBehaviour
{
    public float moveSpeed = 10f;//�ٶ�
    public float rotateSpeed = 75f;//��ת�ٶ�

    private float vInput;
    private float hInput;

    private Rigidbody _rb;

    void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        vInput = Input.GetAxis("Vertical") * moveSpeed;//��ô�ֱ�ٶ�

        hInput = Input.GetAxis("Horizontal") * rotateSpeed;//���ˮƽ��ת�ٶ�



        //this.transform.Translate(Vector3.forward * vInput * Time.deltaTime);

        //this.transform.Rotate(Vector3.up * hInput * Time.deltaTime);
    }

    void FixedUpdate()
    {
        Vector3 rotation = Vector3.up * hInput;

        Quaternion angleRot = Quaternion.Euler(rotation * Time.fixedDeltaTime);

        _rb.MovePosition(this.transform.position + this.transform.forward * vInput * Time.fixedDeltaTime);

        _rb.MoveRotation(_rb.rotation * angleRot);
    }
}
