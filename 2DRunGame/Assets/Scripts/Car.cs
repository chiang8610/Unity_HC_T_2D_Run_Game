using UnityEngine;

public class Car : MonoBehaviour
{
    //欄位 field :儲存資料
    //欄位語法
    //欄位類型 欄位名稱 結束符號

    //整數int:沒有小數點值的數值，例:1、100、-999
    //浮點數 float : 有小數點值的數值，例:1.234、-999.9
    //字串 string : 文字，例:紅水、xxx@gmail.com
    //布林值 bool : 是、否，例:true、false

    //資料
    //品牌、cc數、重量、速度、是否有天窗、顏色
    string brand;
    int cc;
    float weight;
    bool window;
    float speed;

    //類別、成員命名規則
    //不允許
    //1. 特殊符號 例:#*@ 空格
    //2. 數字開頭 例:9cc
    //3. 保留字 例:class int bool

    //允許
    //1. 底線 例:player_a
    //2. 數字中間後面 例:cc9
    //3. 中文 例:角色速度(不建議)
}
