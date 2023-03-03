using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlingshotController : MonoBehaviour
{
    [SerializeField]
    GameObject projectionPlaneObject;

    [SerializeField]
    GameObject projectilePrefab;

    [SerializeField]
    [Tooltip("Position where projectile will be instantiated and collider used for click detection")]
    GameObject projectilePlacer;

    SphereCollider projectilePlacerCollider;

    Plane projectionPlane;
    bool clicked = false;
    GameObject projectile;
    Vector3 mousePos;

    // Start is called before the first frame update
    void Start()
    {
        projectionPlane = new Plane(projectionPlaneObject.transform.up, projectionPlaneObject.transform.position);
        projectilePlacerCollider = projectilePlacer.GetComponent<SphereCollider>();
    }

    // Update is called once per frame
    void Update()
    {
        CheckOnClickEnter();

        CheckOnClic();

        CheckOnClickExit();
    }

    private Vector3? GetClickPositionOnPlane()
    {
        Ray cameraMouseRay = Camera.main.ScreenPointToRay(Input.mousePosition);

        float rayDistance;
        if (projectionPlane.Raycast(cameraMouseRay, out rayDistance))
        {
            return cameraMouseRay.GetPoint(rayDistance);
        }

        return null;
    }

    private void CheckOnClickEnter()
    {
        if (clicked)
        {
            mousePos = GetClickPositionOnPlane().GetValueOrDefault();
            projectile.transform.position = mousePos;
        }
    }

    private void CheckOnClickExit()
    {
        if (Input.GetMouseButtonUp(0))
        {
            Destroy(projectile);
            clicked = false;
        }
    }

    private void CheckOnClic()
    {
        if (Input.GetMouseButtonDown(0))
        {
            mousePos = GetClickPositionOnPlane().GetValueOrDefault();

            //Only detects if mouse position is inside placer bounding sphere
            if (projectilePlacerCollider.bounds.Contains(mousePos))
            {
                projectile = Instantiate(projectilePrefab, mousePos, Quaternion.identity, gameObject.transform);
                clicked = true;
            }
        }
    }
}




/*
if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
{
    touchPosWords = Input.GetTouch(0).position;
}
*/