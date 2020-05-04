using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DummyAI : MonoBehaviour
{
    public float lerpTime;
    public Vector3 destination;
    private void Start()
    {
        Destroy(gameObject, 3);
    }
    void Update()
    {
        transform.position = Vector3.Lerp(transform.position, destination, lerpTime);

    }
}
