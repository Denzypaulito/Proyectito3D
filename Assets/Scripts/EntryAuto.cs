using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StarterAssets;

public class EntryAuto : MonoBehaviour
{
    public GameObject camaraVehiculo;
    public GameObject jugador;
    public bool puedoEntrar;
    public PrometeoCarController PrometeoCarController;
    public GameObject salirVehiculo;
    public GameObject SoundsVehicle;
    public GameObject Velocity;
    public GameObject Prometheus;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            entrarVehiculo();
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            jugador = other.gameObject;
            puedoEntrar = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            jugador = other.gameObject;
            puedoEntrar = false;
        }
    }

    public void entrarVehiculo()
    {
        if (puedoEntrar)
        {
            //Input.ResetInputAxes();
            //jugador.GetComponent<ThirdPersonController>().enabled = false;
            jugador.SetActive(false);
            camaraVehiculo.SetActive(true);
            Prometheus.GetComponent<Rigidbody>().drag = 0.05f;
            PrometeoCarController.enabled = true;
            SoundsVehicle.SetActive(true);
            Velocity.SetActive(true);

            salirVehiculo.SetActive(true);
            gameObject.SetActive(false);
        }
    }
}
