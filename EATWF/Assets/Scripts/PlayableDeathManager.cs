using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayableDeathManager : MonoBehaviour
{
    public GameObject sprite;

    private Health health;
    private PlayableMovementManager pmm;

    // Start is called before the first frame update
    void Start()
    {
        health = GetComponent<Health>();
        pmm = GetComponent<PlayableMovementManager>();
    }

    // Update is called once per frame
    void Update()
    {
        //If the player dies
        if (health.isDead)
        {
            //Kill the player
            sprite.SetActive(false);
            pmm.enabled = false;
        }
    }
}
