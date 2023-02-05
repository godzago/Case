using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class GoldUI : MonoBehaviour
{

    [SerializeField] Transform scoreAreaTransform;
    Sequence goldAnimation;

    Rigidbody rgb;

    void Start()
    {
        rgb = GetComponent<Rigidbody>();
        SetAnim();
    }

    void SetAnim()
    {
        scoreAreaTransform = GameObject.FindGameObjectWithTag("ScorArea").transform;
        goldAnimation = DOTween.Sequence();

        goldAnimation.Append(transform.DOMove(scoreAreaTransform.position, 2).SetEase(Ease.InOutBack)).OnComplete(() => Destroy(gameObject));
    }
}
