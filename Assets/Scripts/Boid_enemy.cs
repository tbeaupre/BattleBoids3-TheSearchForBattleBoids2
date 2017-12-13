using UnityEngine;

public class Boid_enemy : BoidParent
{

    // Use this for initialization
    void Start()
    {
        rbody = GetComponent<Rigidbody>();
        boid = GameObject.Find("BasicBoid");
        enemy = "team1";

        speed = 2000f;
        mass = 2;
        size_x = 1f;
        size_y = 1f;
        size_z = 1.2f;
        push_strength = 20;
        push_delay = 40;
        jump_strength = 0;
        jump_delay = 10000;

        transform.localScale = new Vector3(size_x,size_y,size_z);
    }

    // Update is called once per frame
    void Update()
    {
        float step = speed * Time.deltaTime;
        var heading = center - transform.position;
        var distance = heading.magnitude;
        var direction = heading / distance;

        if (distance > 2) {
            direction = heading / distance;
            rbody.AddForce(direction * step);
        } 

        if (count > push_delay && distance < 10) {
            count = 0;
            push();
        }
        count++;

        if (count2 > jump_delay) {
            count2 = 0;
            jump();
        }
        count2++;

    }
}