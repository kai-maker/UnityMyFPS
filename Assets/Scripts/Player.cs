using System;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody rb;
    [SerializeField] private Camera cam;
    [SerializeField] private Gun gun;
    public float rotateSpeed = 2.0f;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        rb = GetComponent<Rigidbody>();
    }

    void Update ()
    {
        #region WSADで移動
            var v = rb.velocity;
            v.x = Input.GetAxis("Horizontal") * 10;
            v.z = Input.GetAxis("Vertical") * 10;
            if (Input.GetKeyDown(KeyCode.Space))
            {
                v.y = 10f;
            }
            // ワールド座標の速度をローカル座標に直す
            v = transform.rotation * v;
            rb.velocity = v;
        #endregion

        #region 撃つ
            if (Input.GetMouseButtonDown(0))
            {
                gun.OnShut();
            }
        #endregion
        
        
    }

    private void LateUpdate()
    {
        rotateCamera();
    }
    
    /**
     * マウスの位置でカメラを回転
     */
    private void rotateCamera()
    {
        Vector3 angle = new Vector3(Input.GetAxis("Mouse X") * rotateSpeed,Input.GetAxis("Mouse Y") * rotateSpeed, 0);
        
        cam.transform.RotateAround(transform.position, cam.transform.right, -angle.y);
        
        transform.Rotate(new Vector3(0f, angle.x, 0f));
        gun.transform.Rotate(new Vector3(-angle.y, 0f, 0f));
    }
}
