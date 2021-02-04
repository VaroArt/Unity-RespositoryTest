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
    float MasterVolume;
    float BgVolumen;
    float FxVolumen;
    float MusicVolumen;

    public Image SaveIcon;
    public Animator Saveanim;

    public Toggle FullscreenBool;
    public Slider MasterVolumeSlider;
    public Slider BgVolumeSlider;
    public Slider FxVolumeSlider;
    public Slider MusicVolumeSlider;
    public Dropdown QualityDropdown;

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
        //resolutionDropdown.value = currentResolutionIndex;
        resolutionDropdown.RefreshShownValue();
        LoadSettings(currentResolutionIndex);
        Debug.Log("Actual Resolution: " + Screen.currentResolution);
    }

    public void Update()
    {
        ConfigOnOffFunc();
    }

    public void SetResolution (int resolutionIndex) //Actualiza la resolucion del juego
    {
        Resolution resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen, resolution.refreshRate);
        Debug.Log("Set Resolution: " + Screen.currentResolution);
    }

    public void SetVolume (float volume) //volumen General
    {
        AudioMix.SetFloat("MasterVol", volume);
        MasterVolume = volume;
        Debug.Log("Actual Master Volume: " + volume);
    }

    public void BgVol (float volume) //volumen BG
    {
        BgVolume.audioMixer.SetFloat("BgVol", volume);
        BgVolumen = volume;
        Debug.Log("Actual Bg Volume: " + volume);
    }

    public void FxVol (float volume) //Volumen Fx
    {
        FxVolume.audioMixer.SetFloat("FxVol", volume);
        FxVolumen = volume;
    }

    public void MusicVol (float volume) //Volumen Musica
    {
        MusicVolume.audioMixer.SetFloat("MusicVol", volume);
        MusicVolumen = volume;
    }

    public void SetQuality(int qualityIndex) //Calidad Grafica
    {
        QualitySettings.SetQualityLevel(qualityIndex);
        Debug.Log("Actual Quality: " + qualityIndex);
        QualityDropdown.value = qualityIndex;
    }

    public void SetFullscreen (bool isFullscreen) //Pantalla Completa
    {
        Screen.fullScreen = isFullscreen;
        Debug.Log("Fullscreen Set: " + isFullscreen);

        if (isFullscreen == true)
        {
            FullscreenBool.isOn = true;
        }
        if (isFullscreen == false)
        {
            FullscreenBool.isOn = false;
        }
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

    public void SaveAnimation()
    {

    }

    public void SaveSettings()
    {
        PlayerPrefs.SetInt("QualitySettingsPreference", QualityDropdown.value);
        PlayerPrefs.SetInt("ResolutionPreference", resolutionDropdown.value);
        PlayerPrefs.SetInt("FullscreenPreference", System.Convert.ToInt32(Screen.fullScreen));
        PlayerPrefs.SetFloat("MasterVolPreference", MasterVolume);
        PlayerPrefs.SetFloat("BgVolPreference", BgVolumen);
        PlayerPrefs.SetFloat("FxVolPreference", FxVolumen);
        PlayerPrefs.SetFloat("MusicVolPreference", MusicVolumen);
        Debug.Log("Saved");
    }

    public void LoadSettings(int currentResolutionIndex)
    {
        if (PlayerPrefs.HasKey("QualitySettingsPreference"))
        {
            QualityDropdown.value = PlayerPrefs.GetInt("QualitySettingsPreference");
            Debug.Log("Loadeded Quality: " + QualityDropdown.value);
        }
        else
        {
            Debug.LogError("Quality Not Set");
        }

        if (PlayerPrefs.HasKey("ResolutionPreference"))
        {
            resolutionDropdown.value = PlayerPrefs.GetInt("ResolutionPreference");
            Debug.Log("Resolution Loaded: " + Screen.currentResolution);
        }
        else
        {
            resolutionDropdown.value = currentResolutionIndex;
            Debug.LogError("Resolution Not Loaded");
        }

        if (PlayerPrefs.HasKey("FullscreenPreference"))
        {
            Screen.fullScreen = System.Convert.ToBoolean(PlayerPrefs.GetInt("FullscreenPreference"));
            FullscreenBool.isOn = System.Convert.ToBoolean(PlayerPrefs.GetInt("FullscreenPreference"));
            Debug.LogWarning("FullScreen Loaded");
        }
        else
        {
            Screen.fullScreen = true;
            Debug.LogError("Defalut Fullscreen");
        }

        if (PlayerPrefs.HasKey("MasterVolPreference"))
        {
            MasterVolumeSlider.value = PlayerPrefs.GetFloat("MasterVolPreference");
            Debug.Log("Loaded Master Volume: " + MasterVolume);
        }
        else
        {
            MasterVolumeSlider.value = PlayerPrefs.GetFloat("MasterVolPreference");
            Debug.LogError("Error: Master Volume Doesn't load Correctly: " + MasterVolume);
        }

        if (PlayerPrefs.HasKey("BgVolPreference"))
        {
            BgVolumeSlider.value = PlayerPrefs.GetFloat("BgVolPreference");
            Debug.Log("Load Bg Volume: " + BgVolumen);
        }
        else
        {
            BgVolumeSlider.value = PlayerPrefs.GetFloat("BgVolPreference");
            Debug.LogError("Error: Bg Volume Doesn't load Correctly: " + BgVolumen);
        }

        if (PlayerPrefs.HasKey("FxVolPreference"))
        {
            FxVolumeSlider.value = PlayerPrefs.GetFloat("FxVolPreference");
            Debug.Log("Load Fx Volume: " + FxVolumen);
        }
        else
        {
            FxVolumeSlider.value = PlayerPrefs.GetFloat("FxVolPreference");
            Debug.LogError("Error: Fx Volume Doesn't load Correctly: " + FxVolumen);
        }

        if (PlayerPrefs.HasKey("MusicVolPreference"))
        {
            MusicVolumeSlider.value = PlayerPrefs.GetFloat("MusicVolPreference");
            Debug.Log("Load Music Volume: " + MusicVolumen);
        }
        else
        {
            MusicVolumeSlider.value = PlayerPrefs.GetFloat("MusicVolPreference");
            Debug.LogError("Error: Music Volume Doesn't load Correctly: " + MusicVolumen);
        }
    }
}
