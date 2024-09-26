using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidScript : MonoBehaviour
{
    [SerializeField] GameObject Explode;
    [SerializeField] GameObject Damage;
    [SerializeField] int HP = 1;
    [SerializeField] int ScoreVal = 10;

    private void Start()
    {
        InvokeRepeating("CheckHeight", 15, 5);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Projectile")
        {
            if (HP <= 1)
            {
                GameObject Part = Instantiate(Explode);
                Part.transform.position = transform.position;
                ScoreManager.Instance.AddScore(ScoreVal);
                Destroy(gameObject);
            }else
            {
                HP--;
                GameObject Part = Instantiate(Damage);
                Part.transform.position = transform.position;
            }
        }
    }

    void CheckHeight()
    {
        if(transform.position.y <= -25)
        {
            ScoreManager.Instance.AddScore((ScoreVal * -4));
            Destroy(gameObject);
        }
    }
}
