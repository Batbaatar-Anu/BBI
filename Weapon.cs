using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
 {  
    [Header("References")]
        public Transform cam;
        public Transform attackPoint;
        public GameObject bullet;

    [Header("Settings")]
    public int ammo;
    public float rpm;

    [Header("Shoot")]
    public KeyCode shootKey = KeyCode.Mouse0;
    public float bulletForce;
    public float bulletUpWardForce;

    bool readtoshoot;
  
    public Animator gunanimator;
    public Animator handanimator;




    bool readyToShoot;
    // Start is called before the first frame update
    void Start()
    {
        readyToShoot = true;



}

// Update is called once per frame
void Update()
    {   if(Input.GetKeyDown(shootKey) && readyToShoot && ammo > 0)
        {
            Buudah();
        }
    if(Input.GetKeyDown(KeyCode.R) || ammo <= 0)
        {
            Reload();
        }
        
    }
    void Reload()
    {
        if(ammo > 0 &&ammo < 30)
        {
            gunanimator.Play("Reload", 0, 0.0f);
            handanimator.Play("Reload", 3, 0.0f);

            Debug.Log("Reload with ammo");
        }else if(ammo <= 0)
        {
            gunanimator.Play("Reload Empty", 0, 0.0f);
            handanimator.Play("Reload Empty", 3, 0.0f);

            Debug.Log("Reload withouth ammo");
        }
        ammo = 30;
    }
    void Buudah()
    {
        readyToShoot = false;
        GameObject projectile = Instantiate(bullet, attackPoint.position, cam.rotation);
        Rigidbody bulletRb = projectile.GetComponent<Rigidbody>();
        Vector3 forceToAdd = cam.transform.forward * bulletForce + transform.up * bulletUpWardForce;

        bulletRb.AddForce(forceToAdd, ForceMode.Impulse);
        ammo--;
        Invoke(nameof(ResetShoot), rpm);

    }
    private void ResetShoot()
    {
        readyToShoot = true;
    }
}
