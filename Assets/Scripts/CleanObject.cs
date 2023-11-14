using UnityEngine;

public class CleanObject : MonoBehaviour
{
    private Vector3[] posicionesIniciales; // Almacena las posiciones iniciales de los objetos hijos
    public GameObject water; // Asigna el objeto que deseas activar desde el Inspector
    public GameObject hydrant;
    private bool yaCambiado = false; // Bandera para asegurarse de que la acción solo se realice una vez

    void Start()
    {
        // Almacena las posiciones iniciales de los objetos hijos
        posicionesIniciales = new Vector3[transform.childCount];
        for (int i = 0; i < transform.childCount; i++)
        {
            posicionesIniciales[i] = transform.GetChild(i).position;
        }
        
    }

    void Update()
    {
        // Verifica si alguna posición ha cambiado desde el inicio y aún no ha sido procesado
        if (!yaCambiado && PosicionCambiada())
        {
            yaCambiado = true; // Marcar como procesado para evitar la repetición
            water.SetActive(true);
            hydrant.GetComponent<Rigidbody>().AddForce(Vector3.up * 2000.0f, ForceMode.Impulse);
            Invoke("EliminarObjeto", 2.0f);
            Invoke("DesactiveObject", 30.0f);
        }
    }

    bool PosicionCambiada()
    {
        // Comprueba si alguna posición de los objetos hijos ha cambiado
        for (int i = 0; i < transform.childCount; i++)
        {
            if (Vector3.Distance(transform.GetChild(i).position, posicionesIniciales[i]) > 0.3f)
            {
                return true;
            }
        }
        return false;
    }

    void EliminarObjeto()
    {
        // Desactiva el objeto padre (hydrant)
        hydrant.SetActive(false);
    }

    void DesactiveObject()
    {
        // Desactiva el objeto hijo (water)
        water.SetActive(false);
    }
}
