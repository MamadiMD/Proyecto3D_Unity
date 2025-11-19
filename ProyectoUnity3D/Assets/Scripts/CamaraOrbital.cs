using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamaraOrbital : MonoBehaviour
{
    public Transform target;       
    public float distance = 5f;    
    public float sensitivityX = 200f;
    public float sensitivityY = 150f;
    public float minY = -20f;      
    public float maxY = 70f;

    private float rotX;
    private float rotY;

    void Start()
    {
        if (target == null)
        {
            Debug.LogError("No se asignó un target en la cámara orbital.");
        }

        
        Vector3 angles = transform.eulerAngles;
        rotX = angles.y;
        rotY = angles.x;
    }

    void LateUpdate()
    {
        if (target == null) return;

        
        rotX += Input.GetAxis("Mouse X") * sensitivityX * Time.deltaTime;
        rotY -= Input.GetAxis("Mouse Y") * sensitivityY * Time.deltaTime;

        
        rotY = Mathf.Clamp(rotY, minY, maxY);

        
        Quaternion rotation = Quaternion.Euler(rotY, rotX, 0);

        
        Vector3 direction = rotation * new Vector3(0, 0, -distance);
        transform.position = target.position + direction;

        
        transform.LookAt(target);
    }
}
