using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 0.1f;
    private Rigidbody bulletRigidbody;
    [SerializeField] private float damageP;

    void Start()
    {
        bulletRigidbody = GetComponent<Rigidbody>();
        bulletRigidbody.velocity = transform.forward * speed;

        Destroy(gameObject,3f);
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Character")
        {
            MainCharController characterController = other.GetComponent<MainCharController>();
            characterController.GetDamage(damageP);
        }
    }
}
