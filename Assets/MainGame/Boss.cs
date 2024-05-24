using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Boss : MonoBehaviour
{
    public event Action onKilled;
    public bool IsWakeUp = false;
    public float speed = 1f;

    [SerializeField] private ParticleSystem[] _effects;
    [SerializeField] private Transform _destination;
    [SerializeField] private Collider _collider;

    private int attackedCount = 0;
    private void Update()
    {
        if (transform.position == _destination.position)
            return;

        if (IsWakeUp)
        {
            _collider.enabled = true;
            transform.position = Vector3.MoveTowards(transform.position, _destination.position, speed);
        }
    }

    public IEnumerator OnAttacked()
    {
        Array.ForEach(_effects, effect =>
        {
            effect.gameObject.SetActive(true);
            effect.Play();
        });

        float maxDuration = _effects.Max(effect => effect.main.duration);

        yield return new WaitForSeconds(maxDuration);

        Array.ForEach(_effects, effect => effect.gameObject.SetActive(false));

        if (++attackedCount >= 5)
            Destroy(gameObject);
    }
}
