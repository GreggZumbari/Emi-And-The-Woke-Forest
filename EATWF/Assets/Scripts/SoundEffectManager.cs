using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundEffectManager : MonoBehaviour
{
    public AudioClip playerJump;

    /**
     * Player jump sound effect
     */
    public void a_playerJump(AudioSource a)
    {
        a.PlayOneShot(playerJump, 0.1f);
    }
}
