using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class IronBlockController : MonoBehaviour
{

    void Start()
    {
        Sequence sequence = DOTween.Sequence()
        .Append(transform.DOMoveY(20, 5).SetRelative().SetEase(Ease.Linear))
        .Append(transform.DOMoveY(-20, 0.5f).SetRelative().SetEase(Ease.Linear))
        .AppendInterval(1);
        sequence.SetLoops(-1);
    }



}
