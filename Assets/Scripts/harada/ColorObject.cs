using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 色付きオブジェクトにアタッチするクラス
/// </summary>

public class ColorObject : MonoBehaviour
{
    [Tooltip("シーン配置時に色を決定してください\nc_Maxは選択しないでください")]
    [SerializeField]
    ColorManager.Color_Type MyColor;

    // 色を持っているかどうか、外部から取得
    bool havingColor;

    // Start is called before the first frame update
    void Start()
    {
        // タグを変更
        tag = "ColorObject";

        havingColor = true;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public ColorManager.Color_Type GetColorType()
    {
        // 自分の持っている色を返却
        return MyColor;
    }

    public bool GethavingColor()
    {
        // 自分が色を持っているかどうか返却
        return havingColor;
    }

    public void TurnOnColor()
    {
        havingColor = true;
    }

    public void TurnOffColor()
    {
        havingColor = false;
    }
}
