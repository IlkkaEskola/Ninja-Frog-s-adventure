using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{
    [SerializeField] Slider volumeSlider;

    void Start()
    {
        //Tarkistetaan onko ‰‰nenvoimakkuutta tallennettu aiemmin
        if (!PlayerPrefs.HasKey("musicVolume"))
        {
            //Jos ei ole tallennettu, asetetaan oletusarvoksi ‰‰nenvoimakkuus 1
            PlayerPrefs.SetFloat("musicVolume", 1);
            Load();  //Ladataan ‰‰nenvoimakkuuden arvo
        }
        else
        {
            Load();  //Ladataan tallennettu ‰‰nenvoimakkuuden arvo
        }
    }

    public void ChangeVolume()  //Kutsutaan, kun k‰ytt‰j‰ muuttaa ‰‰nenvoimakkuutta
    {
        AudioListener.volume = volumeSlider.value;
        Save();  //Tallennetaan ‰‰nenvoimakkuuden arvo
    }

    private void Load()  //Lataa tallennetun ‰‰nenvoimakkuuden arvon
    {
        volumeSlider.value = PlayerPrefs.GetFloat("musicVolume");
    }

    private void Save()  //Tallentaa nykyisen ‰‰nenvoimakkuuden arvon
    {
        PlayerPrefs.SetFloat("musicVolume", volumeSlider.value);
    }
}
