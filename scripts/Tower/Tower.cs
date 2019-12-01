using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Tower script
//Can be assigned to different gameobjects
//Uses magnitude of direction vector to decide which enemy to fire at.
//Relies on gameobjects using 'Minion' script

public class Tower : MonoBehaviour {

    public GameObject bullet;
    public float BulletSpeed, FireRate, radius;

    private GameObject minion;
    private Vector2 direction;

    private bool isShooting;
    private float shooting_cooldown, currentMagnitudeFromTarget = 10;
    private uint currentProgress = 0;

    private void Awake()
    {
        //Assign default value's
        BulletSpeed = BulletSpeed == 0 ? 6.0f : BulletSpeed;
        FireRate = FireRate == 0 ? 0.5f : FireRate;
        radius = radius == 0 ? 4.5f : radius;
    }

    private void Start()
    {
        GetComponent<CircleCollider2D>().radius = radius;
    }
    
    void FixedUpdate () {

        bool ready_to_shoot = GetComponent<Tower_placement>().isReady;

        if (ready_to_shoot && isShooting && minion != null)
        {
                shooting_cooldown += Time.deltaTime;
                
                direction = (minion.transform.position - transform.position);
                transform.right = direction.normalized;

                if (shooting_cooldown > FireRate)
                {
                    var bul = (GameObject)Instantiate(bullet, transform.position, Quaternion.identity);
                    bul.GetComponent<Rigidbody2D>().velocity = direction * BulletSpeed;
                    shooting_cooldown = 0.0f;
                }
        }
        else if(minion == null)
        {
            currentMagnitudeFromTarget = 10.0f;  //(current magnitude from target)
            currentProgress = 0; //(current progress)
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("minion") && collision.GetComponent<Minion>().magnitudeFromTarget < currentMagnitudeFromTarget && collision.GetComponent<Minion>().progress >= currentProgress)
        {
            minion = collision.gameObject;
            isShooting = true;
            currentMagnitudeFromTarget = collision.GetComponent<Minion>().magnitudeFromTarget;
        }

    }
    
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject == minion)
        {
            isShooting = false;
            currentMagnitudeFromTarget = 10f;
            currentProgress = 0;
        }
    }
}