using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerScript : MonoBehaviour
{
    public GameObject bulletPrefab;
    public GameObject cannon;
    private float bulletSpeed = 10.0f;
    
    public GameObject cursor;
    private Vector3 mouseVector;
    private Vector3 target;


    void Start()
    {
        Cursor.visible = false;
    }

    void Update()
    {
        mouseVector = new Vector3(Input.mousePosition.x, Input.mousePosition.y, transform.position.z);
        target = transform.GetComponent<Camera>().ScreenToWorldPoint(mouseVector);
        cursor.transform.position = new Vector2(target.x, target.y);

        if (Input.GetMouseButtonDown(0))
        {
            Vector3 difference = target - cannon.transform.position;
            float distance = difference.magnitude;
            Vector2 direction = difference / distance;
            // Normalize, keep vectors in same direction but length of 1 now
            direction.Normalize();
            FireBullet(direction, cannon.GetComponent<CannonScript>().angle);
        }
    }

    void FireBullet(Vector2 direction, float rotationZ)
    {
        GameObject tempBullet = Instantiate(bulletPrefab) as GameObject;
        tempBullet.transform.position = cannon.transform.position;
        tempBullet.transform.rotation = Quaternion.Euler(0.0f, 0.0f, rotationZ);
        tempBullet.GetComponent<Rigidbody2D>().velocity = direction * bulletSpeed;
    }
}
