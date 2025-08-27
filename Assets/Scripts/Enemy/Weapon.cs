using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] private Collider myCollider;

    private int damage;
    private float knockback;

    private List<Collider> alreadyCollider = new List<Collider>();

    private void OnEnable()
    {
        alreadyCollider.Clear();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other == myCollider) return;

        if (alreadyCollider.Contains(other)) return;
        
        alreadyCollider.Add(other);

        if (other.TryGetComponent(out Health health))
        {
            health.TakeDamage(damage);
        }

        if (other.TryGetComponent(out ForceReceiver force))
        {
            Vector3 dir = (other.transform.position - myCollider.transform.position);
            
            force.AddForce(dir * knockback);
        }
    }

    public void SetAttack(int damage, float knockback)
    {
        this.damage = damage;
        this.knockback = knockback;
    }
}
