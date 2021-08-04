using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 床との接地判定クラス
/// </summary>
public class GroundChecker : MonoBehaviour {

    GameObject groundGameObject = null;
    public bool IsGround { get => groundGameObject!=null; }

    [Tooltip("床とみなす角度")]
    [SerializeField]
    float goundThresholdAngle = 30;


    void OnCollisionStay2D(Collision2D other) {
        if (groundGameObject != null) {
            return;
        }
        foreach (var contact in other.contacts) {
            Vector2 dir = Vector2.down;

            Vector2 contactObjectDown = -contact.normal;


            if (Vector2.Angle(contactObjectDown, dir) < goundThresholdAngle) {
                groundGameObject=other.gameObject;
                break;
            }

        }
    }

    private void OnCollisionExit2D(Collision2D other) {
        if (groundGameObject==other.gameObject) {
            groundGameObject = null;
        }
    }
}