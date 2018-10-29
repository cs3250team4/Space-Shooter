using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Controller : MonoBehaviour {

    public ShipControl shipController;

    public Slider healthBar;
    public Image healthBarFill;
    public Color[] fillColour = new Color[3]; 

    public void Start()
    {
        healthBar.wholeNumbers = true;
        healthBar.minValue = 0;

        fillColour[0] = new Color(0, 255, 0);
        fillColour[1] = new Color(255, 194 , 0);
        fillColour[2] = new Color(255, 0, 0);
    }

    private void Update()
    {
        healthBar.maxValue = shipController.stats.maxHealth;
        healthBar.value = shipController.stats.currentHealth;

        healthBarFill.color = fillColour[0];
        if (healthBar.value > shipController.stats.maxHealth / 2) healthBarFill.color = fillColour[0];
        if (healthBar.value <= shipController.stats.maxHealth / 2) healthBarFill.color = fillColour[1];
        if (healthBar.value <= shipController.stats.maxHealth / 10) healthBarFill.color = fillColour[2];
    }

}
