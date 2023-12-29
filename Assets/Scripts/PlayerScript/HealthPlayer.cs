using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPlayer : MonoBehaviour
{
    [Header("Health")]
    [SerializeField] private float startingHealthPlayer;
    public float currentHealthPlayer {get; private set;}
    private Animator anim;
    private bool dead;
    private void Awake() {
        currentHealthPlayer = startingHealthPlayer;
        anim = GetComponent<Animator>();
    }

    public void TakeDamage(float _damage){
        currentHealthPlayer = Mathf.Clamp(currentHealthPlayer - _damage, 0 , startingHealthPlayer);
        if(currentHealthPlayer > 0){
            anim.SetTrigger("hurt");
            
        }
        else{
            anim.SetTrigger("die");
            gameObject.layer = 0;
            if(GetComponent<PlayerMovement>() != null)
                GetComponent<PlayerMovement>().enabled = false;
            if(GetComponent<PlayerAttack>() != null)
                GetComponent<PlayerAttack>().enabled = false;
            if(GetComponent<PlayerAttackSkill>() != null)
                GetComponent<PlayerAttackSkill>().enabled = false;
        }
    }
    private void Deactivate(){
        gameObject.SetActive(false);
    }
}
