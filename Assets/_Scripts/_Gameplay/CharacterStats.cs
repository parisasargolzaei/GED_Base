using UnityEngine;

public class CharacterStats : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;

    public int damage;
    public int armor;

    public event System.Action<int, int> OnHealthChanged;

    void Awake() 
    {
        currentHealth = maxHealth;
    }

    // public void Attack()
    // {
    //     TakeDamage(10);
    // }

    public virtual void TakeDamage (int damage)
    {
        damage -= armor;
        damage = Mathf.Clamp(damage, 0, int.MaxValue);

        currentHealth -= damage;
        Debug.Log(transform.name + " takes " + damage + " damage.");

        // For health bar
        if (OnHealthChanged != null)
        {
            OnHealthChanged(maxHealth, currentHealth);
        }

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    public virtual void RecoverHealth(int heal)
    {
        if((currentHealth + heal) < maxHealth)
        {
            currentHealth += heal;
        }
        else
        {
            currentHealth = maxHealth;
        }

        if (OnHealthChanged != null)
        {
            OnHealthChanged(maxHealth, currentHealth);
        }
    }

    public virtual void Die ()
    {
        Debug.Log(transform.name + " died.");
    }
}
