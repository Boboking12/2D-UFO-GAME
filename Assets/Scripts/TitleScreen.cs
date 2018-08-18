using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TitleScreen : MonoBehaviour {

    public Image optionsBackground;
    public Color[] colours;
    public Slider audioVolume;
 


    void Start ()
    {
        audioVolume.value = PlayerPrefs.GetFloat("Volume");
        
    }
	
	
	void Update ()
    {
		
	}



    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void ChangeColours(int colourValue)
    {
        if (colourValue == 0)
            optionsBackground.color = colours[0];
        if (colourValue == 1)
            optionsBackground.color = colours[1];
        if (colourValue == 2)
            optionsBackground.color = colours[2];
    }

    public void SetAudioVolume()
    {
        PlayerPrefs.SetFloat("Volume", audioVolume.value);
        PlayerPrefs.Save();
    }

}
