using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    // Llamar a esta función para pausar el juego
    public void Pause()
    {
        Time.timeScale = 0f;
    }

    // Llamar a esta función para reanudar el juego
    public void Resume()
    {
        Time.timeScale = 1f;
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
    }
}

