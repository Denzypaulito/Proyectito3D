using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;

public class Contador : MonoBehaviour
{
    public Text relojText;
    private float tiempoInicial = 360f; // 24 minutos en segundos
    private float tiempoRestante = 1440f;

    private float points = 0;

    public Text Score;


    void Start()
    {
        // Llama a la función ActualizarReloj cada segundo
        InvokeRepeating("ActualizarReloj", 0f, 1f);
    }

    public void SumPoints(float pointsNew){
        points += pointsNew;
    }
    void ActualizarReloj()
    {
        // Resta un segundo al tiempo restante
        tiempoInicial += 1;
        tiempoRestante -= 1;

        // Convierte el tiempo restante a formato de minutos y segundos
        int minutos = Mathf.FloorToInt(tiempoInicial / 60);
        int segundos = Mathf.FloorToInt(tiempoInicial % 60);

        // Formatea la cadena en el formato HH:mm
        string horaActual = string.Format("{0:D2}:{1:D2}", minutos, segundos);

        // Actualiza el objeto de texto con la hora actual
        relojText.text = horaActual;
        Score.text = "Damage: " + points;

        // Si el tiempo restante llega a cero, puedes manejar aquí la lógica de lo que sucede después
        if (tiempoRestante <= 0)
        {
            CancelInvoke("ActualizarReloj");
            Debug.Log("Tiempo agotado");
            int escenaActual = SceneManager.GetActiveScene().buildIndex;
            SceneManager.LoadScene(escenaActual);
        }
    }
}
