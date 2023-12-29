using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackSkill : MonoBehaviour
{
    [SerializeField] private float attackCooldown;
    [SerializeField] private Transform thuyLongDanPoint;
    [SerializeField] private GameObject[] thuyLongDans;

    private Animator animator;
    private float cooldownTime = Mathf.Infinity;

    private void Awake() {
        animator = GetComponent<Animator>();
    }
    private void Update() {
        if(Input.GetKeyDown(KeyCode.K) && cooldownTime > attackCooldown){
            StartCoroutine(AttackSkillThuyLongDan());
        }
        cooldownTime += Time.deltaTime;
    }
    private IEnumerator AttackSkillThuyLongDan(){
        animator.SetTrigger("thuylongdan");
        yield return new WaitForSeconds(0.9f);
        cooldownTime = 0;
        thuyLongDans[FindThuyLongDan()].transform.position = thuyLongDanPoint.position;
        thuyLongDans[FindThuyLongDan()].GetComponent<ThuyLongDan>().SetDirection(Mathf.Sign(transform.localScale.x));
    
    }
    private int FindThuyLongDan(){
        for(int i=0; i<thuyLongDans.Length; i++){
            if(!thuyLongDans[i].activeInHierarchy){
                return i;
            }
        }
        return 0;
    }
}
