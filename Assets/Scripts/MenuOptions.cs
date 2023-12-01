using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
public class MenuOptions : MonoBehaviour
{
    [SerializeField] private AudioMixer audioMixer;
    public void PantallaCompleta(bool PantallaCompleta)
    {
        Screen.fullScreen = PantallaCompleta;
    }

    public void CambiarVolumen(float volume)
    {
        audioMixer.SetFloat("Volume", volume);
    }

    public void CambiarCalidad(int index)
    {
    QualitySettings.SetQualityLevel(index);
    }
}
