using UnityEngine;
using UnityEngine.SceneManagement; // 引用場景管理API

public class SceneControl : MonoBehaviour
{
    //方法要被按鈕呼叫需要設公開 public

    /// <summary>
    /// 切換場景
    /// </summary>
     private void ChangeScene( )
    {

        //切換場景
        //場景管理.載入場景("場景名稱")
        SceneManager.LoadScene("遊戲場景");
    }

    /// <summary>
    /// 離開遊戲
    /// </summary>
    private void Quit( )
    {
        //關閉遊戲
        //應用程式 離開
        Application.Quit();

    }

    //延遲呼叫方法 Invoke("方法名稱" ,延遲秒數)

    /// <summary>
    /// 延遲場景接換
    /// </summary>
    public void DelayChangScene()
    {
        Invoke("ChangeScene", 0.7f);
    }

    public void DelayQuit()
    {
        Invoke("Quit", 0.7f);

    }
}
