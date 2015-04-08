﻿using UnityEngine;

public class CharacterHealth : MonoBehaviour
{
    public int TotalHealth;
    public int CurrentHealth;
    public int HurtHealth;

    public float NormalizedHealth { get { return 1f * CurrentHealth / TotalHealth; } }

    private Animator animator;

    public void Hurt()
    {
        CurrentHealth -= HurtHealth;
        animator.SetTrigger("Hurt");

        SendMessage("UpdateHealth", NormalizedHealth, SendMessageOptions.DontRequireReceiver);

        if (CurrentHealth <= 0)
        {
            animator.SetTrigger("Die");
            SendMessage("Dead", gameObject, SendMessageOptions.DontRequireReceiver);
        }
    }

    void Awake()
    {
        animator = GetComponent<Animator>();
        CurrentHealth = TotalHealth;
    }
}