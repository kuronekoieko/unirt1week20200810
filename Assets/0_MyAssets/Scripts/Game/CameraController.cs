﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

/// <summary>
/// Unityで解像度に合わせて画面のサイズを自動調整する
/// http://www.project-unknown.jp/entry/2017/01/05/212837
/// </summary>
public class CameraController : MonoBehaviour
{
    [SerializeField] Transform centerTf;
    public static CameraController i;
    void Start()
    {
        if (i == null) i = this;
    }

    void Update()
    {

    }

    private void LateUpdate()
    {
        var pos = transform.position;
        pos.x = centerTf.position.x;
        transform.position = pos;
    }
}
