using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : HealthScript
{
    public Image HealthBar;
    public override void TakeDamage(float damage)
    {
        base.TakeDamage(damage);
        Debug.Log("Player took " + damage.ToString() + " DMG");
        HealthBar.fillAmount = Health / MaxHealth;
    }

    public void Heal(float amount)
    {
        Health += amount;
        Health = Mathf.Clamp(Health, 0, MaxHealth);
        Debug.Log("Player healed " + amount.ToString() + " health");
        HealthBar.fillAmount = Health / 100;
    }

    public override void Die()
    {
        Debug.Log("Player Has Died!");
    }
}
