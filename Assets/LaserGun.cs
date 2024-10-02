using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserGun : MonoBehaviour
{
    public LineRenderer lineRenderer;
    public ParticleSystem remnants;
    public LayerMask layerMask;
    public Transform firePoint;
    public float length;
    private Vector2 endPoint;

    private void Update()
    {
        endPoint = firePoint.position + firePoint.right * length;
        CheckCollider();
        UpdateLineRenderer();
    }

    private void CheckCollider()
    {
        RaycastHit2D hit = Physics2D.Raycast(firePoint.position, firePoint.right, length, layerMask);
        if (hit.collider == null)
        {
            remnants.gameObject.SetActive(false);
        }
        else
        {
            endPoint = hit.point;
            remnants.transform.position = endPoint;
            remnants.gameObject.SetActive(true);
        }
    }

    private void UpdateLineRenderer()
    {
        var startPointLocal = lineRenderer.transform.InverseTransformPoint(firePoint.position);
        var endPointLocal = lineRenderer.transform.InverseTransformPoint(endPoint);

        lineRenderer.SetPosition(0, startPointLocal);
        lineRenderer.SetPosition(1, endPointLocal);
    }
}
