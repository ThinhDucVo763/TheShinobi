using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private HealthPlayer playerHealth;
    [SerializeField] private Image totalhealthBar;
    [SerializeField] private Image currenthealhtBar;

    private void Start() {
        totalhealthBar.fillAmount = playerHealth.currentHealthPlayer / 10;
        
    }
    private void Update() {
        currenthealhtBar.fillAmount = playerHealth.currentHealthPlayer / 10;
        
    }
}
