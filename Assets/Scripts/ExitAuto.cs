using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitAuto : MonoBehaviour
{
    public EntryAuto EntryAuto;
    public GameObject camaraVehiculo;
    public GameObject jugador;
    public PrometeoCarController PrometeoCarController;
    public GameObject SoundsVehicle;
    public GameObject Velocity;
    public GameObject Prometheus;

    
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
        jugador.transform.position = gameObject.transform.position;
        camaraVehiculo.SetActive(false);
        EntryAuto.gameObject.SetActive(true);
        gameObject.SetActive(false);
        SoundsVehicle.SetActive(false);
        Velocity.SetActive(false);
        PrometeoCarController.enabled = false;
        jugador.SetActive(true);
    }
}
