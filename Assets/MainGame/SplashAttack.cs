using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.EventSystems;
using NRKernal;
using TMPro;
using UnityEngine.Events;
using System;
using MainGame;

public class SplashAttack : MonoBehaviour
{
    public event Action<int> onKillEnemy;
    private List<MainGameEnemy> _enemyList = new();
    private Boss _boss;

    void Start()
    {
        NRInput.AddClickListener(ControllerHandEnum.Right, ControllerButton.TRIGGER, () =>
        {
            if (_enemyList.Count > 0)
            {
                onKillEnemy(_enemyList.Count);
                _enemyList.ForEach(enemy => enemy.Kill());
                _enemyList.Clear();
            }
            else
            {
                if (_boss)
                    StartCoroutine(_boss?.OnAttacked());
            }
        });
    }

    private void OnDestroy()
    {
        onKillEnemy = null;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<MainGameEnemy>(out var enemy))
        {
            enemy.SetTargetted(true);
            _enemyList.Add(enemy);
        }

        if (other.TryGetComponent<Boss>(out var boss))
        {
            _boss = boss;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent<MainGameEnemy>(out var enemy))
        {
            enemy.SetTargetted(false);
            if (_enemyList.Contains(enemy))
                _enemyList.Remove(enemy);
        }

        if (other.TryGetComponent<Boss>(out var boss))
        {
            _boss = null;
        }
    }
}
