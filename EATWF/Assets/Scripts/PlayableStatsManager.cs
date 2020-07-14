using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayableStatsManager : MonoBehaviour
{
    public GameObject healthBar;
    public GameObject tempHealthBar;
    public GameObject HPtext;

    private Health health;
    private HealthBarManager hbm;
    private HealthBarManager thbm;
    private Text text;

    // Start is called before the first frame update
    void Start()
    {
        //Initialize our objects
        health = GetComponent<Health>();
        hbm = healthBar.GetComponent<HealthBarManager>();
        thbm = tempHealthBar.GetComponent<HealthBarManager>();
        text = HPtext.GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        /**
         * Update the GUI health bar every frame to reflect how much health that the player has
         */
        //Calculate the percentage of health that the player currently has
        float healthPercent = 0;
        float tempHealthPercent = 0;
        //Prevent the possibility of diving by zero because that would be bad
        if (health.maxHealth != 0)
            healthPercent = (float)health.currentHealth / (float)(health.maxHealth + health.tempMaxHealth);
        if (health.localTempMax != 0)
            tempHealthPercent = (float)health.tempHealth / (float)health.localTempMax;

        //Set the health bar to show how much health the player has visually
        hbm.setFillPercent(healthPercent);
        thbm.setFillPercent(tempHealthPercent);

        //Set the health bar to show how much health the player has numerically
        if (health.currentHealth + health.tempHealth != 0)
        {
            text.text = "HP: " + (health.currentHealth + health.tempHealth) + "/" + (health.maxHealth + health.tempMaxHealth);
        }
        else
        {
            text.text = "YOU ARE DEAD";
        }
    }
}
