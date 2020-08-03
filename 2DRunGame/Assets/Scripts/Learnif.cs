using UnityEngine;

public class Learnif : MonoBehaviour
{

    // 判斷式 if
    // 判斷 布林植 來決定要執行哪種程式
    //範例:
    //判斷 玩家是否死亡 顯示遊戲結束

    private void Start()
    {
        //語法;
        //如果(布林值) {程式內容}
        //當布林值等於 true 時才會執行{} 內容

        if (true)
        {
            print("我使判斷式:p");
        }
    }

    public int score =100;
    public bool open;

    private void Update()
    {


            //語法
            //否則{程式內容}
            //當bool等於false 時才會用否則
            // else 一定要寫在 if 下方
            if (open)
            {
            print("開門!!!");
            }
            else
           {
            print("關門!!!");
           }

        //如果分數大於等於60分及格
        //如果分數大於等於40分補考
        //否則當掉

        if (score>=60)
        {
            print("及格");
        
        }
         else if (score>=40)
        {
            print("你可以補考~");
        }

        else if (score>= 20)
        {
            print("可付錢補考");

        }
        else
        {
            print("當掉");
        }

    }


}
