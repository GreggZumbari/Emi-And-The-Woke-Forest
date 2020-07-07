using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityBehaviorManager : MonoBehaviour
{
    public GameObject player;

    public bool isHarmful;
    public bool touchingPlayer;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Player collision and damage
        if (touchingPlayer && isHarmful)
        {
            player.GetComponent<BoxCollider>().enabled = false;
        }
    }
}
