using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerZone : MonoBehaviour
{
    [Header("Teleport Position")]
    public Transform teleportPosition; // 텔레포트 할 위치
    public bool applyYRotationOffset = false; // Y축 회전을 적용할지 여부
    public bool invertZOffset = false; // Z축 반전이 필요한 트리거: Y축 회전과 세트
    //public float zOffset = 0f; // 보정이 필요하게 되면 조정

    // 플레이어 Teleport
    public void TeleportPlayer(Transform playerTransform)
    {
        // 트리거와 플레이어의 상대적인 위치 계산하여 이동(끊기는 느낌 안나게)
        Vector3 playerOffset = playerTransform.position - transform.position;
        
        // z축 반전: y값 180도 회전이 적용되는 트리거에서 필요
        if (invertZOffset)
        {
            playerOffset.z = -playerOffset.z;
        }
        
        // 보정이 필요하게 되면 조정
        //playerOffset.z += zOffset;

        // 위치 설정
        playerTransform.position = teleportPosition.position + playerOffset;
        
        // y축 회전이 적용 된 경우
        if (applyYRotationOffset)
        {
            playerTransform.rotation = Quaternion.Euler(
                playerTransform.rotation.eulerAngles.x,
                playerTransform.rotation.eulerAngles.y + 180f,
                playerTransform.rotation.eulerAngles.z
            );
        }
    }

    // 플레이어가 트리거에 들어갔을 때
    private void OnTriggerEnter(Collider hitobject)
    {
        if (hitobject.CompareTag("TestPlayer"))
        {
            Transform playerTransform = hitobject.transform;
            TeleportPlayer(playerTransform);
        }
    }
}