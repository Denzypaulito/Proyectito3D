using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StarterAssets;
using Cinemachine;

public class ExitAuto : MonoBehaviour
{
    public EntryAuto EntryAuto;
    public GameObject camaraVehiculo;
    public GameObject jugador;
    public PrometeoCarController PrometeoCarController;
    public GameObject SoundsVehicle;
    public GameObject Velocity;
    public GameObject Prometheus;

    public CinemachineVirtualCamera virtualCamera;
    
    // Start is called before the first frame update
    void Start()
    {
        jugador = EntryAuto.jugador;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            for (int i = 0; i < 1; i++)
            {
            PrometeoCarController.DecelerateCar();
            PrometeoCarController.Brakes();
            }
            ExitVehicle();
        }

    }

    public void ExitVehicle()
    {
        Input.ResetInputAxes();
        //jugador.GetComponent<ThirdPersonController>().Update();
        //jugador.GetComponent<ThirdPersonController>().enabled = true;
        jugador.transform.position = gameObject.transform.position;
        virtualCamera.enabled = true;
        //camaraVehiculo.SetActive(false);
        EntryAuto.gameObject.SetActive(true);
        gameObject.SetActive(false);
        SoundsVehicle.SetActive(false);
        Velocity.SetActive(false);
        PrometeoCarController.enabled = false;
        jugador.SetActive(true);
    }
}
