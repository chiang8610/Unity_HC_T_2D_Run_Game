using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

public class player : MonoBehaviour
{
    #region 欄位
    [Header("移動速度"), Range(0,1000)]
    public float speed = 5;
    [Header("跳躍高度"), Range(0, 1000)]
    public int jump = 350;
    [Header("血量"), Range(0, 2000)]
    public float hp = 500;

    public bool isGround;
    public int coin;

    [Header("音效區域")]
    public AudioClip soundHit;
    public AudioClip soundSlide;
    public AudioClip soundJump;
    public AudioClip soundCoin;

    public Animator  ani;
    public Rigidbody2D ride;
    public CapsuleCollider2D cap;
    #endregion

    #region 方法

    /// <summary>
    /// 移動
    /// </summary>
    public void Move()
    {
       
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
        ani.SetBool("跳躍開關", space);
     
    }

    /// <summary>
    /// 滑行
    /// </summary>
   

    public void Slide()
    {
        bool ctrl = Input.GetKeyDown(KeyCode.LeftControl);
        ani.SetBool("滑行開關", ctrl);

       
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

    public CapsuleCollider2D Cap;

    

    private void Update()
    {
        Jump();
        Slide();

        if ( Input.GetKeyDown(KeyCode.LeftControl))
      

        {
            Cap.size = new Vector2(1.35f,1.35f);
            Cap.offset = new Vector2(-0.1f, -1.5f);
        }

        else
        {
            Cap.size = new Vector2(1.35f, 3.6f);
            Cap.offset = new Vector2(-0.1f, -0.4f);
        }
    }
    #endregion
}
