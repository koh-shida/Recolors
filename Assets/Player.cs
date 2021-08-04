using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// プレイヤー
/// </summary>
[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(GroundChecker))]
public class Player : MonoBehaviour {
    [SerializeField]
    float speed = 10;

    [Tooltip("大きくするとキビキビ動く（大きすぎるとバグる）")]
    [SerializeField]
    float speedFollowing = 30;

    [SerializeField]
    float jump = 5;


    RecolorsInputAction inputActions;
    Rigidbody2D rigid;

    GroundChecker groundChecker;


    void Awake() {
        rigid = GetComponent<Rigidbody2D>();
        groundChecker = GetComponent<GroundChecker>();

        inputActions = new RecolorsInputAction();

        inputActions.Player.Jump.started += JumpStarted; ;
    }

    void OnDisable() => inputActions.Disable();
    void OnDestroy() => inputActions.Disable();

    void OnEnable() => inputActions.Enable();


    void Update() {


    }

    private void JumpStarted(UnityEngine.InputSystem.InputAction.CallbackContext obj) {
        if (groundChecker.IsGround) {
            rigid.AddForce(new Vector2(0, jump), ForceMode2D.Impulse);
        }
    }


    void FixedUpdate() {
        var value = inputActions.Player.Move.ReadValue<Vector2>();

        var move = new Vector2(value.x * speed , 0);

        var moveForce = speedFollowing * (move - rigid.velocity);
        moveForce.y = 0;

        rigid.AddForce(moveForce);

    }
}
