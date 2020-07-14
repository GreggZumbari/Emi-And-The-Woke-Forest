/**
 * This class manages UI health bars
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarManager : MonoBehaviour
{
    public float fillPercent;

    // Start is called before the first frame update
    void Start()
    {
        fillPercent = 1; //By default the health bar is full
    }

    public void setFillPercent(float percent)
    {
        GetComponent<Image>().fillAmount = percent;
    }
}
