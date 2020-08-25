using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class IronBlockController : MonoBehaviour
{
    [SerializeField] float startDelay;
    [SerializeField] Collider collider;
    void Start()
    {
        Sequence sequence = DOTween.Sequence()
        .AppendInterval(startDelay)
        .AppendCallback(() =>
        {
            // collider.enabled = true;
        })
        .Append(transform.DOMoveY(20, 5).SetRelative().SetEase(Ease.Linear))
        .AppendCallback(() =>
        {
            // collider.enabled = false;
        })
        .Append(transform.DOMoveY(-20, 0.5f).SetRelative().SetEase(Ease.Linear))
        .AppendInterval(1);
        sequence.SetLoops(-1);
    }



}
