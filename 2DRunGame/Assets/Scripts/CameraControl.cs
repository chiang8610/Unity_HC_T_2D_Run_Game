﻿using UnityEngine;

public class CameraControl : MonoBehaviour
{
    [Header("目標:要追蹤的物件")]
    public Transform target;
    [Header("追蹤速度"), Range(0, 100)]
    public float speed = 1;
    [Header("攝影機拍攝的上限與下限")]
    public Vector2 limit = new Vector2(0, 0.7f);

    //攝影機 上限 0  下限0.7


    /// <summary>
    /// 追蹤
    /// </summary>
    private void track()
    {
        Vector3 posA = transform.position;        //A點: 攝影機座標
        Vector3 posB = target.position;               //B點: 目標 座標

        posB.z = -10;                                           //攝影機 Z 軸固定-10
        posB.y = Mathf.Clamp(posB.y, limit.x, limit.y);

        //A點=差值(A點, B點 ,百分比)
        posA = Vector3.Lerp(posA, posB, speed * Time.deltaTime);

        transform.position = posA;         //攝影機座標=A點

    }

    // Late Update 在 Update後執行，
    private void LateUpdate()
    {
        track();
    }
}
