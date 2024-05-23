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

    [SerializeField] private Transform enemyBase;

    private List<MainGameEnemy> _enemyList = new();

    void Start()
    {
        NRInput.AddClickListener(ControllerHandEnum.Right, ControllerButton.TRIGGER, () =>
        {
            onKillEnemy(_enemyList.Count);
            _enemyList.ForEach(enemy => enemy.Kill());
            _enemyList.Clear();
        });
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<MainGameEnemy>(out var enemy))
        {
            enemy.SetTargetted(true);
            _enemyList.Add(enemy);
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
    }
}
