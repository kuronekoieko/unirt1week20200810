using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class HammerController : MonoBehaviour
{
    [SerializeField] bool isStartLeft;
    void Start()
    {
        float dir = isStartLeft ? 1 : -1;
        Sequence sequence = DOTween.Sequence()
        .Append(transform.DORotate(Vector3.right * dir * 180, 5).SetRelative().SetEase(Ease.InOutQuart))
        .Append(transform.DORotate(-Vector3.right * dir * 180, 5f).SetRelative().SetEase(Ease.InOutQuart));
        sequence.SetLoops(-1);
    }


}
