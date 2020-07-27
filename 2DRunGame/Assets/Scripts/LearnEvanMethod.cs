using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LearnEvanMethod : MonoBehaviour
{
    // 事件:在特定時間會自動執行

    // 開始:在播放遊戲後會執行一次 初始化 血量滿
    // 輸出 print("訊息") - 將訊息輸出到儀表板 - 測試用

    private void Start()
    {
        print("哈囉，沃德~");

        //  呼叫方法
        //  語法 : 方法名稱( );
        Test();
        Test();

        ShootFire();

        // 呼叫有參數的方法時要輸入對應的引數
        Test2(999);
        Test2(123456);

        Shoot("電");
        Shoot("水");

        //有預設值的參數可以不填寫
        Drive(125, "右邊");
        Drive(999);

        // 多個預設值參數時可以用 參數名稱 : 指定
        Drive(777, sound :"蹦蹦");

    }

    // 更新事件 : 一秒執行約60次 ， 持續執行，例如:移動  監聽玩家輸入   
    private void Update()
    {
        print("嗨，我在更新   ><");
    }

    //  方法 : 儲存演算法與較複雜程式的區塊

    //  *****語法:
    //  修飾詞 傳回類型  方法名稱  (參數) { 程式內容  }
    //  無傳回 void
    //  方法名稱 : unity 習慣大寫開頭
    //  事件與方法差異 : 事件名稱為藍色，方法為白色
    //  事件與方法差異 : 事件自動執行，方法不會，需要呼叫，從事件呼叫
    public void Test()
    {
        print("測試!!!");
    }


    // RPG: 施放火球
    public void ShootFire( )
    {
        print("施放火球!!!");

    }
    /// <summary>
    /// 施放技能
    /// </summary>
    /// <param name="prop">屬性</param>
    public void Shoot(string prop)
    {
        print("施放" + prop +"球!!!");
        print("執行動畫");
   
    }

    //  參數語法 (參數類型 參數名稱 ， 參數類型 參數名稱，...............)
    // 參數與欄位相同但不需要修飾詞
    public void Test2(int number)
    {
        print("我是測試  2  號，你所輸入的數字為");
        print(number);

         
    }


    //  參數預設值 :選填是參數
    //  語法 : 類型  名稱= 值
    //  有預設值的參數須寫在最右邊

    public void Drive(int speed, string direction = "前方", string sound = "咻咻")
    {
        print("時速 : " + speed);
        print("開車方向 : " + direction);
        print("開車音效 :" + sound);
    }
}
