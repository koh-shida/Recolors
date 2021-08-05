using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllColor : MonoBehaviour
{
    ColorManager color_manager;

    // 色を持っているか持ってないか
    bool[] isHaving; 

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
    }

    // Update is called once per frame
    void Update()
    {



    }
}
