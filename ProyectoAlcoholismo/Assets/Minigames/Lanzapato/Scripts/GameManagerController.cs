using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerController : MonoBehaviour
{
    [SerializeField]
    GameObject slingshot;
    SlingshotController slingshotController;

    [SerializeField]
    GameObject cupsContainer;
    CupsController cupsController;

    int score = 0;

    // Start is called before the first frame update
    void Start()
    {
        slingshotController = slingshot.GetComponent<SlingshotController>();
        cupsController = cupsContainer.GetComponent<CupsController>();
        SetupLevel();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SetupLevel()
    {
        score = 0;
        cupsController.SetupEnviroment(5, 1); //Valores placeholder
        //Establece parametros de fuerza
        slingshotController.DeleteAndCreateProjectile();
    }

    void DestroyLevel()
    {
        //Borra/reinicia proyectil lanzado
        cupsController.ResetEnviroment();
    }

    public void OnCupEntered()
    {
        score++;
        StartCoroutine(slingshotController.ResetProjectileOnHit());
    }
}
