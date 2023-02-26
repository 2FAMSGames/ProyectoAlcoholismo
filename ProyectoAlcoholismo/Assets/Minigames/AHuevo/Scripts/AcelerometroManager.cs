using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AcelerometroManager : MonoBehaviour
{


    private Rigidbody rb;

    private float Speed =20f;
    private float friction =1f;

    // Start is called before the first frame update
    void Start()
    {
        rb=GetComponent<Rigidbody>();
        rb.drag = friction;

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 tilt = Input.acceleration;
        tilt = Quaternion.Euler(90, 0, 0) * tilt;
        rb.AddForce(tilt * Speed);
    }
}
