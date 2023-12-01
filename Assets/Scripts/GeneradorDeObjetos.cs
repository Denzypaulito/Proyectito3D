using UnityEngine;
using System.Collections.Generic;

public class GeneradorDeObjetos : MonoBehaviour
{
    public GameObject objetoPrefab; 
    public int cantidadMaximaObjetos = 10; 
    public float rangoX = 10f; 
    public float rangoY = 2f;  
    public float rangoZ = 10f; 

    private List<GameObject> objetosGenerados = new List<GameObject>();

    void Start()
    {
        GenerarObjetos();
    }

    void GenerarObjetos()
    {
        for (int i = 0; i < cantidadMaximaObjetos; i++)
        {
            CrearNuevoObjeto();
        }
    }

    void CrearNuevoObjeto()
    {
        Vector3 posicionActual = transform.position;

        Vector3 posicion = new Vector3(
            posicionActual.x + Random.Range(-rangoX, rangoX),
            posicionActual.y + Random.Range(-rangoY, rangoY),
            posicionActual.z + Random.Range(-rangoZ, rangoZ)
        );

        GameObject nuevoObjeto = Instantiate(objetoPrefab, posicion, Quaternion.identity);

        objetosGenerados.Add(nuevoObjeto);
    }

    void Update()
    {
        if (objetosGenerados.Count < cantidadMaximaObjetos)
        {
            CrearNuevoObjeto();
            Debug.Log("Nuevo objeto generado.");
        }
    }

    public void DisminuirMaxObjetos()
    {
        cantidadMaximaObjetos = Mathf.Max(0, cantidadMaximaObjetos - 1);

        if (objetosGenerados.Count > cantidadMaximaObjetos)
        {
            Destroy(objetosGenerados[0]);
            objetosGenerados.RemoveAt(0);
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireCube(transform.position, new Vector3(rangoX * 2, rangoY * 2, rangoZ * 2));
    }

    void OnDrawGizmos()
    {
        Gizmos.color = new Color(0.5f, 0.5f, 1f, 0.5f);
        Gizmos.DrawCube(transform.position, new Vector3(rangoX * 2, rangoY * 2, rangoZ * 2));
    }
}
