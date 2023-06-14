using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOutOfBounds : MonoBehaviour
{
    public static float bottomBound = -2;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Objects get destroyed if they go beyond the boundaries
        if (transform.position.z < bottomBound) {
            Destroy(gameObject);
        }
    }
}