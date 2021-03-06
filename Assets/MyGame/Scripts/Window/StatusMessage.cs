﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 상태매시지 클래스
/// </summary>
public class StatusMessage : MonoBehaviour
{
    public Text message;
    public Animator anim;

    public float coolTime = 2.5f;
    float currTime;
    bool locked;

    private void Update()
    {
        if(locked)
        {
            currTime += Time.deltaTime;
            if (currTime > coolTime)
                locked = false;
        }
    }

    public void SetMsg(string msg)
    {
        if (locked)
            return;
        SingleTon.instance.StateSound();
        message.text = msg;
        anim.SetTrigger("On");
        locked = true;
        currTime = 0f;
    }
}
