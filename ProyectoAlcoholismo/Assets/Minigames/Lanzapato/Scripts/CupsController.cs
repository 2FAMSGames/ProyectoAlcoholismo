using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CupsController : MonoBehaviour
{
    CupsPlacer cupsPlacer;
    SlingshotController slingshotController;

    // Start is called before the first frame update
    IEnumerator Start()
    {
        cupsPlacer = GetComponent<CupsPlacer>();
        yield return new WaitUntil(() => cupsPlacer.isInitialized);
        cupsPlacer.PlaceCups(5);

        //Rework this  ---> haciendo referencia a un GameController superior
        slingshotController = GameObject.Find("Slingshot").GetComponent<SlingshotController>();
    }

    public void OnCupEntered()
    {
        //Rework this  ---> haciendo referencia a un GameController superior
        StartCoroutine(slingshotController.ResetProjectileOnHit());
        
    }
}
