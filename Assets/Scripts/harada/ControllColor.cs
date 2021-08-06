using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllColor : MonoBehaviour
{
    ColorManager color_manager;

    GameObject[] Circles;

    // 色を持っているか持ってないか
    bool[] isHaving;

    // 現在の能力の指標
    int index_CurPow = -1;

    public void SetInputActions(RecolorsInputAction inp)
    {
        inp.Player.SwitchAbility.started += SwitchAbilityStarted;
    }

    // Start is called before the first frame update
    void Start()
    {
        // マネージャーを取得
        color_manager = GameObject.FindObjectOfType<ColorManager>();

        // ブール初期化
        isHaving = new bool[(int)ColorManager.Color_Type.c_Max];

        for(var i = 0; i < (int)ColorManager.Color_Type.c_Max; ++i)
        {
            isHaving[i] = false;
        }

        // サークル取得
    }

    // Update is called once per frame
    void Update()
    {



    }

    public void SetColorActive(ColorManager.Color_Type col)
    {
        isHaving[(int)col] = true;
    }

    private void SwitchAbilityStarted(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        // 関数が呼ばれているかチェック
        Debug.Log("SwtichAbility Working");

        // 能力を持っているか判定
        var fal_num = 0;

        for (var i = 0; i < (int)ColorManager.Color_Type.c_Max; ++i)
        {
            fal_num++;

            if (isHaving[i])
            {
                break;
            }
        }

        // 能力を一つも持ってない場合
        if (fal_num == 0)
        {
            return;
        }
        else
        {
            // 色の切り替え処理
            for (var j = 0; ; j++)
            {
                index_CurPow++;

                if (index_CurPow >= (int)ColorManager.Color_Type.c_Max)
                {
                    index_CurPow = 0;
                }

                // インデックスに対応する色を持っていたらブレーク
                if (isHaving[index_CurPow])
                {
                    GetComponent<Player>().SetPlayerColor((ColorManager.Color_Type)index_CurPow);

                    break;
                }

                if (j > (int)ColorManager.Color_Type.c_Max)
                {
                    break;
                }
            }

        }
    }
}
