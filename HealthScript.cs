using UnityEngine;

public class HealthScript : MonoBehaviour
{
    public float Health;
    public float MaxHealth;

    void Start()
    {
        Debug.Log(gameObject.name + " started with " + Health.ToString() + " Health");
    }

    public virtual void TakeDamage(float damage)
    {
        Health -= damage;
        if (Health <= 0) Die();
    }

    public virtual void Die()
    {
        //Death Command
    }
}
