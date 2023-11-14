using UnityEngine;

public class CleanObject2 : MonoBehaviour
{
    private Vector3 posicionInicial;
    public GameObject prop;

    void Start()
    {
        // Almacena la posición inicial al inicio
        posicionInicial = transform.position;
    }

    void Update()
    {
        // Verifica si la posición ha cambiado desde el inicio
        if (Vector3.Distance(transform.position, posicionInicial) > 0.5f)
        {
            Invoke("EliminarObjeto", 2.0f);
        }
    }

    void EliminarObjeto()
    {
        // Elimina el objeto
        prop.SetActive(false);
    }
}