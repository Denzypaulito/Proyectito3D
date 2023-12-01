using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public GameObject objetoADesactivar; // Objeto que deseas desactivar al pausar el juego
    public GameObject objetoADesactivar2;
    public GameObject objetoADesactivar3;
    public GameObject objetoADesactivar4;
    public GameObject objetoADesactivar5;
    [SerializeField] private Contador menu;

    // Llamar a esta función para pausar el juego
    public void Pause()
    {
        Debug.Log(menu.Corpse());
        Time.timeScale = 0f;
        DesactivarObjeto();
    }

    // Llamar a esta función para reanudar el juego
    public void Resume()
    {
        Time.timeScale = 1f;
        ActivarObjeto();
    }

    // Método Update se llama en cada frame
    void Update()
    {

        // Verificar si la tecla Escape ha sido presionada
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            // Pausar o reanudar el juego según el estado actual
            if (Time.timeScale == 0f)
            {
                // Si el juego está pausado, reanudarlo
                Resume();
            }
            else
            {
                // Si el juego no está pausado, pausarlo
                Pause();
            }
        }
        if (menu.Corpse() >= 100){
            Pause();
            Win();
        }
    }

    // Método para desactivar el objeto
    private void DesactivarObjeto()
    {
        Cursor.visible = true;
        objetoADesactivar.SetActive(false);
        objetoADesactivar3.SetActive(true);
        if (!objetoADesactivar4.activeSelf){
            objetoADesactivar2.SetActive(false);
        }
    }

    // Método para activar el objeto
    private void ActivarObjeto()
    {
        Cursor.visible = false;
        objetoADesactivar.SetActive(true);
        objetoADesactivar3.SetActive(false);
        if (!objetoADesactivar4.activeSelf){
            objetoADesactivar2.SetActive(true);
        }
    }
    private void Win()
    {
        objetoADesactivar5.SetActive(true);
    }
}
