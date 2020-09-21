using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerControls : MonoBehaviour
{
    private Rigidbody myRigidBody;
    public int movementSpeed = 50;
    private Camera myCamera;
    public GameObject bulletPrefab;
    public float fireDelay = 0.1f;
    private float delayForNextFire = 0;

    void Start()
    {
        myRigidBody = GetComponent<Rigidbody>();
        myCamera = FindObjectOfType<Camera>();
    }

    void Update()
    {
        MovePlayer();
        OrientatePlayer();
        ProcessFire();
    }

    private void MovePlayer()
    {
        float inputHorizontal = Input.GetAxis("Horizontal");
        float inputVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(inputHorizontal, 0, inputVertical) * Time.deltaTime * movementSpeed;
        myRigidBody.MovePosition(myRigidBody.position + movement);
    }

    private void OrientatePlayer()
    {
        Vector3 result = FindPositionOfMouse();
        result.y = myRigidBody.position.y;
        Vector3 relativePosition = result - transform.position;
        Quaternion quaternionRotation = Quaternion.LookRotation(relativePosition, Vector3.up);
        myRigidBody.MoveRotation(quaternionRotation);
    }
    private void ProcessFire()
    {
        delayForNextFire -= Time.deltaTime;
        if (Input.GetAxis("Fire1") != 0)
        {
            if (delayForNextFire <= 0)
            {
                //shoot
                delayForNextFire = fireDelay;
                ShootBullet();
            }
        }
    }

    private void ShootBullet()
    {
        Instantiate(bulletPrefab, transform.position + transform.forward, transform.rotation);
    }

    private Vector3 FindPositionOfMouse()
    {
        Vector3 position = new Vector3();
        RaycastHit hit;
        Ray ray = myCamera.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit, 1000))
        {
            position.x = hit.point.x;
            position.y = hit.point.y;
            position.z = hit.point.z;
        }

        return position;
    }
}
