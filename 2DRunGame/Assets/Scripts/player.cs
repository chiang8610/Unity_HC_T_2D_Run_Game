﻿using UnityEngine;

public class player : MonoBehaviour
{
    #region 欄位
    [Header("移動速度"), Range(0, 1000)]
    public float speed = 5;
    [Header("跳躍高度"), Range(0, 1000)]
    public int jump = 350;
    [Header("血量"), Range(0, 2000)]
    public float hp = 500;

    public bool isGround; //是否在地板上
    public int coin;
   
    [Header("音效區域")]
    public AudioClip soundHit;
    public AudioClip soundSlide;
    public AudioClip soundJump;
    public AudioClip soundCoin;

    public Animator ani;
    public Rigidbody2D rig;
    public CapsuleCollider2D cap;
    public AudioSource aud;
    
    #endregion

    #region 方法

    /// <summary>
    /// 移動
    /// </summary>
    public void Move()
    {
        // Time.deltaTime 一禎的時間
        // Update 內移動 旋轉 運動 *Time.deltatime
        // 避免不同裝置執行速度不同
        transform.Translate(speed*Time.deltaTime, 0, 0);     // 變形的位移(x y z)

    }      


    /// <summary>
    ///  跳躍
    /// </summary>
    public void Jump()
    {
        //動畫控制器 設定布林值("參數名稱",布林植)
        //名稱.SetBool("bool名稱",是or否)
        //玩家是否按空白建
        bool space = Input.GetKeyDown(KeyCode.Space);

        //2D設限碰撞物件= 2D 物理 .  設限碰撞(起點,方向,長度,圖層-只使用在這圖層上,語法1<<圖層)
        RaycastHit2D hit = Physics2D.Raycast(transform.position + new Vector3(-0.05f, -1.1f), -transform.up, 0.01f, 1 << 8);

        if (hit)
        {
            isGround = true;      //如果碰到地板圖層 在地板上 = 是
            ani.SetBool("跳躍開關", false);    //在地板上不要跳  
        }
        else
        {
            isGround = false;     //如果碰到地板圖層 在地板上  = 否
        }
        //如果角設在地板上
        if (isGround)
        {

            //如果按下空白建
            if (space)
            {
                //動畫控制器.設定布林植("參數名稱"，布林植)
                ani.SetBool("跳躍開關", true);
                //剛體.添加推力(二維向量)
                rig.AddForce(new Vector2(0, jump));
                aud.PlayOneShot(soundJump, 0.5f);


            }
        }
    }

    /// <summary>
    /// 滑行
    /// </summary>


    public void Slide()
    {
        bool ctrl = Input.GetKey(KeyCode.LeftControl);
        ani.SetBool("滑行開關", ctrl);

        if (Input.GetKeyDown(KeyCode.LeftControl))   aud.PlayOneShot(soundSlide, 1.3f);
        

        if (ctrl)
        {
            cap.size = new Vector2(1.35f, 1.35f);
            cap.offset = new Vector2(-0.1f, -1.5f);
            

        }
        else
        {
            cap.size = new Vector2(1.35f, 3.6f);
            cap.offset = new Vector2(-0.1f, -0.4f);
        }

    }


    /// <summary>
    /// 吃金幣
    /// </summary>
    public void Eatcoin()
    {

    }

    /// <summary>
    /// 受傷
    /// </summary>
    public void Hit()
    {

    }
    /// <summary>
    /// 死亡
    /// </summary>
    public void Dead()
    {

    } /// <summary>
      /// 過關
      /// </summary>
    public void Pass()
    {

    }
    #endregion

    #region 事件
    private void Start()
    {
       

    }





    private void Update()
    {
        Jump();
        Slide();
        Move();



    }



    //繪製圖式的事件:繪製一些副助線條，只有在scenc看得到，玩家看不到
    private void OnDrawGizmos()
    {
        //圖示.顏色=顏色.紅色(靜態)
        Gizmos.color = Color.red;

        //圖示.繪製線(起點,終點)
        //transform 此物件的變形元件
        //transform.position 此物件的座標
        //transform.up 此物件上方           y
        //transform.right 此物件右方       x
        //transform.forward 此物件前方  z
        //如需要下 左 後 在上述方向加負號
        Gizmos.DrawRay(transform.position + new Vector3(-0.05f, -1.1f), -transform.up * 0.01f);

    }
    #endregion
}
