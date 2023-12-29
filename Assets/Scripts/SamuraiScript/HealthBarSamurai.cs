using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarSamurai : MonoBehaviour
{
    [SerializeField] private HealthSamurai healthSamurai;
    [SerializeField] private Image totalhealthBar;
    [SerializeField] private Image currenthealthBar;
    void Start()
    {
        totalhealthBar.fillAmount = healthSamurai.currentHealthSamurai / 10;
    }
    void Update()
    {
        currenthealthBar.fillAmount = healthSamurai.currentHealthSamurai / 10;
    }

}
