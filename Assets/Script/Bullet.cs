using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Bullet : MonoBehaviour
{
    public GameObject btnReplay;
    public Shoot shot;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Target")
        {
            Destroy(other.gameObject);
            Destroy(this.gameObject);
        }

        if (other.tag == "Obstacle")
        {
            Handheld.Vibrate();
            btnReplay.SetActive(true);
            shot.enabled = false;
        }
    }

    public void Replay()
    {
        SceneManager.LoadScene("FireBall");
        btnReplay.SetActive(false);
    }
}
