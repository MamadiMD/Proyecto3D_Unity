using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DragPelota : MonoBehaviour
{
    public LineRenderer lineRenderer;
    public float forceMultiplier = 10f;

    private Vector3 lastSafePosition;

    public CinematicaImagen cinematica;

    private bool puedeGolpear = true;

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

        if (!puedeGolpear)
        return;

        dragging = true;
        dragStartPos = GetMousePointOnGround();
        lastSafePosition = transform.position;
        
    }

    void OnMouseDrag()
    {
        if (!dragging) return;

        Vector3 currentPos = GetMousePointOnGround();
        Vector3 direction = dragStartPos - currentPos; // hacia atr�s

        // Mostrar la l�nea
        lineRenderer.enabled = true;
        lineRenderer.SetPosition(0, transform.position);
        lineRenderer.SetPosition(1, transform.position + direction);
    }

    void OnMouseUp()
    {

        if (!puedeGolpear)
        return; 

        dragging = false;
        lineRenderer.enabled = false;

        Vector3 releasePos = GetMousePointOnGround();
        Vector3 direction = dragStartPos - releasePos;

        rb.AddForce(direction * forceMultiplier, ForceMode.Impulse);

        cinematica.contadorGolpes++;
    }

    // Convertir mouse a punto en el suelo
    Vector3 GetMousePointOnGround()
    {
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        Plane ground = new Plane(Vector3.up, Vector3.zero);

        ground.Raycast(ray, out float distance);
        return ray.GetPoint(distance);
    }

    private void OnCollisionEnter(Collision collision)
{
    if (collision.collider.CompareTag("Suelo"))
    {
        ReturnToLastPosition();
    }

    if (collision.collider.CompareTag("Llave"))
        {
            DesactivarMuros();
        }
}

    void ReturnToLastPosition()
{
    rb.velocity = Vector3.zero;
    rb.angularVelocity = Vector3.zero;

    transform.position = lastSafePosition;
}

void DesactivarMuros()
    {
        GameObject[] muros = GameObject.FindGameObjectsWithTag("Muro");

        foreach (GameObject muro in muros)
        {
            muro.SetActive(false);
        }
    }

    void FixedUpdate()
{
    if (rb.velocity.magnitude < 0.05f)
{
    puedeGolpear = true;
}
else
{
    puedeGolpear = false;
}


}
}
