using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehavior : MonoBehaviour
{
    public float moveSpeed = 10f;//速度
    public float rotateSpeed = 75f;//旋转速度
    public float jumpVelocity = 5f;//跳跃
    public float distanceToGround = 0.1f;
    public float bulletSpeed = 100f;//子弹速度

    public GameObject bullet;//子弹
    public LayerMask groundLayer;

    private float vInput;
    private float hInput;
    private bool flagBullet = false;

    private Rigidbody _rb;
    private CapsuleCollider _col;
    private GameBehavior _gameManager;//得到的游戏管理器

    void Start()
    {
        _rb = GetComponent<Rigidbody>();

        _col = GetComponent<CapsuleCollider>();

        _gameManager = GameObject.Find("GameManager").GetComponent<GameBehavior>();
    }

    void Update()
    {
        vInput = Input.GetAxis("Vertical") * moveSpeed;//获得垂直速度

        hInput = Input.GetAxis("Horizontal") * rotateSpeed;//获得水平旋转速度

        if( IsGrounded() && Input.GetKeyDown(KeyCode.Space))
        {
            _rb.AddForce(Vector3.up * jumpVelocity, ForceMode.Impulse);

        }

        if(Input.GetMouseButtonDown(0))
        {
            flagBullet = true;
        }
        //this.transform.Translate(Vector3.forward * vInput * Time.deltaTime);

        //this.transform.Rotate(Vector3.up * hInput * Time.deltaTime);
    }

    void FixedUpdate()
    {
        Vector3 rotation = Vector3.up * hInput;

        Quaternion angleRot = Quaternion.Euler(rotation * Time.fixedDeltaTime);

        _rb.MovePosition(this.transform.position + this.transform.forward * vInput * Time.fixedDeltaTime);

        _rb.MoveRotation(_rb.rotation * angleRot);

        if(flagBullet)
        {
            GameObject newBullet = Instantiate(bullet, this.transform.position, this.transform.rotation) as GameObject;

            Rigidbody bulletRB = newBullet.GetComponent<Rigidbody>();

            bulletRB.velocity = this.transform.forward * bulletSpeed;

            Debug.Log("open fire!");
            flagBullet = false ;

        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if( collision.gameObject.name == "Enemy" )
        {
            _gameManager.Lives -= 1;
        }
    }

    private bool IsGrounded()
    {
       Vector3 capsuleBottom = new Vector3(_col.bounds.center.x, _col.bounds.min.y, _col.bounds.center.z);//物体的底部

        bool grounded = Physics.CheckCapsule(_col.bounds.center, capsuleBottom, distanceToGround, groundLayer, QueryTriggerInteraction.Ignore);

        return grounded;
    }
}
