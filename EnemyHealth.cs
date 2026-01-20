using UnityEngine;

public class EnemyHealth : HealthScript
{
    public override void TakeDamage(float damage)
    {
        base.TakeDamage(damage);
        Debug.Log("Enemy " + gameObject.name + "took " + damage.ToString() + " DMG");
    }

    public override void Die()
    {
        Destroy(gameObject);
    }
}
