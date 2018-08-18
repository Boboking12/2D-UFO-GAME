using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {

    public Text timerText;
    public Text healthText;
    public Slider healthSlider;
    public Image avatar;

	void Start ()
    {
		
	}
	
	void Update ()
    {
		
	}


    public void UpdateTimer(float timer)
    {
        timerText.text = timer.ToString("'Timer: '###.#");
        if (timer < 10)
            timerText.color = Color.red;
        else
            timerText.color = Color.green;
    }

    public void UpdateHealth (int health)
    {
        healthText.text = health.ToString();
        healthSlider.value = health;
        avatar.fillAmount = (float)health / 100;
    }
}
