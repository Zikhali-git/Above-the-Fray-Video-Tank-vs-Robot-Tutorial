using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonScript : MonoBehaviour
{
    private Vector3 zAngle;
    public float angle = 1.0f;

    // Update is called once per frame
    void Update()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0f;

        // Gun follows the mouse
        // normalized, a vector keeps the same direction but its length is 1.0
        Vector3 aimDirection = (mousePos - transform.position).normalized;
        // atan2 - the angle, in radians, between positive x axis and ray to point x, y
        angle = (Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg) - 90;
        zAngle = new Vector3(0, 0, angle);
        // Euler angles - 3 angles that describe the orientation of a rigid body in a coordinate system
        transform.eulerAngles = zAngle;
    }
}
