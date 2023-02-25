using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehavior : MonoBehaviour
{
    public float moveSpeed = 10f;//速度
    public float rotateSpeed = 75f;//旋转速度

    private float vInput;
    private float hInput;

    private Rigidbody _rb;

    void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        vInput = Input.GetAxis("Vertical") * moveSpeed;//获得垂直速度

        hInput = Input.GetAxis("Horizontal") * rotateSpeed;//获得水平旋转速度



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
