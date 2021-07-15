using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateBeam : MonoBehaviour
{
    void Update()
    {
        gameObject.transform.RotateAround(gameObject.transform.position, Vector3.forward, 500 * Time.deltaTime);
    }
}
