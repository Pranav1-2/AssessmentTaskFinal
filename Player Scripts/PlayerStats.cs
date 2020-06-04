using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour 
{

    [SerializeField]
    private Image health_Stats, stamina_Stats;
    //fill the bar for health and decrease every time health decreases
    public void Display_HealthStats(float healthValue) 
    {

        healthValue /= 100f;

        health_Stats.fillAmount = healthValue;

    }

    //fill the bar for stamina and decrease every time player is sprinting
    public void Display_StaminaStats(float staminaValue) 
    {

        staminaValue /= 100f;

        stamina_Stats.fillAmount = staminaValue;

    }


} // class





























