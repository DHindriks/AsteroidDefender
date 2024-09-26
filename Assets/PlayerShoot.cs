using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    [SerializeField] float Cooldown;
    [SerializeField] GameObject Projectile;
    [SerializeField] int ProjectileSpeed;
    float Timestamp;

    void Update()
    {
        if (Input.GetKey(KeyCode.Space) && Time.time > Timestamp)
        {
            GameObject NewProjectile = Instantiate(Projectile);
            NewProjectile.transform.position = transform.GetChild(0).position;
            NewProjectile.GetComponent<Rigidbody>().AddForce(Vector3.up * ProjectileSpeed, ForceMode.VelocityChange);
            Destroy(NewProjectile, 5);

            Timestamp = Time.time + Cooldown;
        }
    }
}
