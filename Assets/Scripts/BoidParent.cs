using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoidParent : MonoBehaviour
{
    public GameObject target;
    public GameObject boid;
    public string enemy;
    public Vector3 center = new Vector3(0, 0, 0);
    public int count = 0;
    public int count2 = 0;

    public Rigidbody rbody;

    //stats
    public float speed;
    public float mass;
    public float size_x;
    public float size_y;
    public float size_z;
    public float push_strength;
    public float push_delay;
    public float jump_strength;
    public float jump_delay;

    // Use this for initialization
    void Start()
    {

        //speed = 100f;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void push()
    {
        GameObject[] gos = GameObject.FindGameObjectsWithTag(enemy);
        var dist = 10000f;
        Vector3 heading;
        Vector3 direction;
        float distance;
        for (var i = 0; i < gos.Length; i++)
        {
            heading = gos[i].transform.position - transform.position;
            distance = heading.magnitude;
            if (distance < dist)
            {
                dist = distance;
                target = gos[i];
            }
        }
        heading = target.transform.position - transform.position;
        distance = heading.magnitude;
        direction = heading / distance;
        rbody.AddForce(direction * push_strength, ForceMode.Impulse);
    }

    public void jump() {
        rbody.AddForce(new Vector3(0, 1, 0) * jump_strength, ForceMode.Impulse);
    }

}