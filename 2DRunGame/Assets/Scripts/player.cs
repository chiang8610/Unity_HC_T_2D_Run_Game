using UnityEngine;
using UnityEngine.UI;

public class player : MonoBehaviour
{
    #region 欄位
    [Header("移動速度"), Range(0, 1000)]
    public float speed = 5;
    [Header("跳躍高度"), Range(0, 1000)]
    public int jump = 350;
    [Header("血量"), Range(0, 2000)]
    public float hp = 500;
    [Header("血條")]
    public Image imageHp;
    private float hpMax;
    [Header("是否在地板")]
    public bool isGround; //是否在地板上
    [Header("金幣")]
    public int coin;
    
   
    [Header("音效區域")]
    public AudioClip soundHit;
    public AudioClip soundSlide;
    public AudioClip soundJump;
    public AudioClip soundCoin;

    [Header("金幣數量")]
    public Text textCoin;


    [Header("結束畫面")]
    public GameObject final;
    private bool dead;

    [Header("過關標題與金幣")]
    public Text textTitle;
    public Text textFinaCoin;

    [Header("其他")]
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
        RaycastHit2D hit = Physics2D.Raycast(transform.position + new Vector3(-0.05f, -1.1f), -transform.up, 0.2f, 1 << 8);

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
                isGround = true;

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
/// <param name="obj"></param>
    public void Eatcoin(GameObject obj)
    {
        coin++;                                                  //遞增1
        aud.PlayOneShot(soundCoin, 0.7f);          //播放音效
        textCoin.text = "金幣數量:" + coin;       //文字介面.文字= 字串 + 整數
        Destroy(obj,0);                                         //刪除(金幣物件，延遲時間)
    }
    


    /// <summary>
    /// 受傷
    /// </summary>
    public void Hit(GameObject obj)
    {
        hp -= 100;
       aud.PlayOneShot(soundHit, 1);
        imageHp.fillAmount = hp / hpMax;
       Destroy(obj);

        if (hp <= 0) Dead();
      
       

    }
   
    /// <summary>
    /// 死亡
    /// </summary>
    public void Dead()
    {
        ani.SetTrigger("死亡觸發");               //死亡動畫
        final.SetActive(true);                          //顯示結束畫面
        speed = 0;                                            //死掉後速度=0
        dead = true;
        textTitle.text = "失敗 哭哭.....";
        textFinaCoin.text = "本次金幣數量:" + coin;
    }

   
    


    /// <summary>
      /// 過關
      /// </summary>
    public void Pass()
    {
        speed = 0;                               //速度=0
        final.SetActive(true);             //顯示結束畫面
        textTitle.text = "大吉大利，今晚吃雞!";
        textFinaCoin.text = "本次金幣數量:" + coin;

    }
    #endregion

    #region 事件
    private void Start()
    {

        hpMax = hp;
    }





    private void Update()
    {

        if (dead) return;                                              //如果死亡 後面的動作不執行 直接跳出
        if (transform.position.y <= -5) Dead( );         //第二種死法

        Jump();
        Slide();
        Move();



    }



    // 碰撞(觸發)事件:
    //兩個物件必須有一個勾選 Is Triggrt
    // Enter 進入時執行一次
    // Stay 碰撞時執行一次約60次
    // Exit 離開時執行一次
    // 參數:紀錄碰撞到的碰撞資訊
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //如果 碰撞資訊.標籤 等於 金幣 吃掉金幣(碰撞資訊,遊戲物件)
        if (collision.tag == "金幣") Eatcoin(collision.gameObject);

        // 如果 碰到障礙物 受傷
        if (collision.tag == "障礙物") Hit(collision.gameObject);

        //如果 碰撞資訊.名稱 等於 傳送門 過關
        if (collision.name == "傳送門") Pass();
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
        Gizmos.DrawRay(transform.position + new Vector3(-0.05f, -1.1f), -transform.up * 0.2f);

    }
    #endregion
}
