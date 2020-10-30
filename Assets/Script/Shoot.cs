using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public GameObject Bullet;
    public float SmoothTime = 0.3f;
    float TimeFire = 0.4f;
    public GameObject ParticleEfect;
    public float ParticleTime = 4;
    public Vector3 destination;
    public GameObject Obstacle;
    private float desiredRot;
    public Camera camera;
    public Rigidbody rb;
    public GameObject Spawnobject;
    bool CheckSpawn = false;
    public AudioSource ShootSound;
    void Update()
    {
        PlayerShoot();
        Particle();
        Destroy(GameObject.Find("Bullet(Clone)"), 0.3f);


    }
    void PlayerShoot()
    {
        if (Input.GetKey(KeyCode.Mouse0))
        {
            TimeFire -= Time.deltaTime;
            if (TimeFire <= 0)
            {
                   ShootSound.Play();
                   GameObject instantiatedProjectile = Instantiate(Bullet, transform.position, transform.rotation);
                instantiatedProjectile.GetComponent<Rigidbody>().velocity =
                transform.TransformDirection(new Vector3(transform.forward.x, transform.forward.z, +5));
                TimeFire = 0.4f;
            }
        }
    }

    void Particle()
    {
        if (GameObject.Find("Target(Clone)") == null)
        {
            ParticleTime -= Time.deltaTime;
            ParticleEfect.SetActive(true);
            Obstacle.SetActive(false);

            if (ParticleTime <= 0)
            {
                ParticleEfect.SetActive(false);
                transform.position = Vector3.Lerp(transform.position, new Vector3(0.0002f, 1.008f, 1.27f), Time.deltaTime * 0.7f);
            }
            if (transform.position.z >= 1.25)
            {

                var desiredRotQ = Quaternion.Euler(transform.eulerAngles.x, -31.1f, desiredRot);
                transform.rotation = Quaternion.Lerp(transform.rotation, desiredRotQ, Time.deltaTime * 10);
                transform.position = Vector3.Lerp(transform.position, new Vector3(-0.641f, 1.008f, 2.094f), Time.deltaTime * 1f);
                camera.GetComponent<CameraFollow>().Offset.x = 0.35f;
                Bullet.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezePositionZ;
                Bullet.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezeRotationZ;
                if (transform.position.z >= 1.69f && CheckSpawn == false)
                {
                    for (int i = 0; i <= 22; i++)
                    {
                        for (int y = 0; y < 1; y++)
                        {
                            Instantiate(Spawnobject, new Vector3(-1.151f, 1.024f, 2.757f), Quaternion.identity);
                        }
                    }
                    CheckSpawn = true;

                }
            }

        }
    }


}

