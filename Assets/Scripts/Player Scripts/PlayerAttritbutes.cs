using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerAttritbutes : MonoBehaviour
{
    [SerializeField]
    private Image health_Stats, stamina_Stats;

    public void Display_AttributeStats(float health_value,float stamina_value)
    {
        health_value /= 100f;
        stamina_value /= 100f;


        stamina_Stats.fillAmount = stamina_value;
        health_Stats.fillAmount = health_value;
    }
}
