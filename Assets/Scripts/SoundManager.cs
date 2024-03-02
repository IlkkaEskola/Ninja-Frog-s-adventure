using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{
    [SerializeField] Slider volumeSlider;

    void Start()
    {
        //Tarkistetaan onko äänenvoimakkuutta tallennettu aiemmin
        if (!PlayerPrefs.HasKey("musicVolume"))
        {
            //Jos ei ole tallennettu, asetetaan oletusarvoksi äänenvoimakkuus 1
            PlayerPrefs.SetFloat("musicVolume", 1);
            Load();  //Ladataan äänenvoimakkuuden arvo
        }
        else
        {
            Load();  //Ladataan tallennettu äänenvoimakkuuden arvo
        }
    }

    public void ChangeVolume()  //Kutsutaan, kun käyttäjä muuttaa äänenvoimakkuutta
    {
        AudioListener.volume = volumeSlider.value;
        Save();  //Tallennetaan äänenvoimakkuuden arvo
    }

    private void Load()  //Lataa tallennetun äänenvoimakkuuden arvon
    {
        volumeSlider.value = PlayerPrefs.GetFloat("musicVolume");
    }

    private void Save()  //Tallentaa nykyisen äänenvoimakkuuden arvon
    {
        PlayerPrefs.SetFloat("musicVolume", volumeSlider.value);
    }
}
