using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThuyLongDan : MonoBehaviour
{
    [SerializeField] private float speed;
    private bool hit;
    private float lifeTime;
    private Animator anim;
    private float direction;
    private BoxCollider2D coll;

    private void Awake() {
        anim = GetComponent<Animator>();
        coll = GetComponent<BoxCollider2D>();
    }
    private void Update() {
        if(hit) return;
        float movenentSpeed = speed * Time.deltaTime * direction;
        transform.Translate(movenentSpeed,0,0);
        lifeTime += Time.deltaTime;
        if(lifeTime > 0.9f){
            gameObject.SetActive(false);
        }
    }
    public void SetDirection(float _direction){
        lifeTime = 0;
        direction = _direction;
        gameObject.SetActive(true);
        hit = false;
        coll.enabled = true;
        //thay doi chieu cua hoat anh theo diretion
        float localScaleX = transform.localScale.x;
        if(Math.Sign(localScaleX)!=_direction){
            localScaleX = -localScaleX;
        }
        transform.localScale = new Vector3(localScaleX, transform.localScale.y, transform.localScale.z);
    }

    private void Deactivate(){
        gameObject.SetActive(false);
    }
}
