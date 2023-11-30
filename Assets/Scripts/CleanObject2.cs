using UnityEngine;
using UnityEngine.UI;
public class CleanObject2 : MonoBehaviour
{
    [SerializeField] private float cantidadPuntos;

    [SerializeField] private Contador menu;

    private Vector3 posicionInicial;
    public GameObject prop;

    // Se añade una referencia al Rigidbody
    private Rigidbody rb;

    public Text Score;

    public int Points;

    public int i = 0;
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
            if (i < 1){
                menu.SumPoints(cantidadPuntos);
            }
            i = 1;
            prop.GetComponent<Rigidbody>().AddForce(Vector3.up * 0.5f, ForceMode.Impulse);
            Invoke("DesactivarRigidbody", 1.0f);
            Invoke("EliminarObject", 3.0f);
        }
    }

    void DesactivarRigidbody()
    {
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
