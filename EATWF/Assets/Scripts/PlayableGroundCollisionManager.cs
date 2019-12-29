using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayableGroundCollisionManager : MonoBehaviour
{
    GameObject player;
    
    // Start is called before the first frame update
    void Start()
    {
        player = transform.parent.gameObject;
    }
    
    void OnTriggerEnter(Collider collider)
    {
        player.GetComponent<PlayableMovingManager>().midAir = false;
    }
    
    void OnTriggerExit(Collider other)
    {
        player.GetComponent<PlayableMovingManager>().midAir = true;
    }
}
