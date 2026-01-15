using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class screenImageChanger : MonoBehaviour
{
    public float speed; 
    private float max;
    private float min; 
    // Use this for initialization
    void Start()
    {

        min = transform.position.x - 0.40f;
        max = transform.position.x + 0.40f;

    }

    // Update is called once per frame
    void Update()
    {


        transform.position = new Vector3(Mathf.PingPong(Time.time * speed, max - min) + min, transform.position.y, transform.position.z);

    }
}
