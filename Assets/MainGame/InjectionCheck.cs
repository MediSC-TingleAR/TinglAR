using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InjectionCheck : MonoBehaviour
{
    public event Action onInjected;

    private bool IsFinish { get; set; }
    [SerializeField] private ParticleSystem _particleSystem;


    void Start()
    {
        _particleSystem?.gameObject.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (IsFinish)
            return;

        _particleSystem?.gameObject.SetActive(true);
        _particleSystem?.Play();
        IsFinish = true;

        // 캐릭터 부활 애니메이션 작동
        ReviveCharacter();

        // 병균 공격 멈춤
        StopAttack();

        onInjected?.Invoke();
    }

    private void ReviveCharacter()
    {

    }

    private void StopAttack()
    {

    }
}
