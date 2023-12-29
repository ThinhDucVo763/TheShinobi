using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMovement : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private float tileDichuyen = 0.5f;

    private void Update() {
        if(player != null){
            float positionPlayer = player.position.x;

            Vector3 newPosition = new Vector3(positionPlayer * tileDichuyen, transform.position.y,  transform.position.z);
            transform.position = newPosition;
        }
    }
}
