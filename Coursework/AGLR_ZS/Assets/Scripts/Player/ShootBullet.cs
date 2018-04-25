using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShootBullet : MonoBehaviour
{

    public GameObject bulletPrefab;
    public Transform bulletSpawn;

    public float fireTime = 0.5f;
    public float reloadTime = 2.0f;

    private bool isFiring = false;
    private bool isReloading = false;

    public int max = 56;
    public int load = 8;

    public delegate void UpdateAmmo(int load, int max);

    public static event UpdateAmmo OnUpdateAmmo;

    private void Start()
    {

        SendAmmoData();

    }

    void Fire()
    {

        isFiring = true;

        Instantiate(bulletPrefab, bulletSpawn.position, bulletSpawn.rotation);

        load -= 1;

        SendAmmoData();

        if (load == 0 && max != 0)
        {
            Invoke("Reload", reloadTime);
        }

        Invoke("SetFiring", fireTime);

    }

    void Reload()
    {

        int loadDifference = 8 - load;

        if (max - loadDifference < 0)
        {

            loadDifference = max;
            
        }

        load += loadDifference;

        max -= loadDifference;

        SendAmmoData();

        isReloading = false;

    }

    void SetFiring()
    {

        isFiring = false;

    }

    void Update()
    {

        if (Input.GetMouseButton(0))
        {

            if ((!isFiring) && (!isReloading) && (load != 0))
            {
                Fire();
            }
        }

        if (Input.GetKeyDown(KeyCode.R) && (load != 8) && (max != 0))
        {

            isReloading = true;

            Invoke("Reload", reloadTime);

        }
    }

    void SendAmmoData()
    {
        if (OnUpdateAmmo != null)
        {

            OnUpdateAmmo(load, max);

        }
    }
}
