using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthSamurai : MonoBehaviour
{
    [Header("Health")]
    [SerializeField] private float startingHealthSamurai;
    public float currentHealthSamurai {get; private set;}
    private Animator anim;
    private bool dead;
    private void Awake() {
        currentHealthSamurai = startingHealthSamurai;
        anim = GetComponent<Animator>();
    }

    public void TakeDamageSamurai(float _damage){
        currentHealthSamurai = Mathf.Clamp(currentHealthSamurai - _damage, 0, startingHealthSamurai);
        if(currentHealthSamurai > 0 ){
            anim.SetTrigger("hurt");
        }
        else{
            anim.SetTrigger("die");
            gameObject.layer = 0;
            if(GetComponentInParent<SamuraiPatrol>()!=null)
                GetComponentInParent<SamuraiPatrol>().enabled = false;
            if(GetComponent<MeleeSamurai>()!=null)
                GetComponent<MeleeSamurai>().enabled = false;
        }

    }
    private void Deactivate(){
        gameObject.SetActive(false);
    }
}
