/**
 * This class contains health information for whatever entity that it is attached to.
 * @author Greggory Hickman, July 2020
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public int maxHealth; //The entity's maximum amount of hit points
    public int tempMaxHealth; //The entity's amount of temporary maximum hit points, which are added on top of the entity's maximum hit points
    public int currentHealth; //The entity's current amount of hit points
    public int tempHealth; //The entity's current amount of temporary hit points, which are additional hit points added on top of the entity's current hit points (not assosiated with tempMaxHealth)
    public int localTempMax; //The local maximum of temp HP

    public float timeBeforeNextHit; //The minimum amount of time in seconds after the entity is damaged before the entity can take damage again

    public bool isInvincible; //Is the entity currently undamagable?
    public bool isDead; //Is the entity currently dead?

    void Start()
    {
        isDead = false; //By default things are not dead

        //Set current health to max health
        currentHealth = maxHealth + tempMaxHealth;
    }

    void Update()
    {
        /**
         * Update the entity's living status and regulates HP so that nothing is illegal
         */
        //If current HP is below zero
        if (currentHealth < 0)
        {
            //Set it to zero because health being below zero is illegal
            currentHealth = 0;
        }

        //If temp HP is below zero
        if (tempHealth < 0)
        {
            //Set it to zero because health being below zero is illegal
            tempHealth = 0;
        }

        //If total HP is higher than total maximum HP
        if (currentHealth > maxHealth + tempMaxHealth)
        {
            //Lower current HP to be equal to the maximum health
            currentHealth = maxHealth + tempMaxHealth;
        }

        //If total HP is at zero
        if (currentHealth + tempHealth == 0)
        {
            //The entity is dead
            isDead = true;
        }
        //If total HP is at or above zero
        else if (currentHealth + tempHealth > 0)
        {
            //The entity is alive
            isDead = false;
        }

        /**
         * Update the local temp HP maximum so that the UI is updated and looks gucci
         */
        //If tempHealth is currently bigger than the old localTempMax
        if (localTempMax < tempHealth)
        {
            //Set the current tempHealth to be the new localTempMax
            localTempMax = tempHealth;
        }
        //If tempHealth reaches 0
        if (tempHealth <= 0)
        {
            //Reset localTempMax
            localTempMax = 0;
        }
    }

    /**
     * Heal the entity for a certain amount
     */
    public void Heal(int healing)
    {
        currentHealth += healing;
    }

    /**
     * Add some temporary HP
     */
    public void HealTempHP(int healing)
    {
        tempHealth += healing;
    }

    /**
     * Damage the entity for a certain amount
     */
    public void Harm(int damage)
    {
        //If the entity is not currently invincible
        if (!isInvincible)
        {
            //Take the amount of damage inflicted off of the temp HP first
            tempHealth -= damage;

            //If the damage inflicted caused temporary HP to drop below zero
            if (tempHealth < 0)
            {
                //Have the real HP take the rest of the damage
                currentHealth += tempHealth;
                //Then bring temp health back up to zero
                tempHealth = 0;
            }
            //Start the invince timer
            StartCoroutine("InvincibilityTimer");
        }
    }

    /**
     * Prevent the entity from being damaged for their invince period
     */
    private IEnumerator InvincibilityTimer()
    {
        //Set the entity to be invincible
        isInvincible = true;
        //Wait for the amount of time before the entity is allowed to be hit again
        yield return new WaitForSeconds(timeBeforeNextHit);
        //Remove the entity's invincibility
        isInvincible = false;
    }
}
