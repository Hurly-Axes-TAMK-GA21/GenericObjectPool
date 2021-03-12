using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TowerDefence
{
    // <summary>
    /// Enemy Base class from which the individual enemy units will be created from.
    /// Implements the IDamageable interface which includes health and damage taking.
    /// </summary>
    public abstract class EnemyBase : MonoBehaviour, IDamageable
    {
        // The speed the enemy is moving
        [SerializeField]
        protected private float speed = 1f;

        // The current health of the enemy
        [SerializeField]
        protected private float currentHealth;

        // The maxmimum health of the enemy
        [SerializeField]
        protected private float maxHealth = 100;

        private void Start()
        {   // Reset the current health value to the max health value
            ResetHealth();            
        }

        public int CurrentHealth
        {
            get 
            { 
                return CurrentHealth; 
            }

            private set
            {
                currentHealth = value;
            }

        }

        public int MaxHealth 
        {
            get
            {
                return MaxHealth;
            }

            private set
            {
                maxHealth = value;
            }
        }

        public bool IsImmortal {
            get;
            set;
        }

        public void DecreaseHealth(int amount)
        {
            currentHealth -= amount;

            if (currentHealth <= 0)
            {
                DestroyEnemy();
            }
        }

        public void IncreaseHealth(int amount)
        {
            if (currentHealth + amount > maxHealth)
            {
                currentHealth = maxHealth;
            } else
            {
                currentHealth += amount;
            }
        }

        public void ResetHealth()
        {
            currentHealth = maxHealth;
        }

        public virtual void TakeDamage(int amount)
        {
            DecreaseHealth(amount);
        }

        public virtual void DestroyEnemy()
        {
            Destroy(gameObject);
        }
    }

}

    

