using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeathSamurai : MonoBehaviour
{
    [SerializeField] private float startingHealthSamurai;
    private float currentHealth;
    private Animator animator;

    private void Awake() {
        currentHealth = startingHealthSamurai;
        animator = GetComponent<Animator>();
    }
    public void TakeDamageSamurai(float _damage){
        currentHealth = Mathf.Clamp(currentHealth - _damage, 0, startingHealthSamurai);
        if(currentHealth > 0){
            animator.SetTrigger("hurt");
        }
        else{
            animator.SetTrigger("die");
            if(GetComponentInParent<SamuraiPatrol>())
                GetComponentInParent<SamuraiPatrol>().enabled = false;
            if(GetComponent<MeleeSamurai>())
                GetComponent<MeleeSamurai>().enabled = false;
        }
    }
    private void Deactivate(){
        gameObject.SetActive(false);
    }
}
