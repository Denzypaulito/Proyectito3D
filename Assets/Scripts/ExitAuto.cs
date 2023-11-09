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
        if (Input.GetKeyDown(KeyCode.C) && (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D)))
        {
            Debug.Log("Deja de manejar para salir del vehículo");
        }

        if (Input.GetKeyDown(KeyCode.C) && !Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.S) && !Input.GetKey(KeyCode.D))
        {
            ExitVehicle();
        }

    }

    public void ExitVehicle()
    {
        jugador.transform.position = gameObject.transform.position;
        jugador.SetActive(true);
        camaraVehiculo.SetActive(false);
        EntryAuto.gameObject.SetActive(true);
        gameObject.SetActive(false);
        SoundsVehicle.SetActive(false);
        Velocity.SetActive(false);
        PrometeoCarController.enabled = false;
    }
}
