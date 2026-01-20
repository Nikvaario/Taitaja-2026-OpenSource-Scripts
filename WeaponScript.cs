using System.Collections;
using UnityEngine;

public class WeaponScript : MonoBehaviour 
{
    [SerializeField] float damage;
    [SerializeField] float range;
    [SerializeField] float cooldown;
    [SerializeField] int currentAmmo;
    [SerializeField] int reloadTimer;
    [SerializeField] int maxAmmo;
    [SerializeField] Camera fpsCamera;
    [SerializeField] string targetTag;
    private bool canShoot = true;

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && canShoot)
        {
            Shoot();
        }    
        if (Input.GetKeyDown(KeyCode.R))
        {
            ReloadAmmo();
        }
    }

    void Shoot()
    {
        RaycastHit hit;

        if (Physics.Raycast(fpsCamera.transform.position, fpsCamera.transform.forward, out hit, range))
        {
            if (hit.transform.CompareTag(targetTag))
            {
                hit.transform.GetComponent<HealthScript>().TakeDamage(damage);
            }
        }
        
        currentAmmo--;
        if (currentAmmo <= 0)
        {
            ReloadAmmo();
        }
    }

    IEnumerator ReloadAmmo()
    {
        canShoot = false;
        yield return new WaitForSeconds(reloadTimer);
        currentAmmo = maxAmmo;
        canShoot = true;
    }
}