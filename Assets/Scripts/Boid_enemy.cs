using UnityEngine;

public class Boid_enemy : BoidParent
{

    // Use this for initialization
    void Start()
    {
        rbody = GetComponent<Rigidbody>();
        boid = GameObject.Find("BasicBoid");
        enemy = "team1";
        friend = "team2";

        speed = 1600f;
        mass = 2;
        size_x = 0.7f+Random.Range(1,2);
        size_y = 0.7f;
        size_z = 0.7f;
        push_strength = 35;
        push_delay = 80;
        jump_strength = 0;
        jump_delay = 51000;
        bounciness = 100;
        cohesion = 50;

        transform.localScale = new Vector3(size_x,size_y,size_z);
    }

    // Update is called once per frame
    void Update()
    {
        float step = speed * Time.deltaTime;
        var heading = center - transform.position;
        var distance = heading.magnitude;
        var direction = heading / distance;

        if (transform.position.y < -40) {
            Destroy(gameObject);
        }

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


        if (count3 > 60)
        {
            count3 = 0;
            find_friend();
        }
        count3++;
        move_towards_friend();

    }
}