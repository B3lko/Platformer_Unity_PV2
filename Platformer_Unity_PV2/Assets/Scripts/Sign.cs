using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sign : MonoBehaviour
{
    private float degree = 0;
    void FixedUpdate() {
        transform.position = new Vector3(transform.position.x, transform.position.y + Mathf.Sin(degree) * 0.0025f, transform.position.z);
        degree += 0.08f;
    }
}
