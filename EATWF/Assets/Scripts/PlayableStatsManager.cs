using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayableStatsManager : MonoBehaviour
{
    public GameObject healthBar;

    private Health health;
    private HealthBarManager hbm;

    // Start is called before the first frame update
    void Start()
    {
        //Initialize our objects
        health = GetComponent<Health>();
        hbm = healthBar.GetComponent<HealthBarManager>();
    }

    // Update is called once per frame
    void Update()
    {
        /**
         * Update the GUI health bar every frame to reflect how much health that the player has
         */
        float healthPercent = (float)health.currentHealth / (float)health.maxHealth;
        Debug.Log(healthPercent);
        hbm.setFillPercent(healthPercent);
    }
}
