using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LearmAPI : MonoBehaviour
{
    //非靜態需要
    //1.實體物件或元件 (Unity 階層面板)
    //2.欄位
    //先看場景上有的物件和元件
    public GameObject sphere;

    public Transform tra;

    public Transform cube;

    public Light Directional;

    public Camera Main;

    private void Start()
    {
        // [取得] 屬性 Peoperties
        //***語法:
        //print(欄位名稱.屬性)
        print(sphere.layer);

        print("球的座標:" + tra.position);

        //[設定]屬性 Peoperties
        //***語法:
        //欄位名稱.屬性 = 值
        tra.localScale = new Vector3(7, 7, 7);


        //練習:
        //1.控制燈光顏色為紅色   Light

        Directional.color = new Color(0.8f, 0, 0);
        

        //2.設定燈光恢復預設值   Light

        Directional.Reset();


        //3.調整攝影機尺寸 3        Camera

        Main.orthographicSize = 3;


    }

    private void Update()
    {

        //[使用]方法 Methofs
        //****語法 :
        // 欄位名稱.方法(對應的引數)
        cube.Rotate(0,0,10);          //以秒為單位1/s  10
        cube.Translate(1, 0, 0);
       

    }
}
