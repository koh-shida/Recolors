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

    GameObject foot;

    bool isColor = false;
    ColorManager.Color_Type current;

    ColorManager manager;
    Vector3 respawnPos;

    Renderer rend;

    void Awake() {
        respawnPos = transform.position;

        isColor = false;

        foot = transform.GetChild(0).gameObject;

        rigid = GetComponent<Rigidbody2D>();
        groundChecker = GetComponent<GroundChecker>();

        rend = GetComponent<Renderer>();

        inputActions = new RecolorsInputAction();

        inputActions.Player.Jump.started += JumpStarted;
        inputActions.Player.UseAbility.started += UseAbilityStarted;
        inputActions.Player.UseAbility.canceled += UseAbilityCanceled;
        //inputActions.Player.


    }


    private void Start() {
        manager = GameObject.Find("GameMaster").GetComponent<ColorManager>();
    }

    private void UseAbilityStarted(UnityEngine.InputSystem.InputAction.CallbackContext obj) {
        if (!isColor) {
            return;
        }
        switch (current) {
            case ColorManager.Color_Type.Blue:
                var scale=transform.localScale;
                scale.y = 0.3f;
                transform.localScale = scale;
                break;
            case ColorManager.Color_Type.Red:
                break;
            case ColorManager.Color_Type.Yellow:
                break;
            case ColorManager.Color_Type.Orange:
                break;
            case ColorManager.Color_Type.Purple:
                break;
            case ColorManager.Color_Type.Green:
                break;
            case ColorManager.Color_Type.c_Max:
                break;
            default:
                break;
        }
    }
    private void UseAbilityCanceled(UnityEngine.InputSystem.InputAction.CallbackContext obj) {
        if (!isColor) {
            return;
        }
        switch (current) {
            case ColorManager.Color_Type.Blue:
                var scale = transform.localScale;
                scale.y = 1.0f;
                transform.localScale = scale;
                break;
            case ColorManager.Color_Type.Red:
                break;
            case ColorManager.Color_Type.Yellow:
                break;
            case ColorManager.Color_Type.Orange:
                break;
            case ColorManager.Color_Type.Purple:
                break;
            case ColorManager.Color_Type.Green:
                break;
            case ColorManager.Color_Type.c_Max:
                break;
            default:
                break;
        }
    }

    void OnDisable() => inputActions.Disable();
    void OnDestroy() => inputActions.Disable();

    void OnEnable() => inputActions.Enable();


    void Update() {
        //下にすり抜ける用
        var value = inputActions.Player.Move.ReadValue<Vector2>();
        var active=value.y > -0.8f;

        if (foot.activeSelf != active) {
            foot.SetActive(active);
        }

    }

    //ジャンプ
    private void JumpStarted(UnityEngine.InputSystem.InputAction.CallbackContext obj) {
        if (groundChecker.IsGround) {
            rigid.AddForce(new Vector2(0, jump), ForceMode2D.Impulse);
        }
    }


    void FixedUpdate() {
        //横移動
        var value = inputActions.Player.Move.ReadValue<Vector2>();

        var move = new Vector2(value.x * speed , 0);

        var moveForce = speedFollowing * (move - rigid.velocity);
        moveForce.y = 0;

        rigid.AddForce(moveForce);

    }

    void Death() {
        transform.position = respawnPos;
        var cameraPos = Camera.main.transform.position;
        cameraPos.x = respawnPos.x;
        Camera.main.transform.position = cameraPos;
    }


    private void OnTriggerEnter2D(Collider2D collision) {
        var colorObj=collision.GetComponent<ColorObject>();
        if (colorObj != null) {
            current = colorObj.GetColorType();
            manager.TurnMonochrome(current);
            rend.material.color = ColorManager.GetOriginalColor(current);
            isColor = true;

            if (current == ColorManager.Color_Type.Blue) {
                collision.GetComponent<Collider2D>().isTrigger = false;
                Death();
            }
        }
    }
}
