using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragPelota : MonoBehaviour
{
    public LineRenderer lineRenderer;
    public float forceMultiplier = 10f;

    private Camera cam;
    private Rigidbody rb;
    private bool dragging = false;
    private Vector3 dragStartPos;

    void Start()
    {
        cam = Camera.main;
        rb = GetComponent<Rigidbody>();

        lineRenderer.positionCount = 2;
        lineRenderer.enabled = false;
    }

    void OnMouseDown()
    {
        dragging = true;
        dragStartPos = GetMousePointOnGround();
    }

    void OnMouseDrag()
    {
        if (!dragging) return;

        Vector3 currentPos = GetMousePointOnGround();
        Vector3 direction = dragStartPos - currentPos; // hacia atrás

        // Mostrar la línea
        lineRenderer.enabled = true;
        lineRenderer.SetPosition(0, transform.position);
        lineRenderer.SetPosition(1, transform.position + direction);
    }

    void OnMouseUp()
    {
        dragging = false;
        lineRenderer.enabled = false;

        Vector3 releasePos = GetMousePointOnGround();
        Vector3 direction = dragStartPos - releasePos;

        rb.AddForce(direction * forceMultiplier, ForceMode.Impulse);
    }

    // Convertir mouse a punto en el suelo
    Vector3 GetMousePointOnGround()
    {
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        Plane ground = new Plane(Vector3.up, Vector3.zero);

        ground.Raycast(ray, out float distance);
        return ray.GetPoint(distance);
    }
}
