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

    [SerializeField]
    GameObject arrowPrefab;

    SphereCollider projectilePlacerCollider;

    GameObject projectile;
    
    Plane projectionPlane;

    GameObject arrow;
    SpriteRenderer arrowSprRend;
    float arrowAspectRatio;

    bool clicked = false;
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

        CheckOnClick();

        CheckOnClickExit();
    }

    private void CheckOnClickEnter()
    {
        if (Input.GetMouseButtonDown(0))
        {
            mousePos = GetClickPositionOnPlane().GetValueOrDefault();

            //Only detects if mouse position is inside placer bounding sphere
            if (projectilePlacerCollider.bounds.Contains(mousePos))
            {
                projectile = Instantiate(projectilePrefab, mousePos, Quaternion.identity, gameObject.transform);
                arrow = Instantiate(arrowPrefab, projectilePlacer.transform.position, Quaternion.FromToRotation(Vector3.up, transform.forward), gameObject.transform);
                arrowSprRend = arrow.GetComponent<SpriteRenderer>();
                arrowAspectRatio = arrowSprRend.size.x / arrowSprRend.size.y;
                clicked = true;
            }
        }
    }

    private void CheckOnClick()
    {
        if (clicked)
        {
            mousePos = GetClickPositionOnPlane().GetValueOrDefault();
            projectile.transform.position = mousePos;

            float angle = getRotationAngle();
            arrow.transform.localRotation = Quaternion.Euler(90, angle, 0);

            float mousePlaceDistance = Vector3.Distance(mousePos, projectilePlacer.transform.position);
            float arrowHeight = mousePlaceDistance * 2;
            arrowSprRend.size = new Vector2(arrowHeight * arrowAspectRatio, arrowHeight);
        }
    }

    private void CheckOnClickExit()
    {
        if (Input.GetMouseButtonUp(0))
        {
            Destroy(projectile);
            Destroy(arrow);
            clicked = false;
        }
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

    private float getRotationAngle()
    {
        float angle = Vector3.Angle(new Vector3(0, 0, -1), transform.InverseTransformPoint(mousePos));
        Vector3 cross = Vector3.Cross(new Vector3(0, 0, -1), transform.InverseTransformPoint(mousePos));
        if (cross.y < 0) angle = -angle;

        return angle;
    }
}




/*
if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
{
    touchPosWords = Input.GetTouch(0).position;
}
*/