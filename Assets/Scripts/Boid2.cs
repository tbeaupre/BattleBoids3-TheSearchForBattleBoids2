using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boid2 : MonoBehaviour {
    public GameObject boid;
    public GameObject target;
    float speed;
    public Vector3 center;
    //Collider m_collider;
    private Rigidbody rbody;
    int count;
    // Use this for initialization
    // Use this for initialization
    void Start () {
        boid = GameObject.Find("BasicBoid");
        speed = 2f;
        count = 0;
        center = new Vector3(0, 0, 0);
        rbody = GetComponent<Rigidbody>();
        //m_collider = GetComponent<Collider>();
        //m_collider.enabled = true;
    }

    // Update is called once per frame
    void Update () {
        count++;
        float step = speed * Time.deltaTime;
        var heading = center - transform.position;
        var distance = heading.magnitude;
        var direction = heading / distance;
        //transform.position = Vector3.MoveTowards(transform.position, boid.transform.position, step);
        //gameObject.transform.position += Vector3.forward;
        //float distance = Vector3.Distance(this.transform.position, boid.transform.position);
        //gameObject.transform.position += Vector3.MoveTowards(transform.position, boid.transform.position, step);
        //rbody.AddForce(20,0,20);
        //rbody.AddForce(direction * 10);

        if (distance > 0)
        {
            direction = heading / distance;
            rbody.AddForce(direction * 10);
        }

        if (count > 120)
        {
            count = 0;
            GameObject[] gos = GameObject.FindGameObjectsWithTag("team1");
            var dist = 10000f;
            for (var i=0;i< gos.Length;i++)
            {
                heading = gos[i].transform.position - transform.position;
                distance = heading.magnitude;
                if (distance < dist)
                {
                    dist = distance;
                    target = gos[i];
                }
            }
            //target = GameObject.Find("BasicBoid");
            heading = target.transform.position - transform.position;
            distance = heading.magnitude;
            direction = heading / distance;
            rbody.AddForce(direction * 15, ForceMode.Impulse);
        }
    }
}