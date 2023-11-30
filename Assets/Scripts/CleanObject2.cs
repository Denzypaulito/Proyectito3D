using UnityEngine;
using UnityEngine.UI;
public class CleanObject2 : MonoBehaviour
{
    private Vector3 posicionInicial;
    public GameObject prop;

    // Se añade una referencia al Rigidbody
    private Rigidbody rb;

    public Text Score;

    public int Points;

    void Start()
    {
        // Almacena la posición inicial al inicio
        posicionInicial = transform.position;

        // Obtiene la referencia al Rigidbody
        rb = prop.GetComponent<Rigidbody>();
    }

    void Update()
    {
        // Verifica si la posición ha cambiado desde el inicio
        if (Vector3.Distance(transform.position, posicionInicial) > 0.5f)
        {
            prop.GetComponent<Rigidbody>().AddForce(Vector3.up * 2000.0f, ForceMode.Impulse);
            Invoke("DesactivarRigidbody", 1.0f);
            Invoke("EliminarObject", 3.0f);
        }
    }

    void DesactivarRigidbody()
    {
        Points += 30;
        Score.text = "Damage: " + Points;
        // Desactiva el Rigidbody
        rb.isKinematic = true;
        rb.detectCollisions = false;

        // Alternativamente, puedes desactivar el objeto completo
        // prop.SetActive(false);
    }

    void EliminarObject()
    {
        prop.SetActive(false);
    }
}
