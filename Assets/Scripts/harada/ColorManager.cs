using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorManager : MonoBehaviour
{
    // 各オブジェクトに変数を作成して設定
    public enum Color_Type
    {
        Blue = 0,
        Red,
        Yellow,
        Orange,
        Purple,
        Green,
        c_Max
    };

    // 色の個数分リストを作成
    List<ColorObject>[] array_listColors;

    // Start is called before the first frame update
    void Start()
    {
        // それぞれの色のリストを初期化
        array_listColors = new List<ColorObject>[(int)Color_Type.c_Max];

        for (var i = 0; i < (int)Color_Type.c_Max; ++i)
        {
            array_listColors[i] = new List<ColorObject>();
        }

        // 色付きのオブジェクトを探して各リストに格納
        var list_GameObject = new List<GameObject>();
        list_GameObject.AddRange(GameObject.FindGameObjectsWithTag("ColorObject"));

        for (var i = 0; i < (int)Color_Type.c_Max - 1; ++i)
        {
            for (var j = 0; j < list_GameObject.Count; ++j)
            {
                var its_color = list_GameObject[j].GetComponent<ColorObject>();

                // 取得できたかチェック
                if (its_color != null)
                {
                    // 色のタイプを取得、比較
                    if (i == (int)its_color.GetColorType())
                    {
                        // リストに追加
                        array_listColors[i].Add(its_color);
                    }
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    // 特定の色を白黒に変更
    public void TurnMonochrome(Color_Type color)
    {
        // 白黒に変更する色
        var c_num = (int)color;

        // iは色に対応する数字
        for (var i = 0; i < (int)Color_Type.c_Max - 1; ++i)
        {
            if (c_num == i)
            {
                for (var j = 0; j < array_listColors[i].Count; ++j)
                {
                    array_listColors[i][j].TurnOffColor();
                }

                break;
            }
        }
    }

    public void RecoverColor(Color_Type color)
    {
        // 復活させる色
        var c_num = (int)color;

        // iは色に対応する数字
        for (var i = 0; i < (int)Color_Type.c_Max - 1; ++i)
        {
            if (c_num == i)
            {
                for (var j = 0; j < array_listColors[i].Count; ++j)
                {
                    array_listColors[i][j].TurnOnColor();
                }

                break;
            }
        }
    }
}
