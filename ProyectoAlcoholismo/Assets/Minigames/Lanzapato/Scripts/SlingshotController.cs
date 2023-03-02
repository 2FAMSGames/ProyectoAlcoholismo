using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlingshotController : MonoBehaviour
{
    [SerializeField]
    GameObject projectionPlaneObject;

    Plane projectionPlane;

    // Start is called before the first frame update
    void Start()
    {
        projectionPlane = new Plane(projectionPlaneObject.transform.up, projectionPlaneObject.transform.position);
    }

    // Update is called once per frame
    void Update()
    {
        
        /*if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            touchPosWords = Input.GetTouch(0).position;
        }*/

        if (Input.GetMouseButtonDown(0))
        {
            Vector3 clickPos = GetClickPositionOnPlane().GetValueOrDefault();

            GameObject clickSphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
            clickSphere.transform.position = clickPos;

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


}
