using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    private SpriteRenderer sprite;
    private Animator anim;
    private int solanTanCong = 0;
    private float timeGiuaCacLanDanh = 0.3f;
    private float timeStartAttack = 0f;
    private PlayerMovement playerMovement;

    private void Awake() {
        sprite = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        playerMovement =  GetComponent<PlayerMovement>();
    }
    private void Update() {
        Attack();
    }
    private void Attack(){
        if(Input.GetKeyDown(KeyCode.J)){
            playerMovement.enabled = false;
            float currentTime = Time.time;
            float timeSinceLastAttack = currentTime - timeStartAttack;

            if (solanTanCong == 0 || timeSinceLastAttack > timeGiuaCacLanDanh){
                // Reset nếu đã vượt quá thời gian giữa các lần nhấn
                solanTanCong = 1;
            } else {
                // Tăng số lần tấn công nếu thỏa mãn điều kiện
                solanTanCong++;
            }

            // Lưu thời điểm cuối cùng nhấn J
            timeStartAttack = currentTime;

            // Kích hoạt trạng thái tấn công tương ứng
                switch (solanTanCong){
                    case 1:
                        anim.SetTrigger("attack1");
                        break;
                    case 2:
                        anim.SetTrigger("attack2");
                        break;
                    case 3:
                        anim.SetTrigger("attack3");
                        solanTanCong = 0; // Reset về lần đầu tiên sau khi tấn công lần thứ 3
                        break;
                    default:
                        break;
                }
        }
        else if(Input.GetKeyUp(KeyCode.J)){
            playerMovement.enabled = true;
        }
        if(Input.GetKey(KeyCode.S)){
            anim.SetTrigger("shield");
        }
    }    
    
}
