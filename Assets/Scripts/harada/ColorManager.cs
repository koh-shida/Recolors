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
        Green
    };

    


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void ColorStatusChange(Color_Type color)
    {
        switch (color)
        {
            case Color_Type.Blue:

                break;

            case Color_Type.Red:

                break;
            case Color_Type.Yellow:

                break;
            case Color_Type.Orange:

                break;
            case Color_Type.Purple:

                break;
            case Color_Type.Green:

                break;
        }

    } 
}
