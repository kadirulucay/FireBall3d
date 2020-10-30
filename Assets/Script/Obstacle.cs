using System;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    int zAngle = 2;

    private void Update()
    {
        base.transform.Rotate(0f, -this.zAngle * Time.deltaTime * 60f, 0f);
    }

}
