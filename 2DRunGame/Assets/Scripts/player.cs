using System.Collections;
using System.Collections.Generic;
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
        //
        ani.SetBool("跳躍開關", true);
    }
    
    /// <summary>
    /// 滑行
    /// </summary>
    public void Slide()
    {
     
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
        Jump();

    }

    private void Update()
    {
        
    }
    #endregion
}
