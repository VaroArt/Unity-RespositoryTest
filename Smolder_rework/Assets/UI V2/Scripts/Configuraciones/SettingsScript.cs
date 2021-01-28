using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SettingsScript : MonoBehaviour
{
    [Header("Controles")]
    public Canvas PanelDeConfiguracion;
    public bool ConfiguracionesActivas;

    [Header("Funciones")]
    public AudioMixer AudioMix;
    public AudioMixerGroup BgVolume;
    public AudioMixerGroup FxVolume;
    public AudioMixerGroup MusicVolume;

    public Dropdown resolutionDropdown;

    Resolution[] resolutions;

    // Configuracion de calidades para el juego
    void Start()
    {
        resolutions = Screen.resolutions;

        resolutionDropdown.ClearOptions();

        int currentResolutionIndex = 0;
        List<string> options = new List<string>();

        for (int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + " x " + resolutions[i].height + ", " + resolutions[i].refreshRate + "Fps";
            options.Add(option);

            if(resolutions[i].width == Screen.currentResolution.width && resolutions[i].height == Screen.currentResolution.height)
            {
                currentResolutionIndex = i;
            }
        }

        resolutionDropdown.AddOptions(options);
        resolutionDropdown.value = currentResolutionIndex;
        resolutionDropdown.RefreshShownValue();
    }

    public void Update()
    {
        ConfigOnOffFunc();
    }

    public void SetResolution (int resolutionIndex) //Actualiza la resolucion del juego
    {
        Resolution resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen, resolution.refreshRate);
    }

    public void SetVolume (float volume) //volumen General
    {
        AudioMix.SetFloat("MasterVol", volume);
    }

    public void BgVol (float volume) //volumen BG
    {
        BgVolume.audioMixer.SetFloat("BgVol", volume);
    }

    public void FxVol (float volume) //Volumen Fx
    {
        FxVolume.audioMixer.SetFloat("FxVol", volume);
    }

    public void MusicVol (float volume) //Volumen Musica
    {
        MusicVolume.audioMixer.SetFloat("MusicVol", volume);
    }

    public void SetQuality(int qualityIndex) //Calidad Grafica
    {
        QualitySettings.SetQualityLevel(qualityIndex);
    }

    public void SetFullscreen (bool isFullscreen) //Pantalla Completa
    {
        Screen.fullScreen = isFullscreen;
    }

    public void ConfigOnOffFunc()
    {
        if(ConfiguracionesActivas == true)
        {
            PanelDeConfiguracion.enabled = true;
        }
        if(ConfiguracionesActivas == false)
        {
            PanelDeConfiguracion.enabled = false;
        }
    }

    public void ButtonConfigOn()
    {
        ConfiguracionesActivas = true;
    }

    public void ButtonConfigOff()
    {
        ConfiguracionesActivas = false;
    }
}
