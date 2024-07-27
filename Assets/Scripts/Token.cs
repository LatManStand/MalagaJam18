using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Token : MonoBehaviour
{
    public Player player;
    public float verticalTimer;
    public float verticalOffset;
    public float horizontalTimer;


    public void MoveTo(Transform target)
    {
        AudioPlayer.Instance.PlaySFX(2);
        Sequence sequence = DOTween.Sequence();
        sequence.Append(
            transform.DOMove(transform.position + Vector3.up * verticalOffset, verticalTimer).SetEase(Ease.InOutElastic)).Append(
            transform.DOMove(target.position + Vector3.up * verticalOffset, horizontalTimer).SetEase(Ease.InOutElastic)).Append(
            transform.DOMove(target.position, verticalTimer).SetEase(Ease.InOutElastic)
        ).Play();
    }
}
