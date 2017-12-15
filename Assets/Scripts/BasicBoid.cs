using UnityEngine;

public class BasicBoid : BoidParent {
		
	// Use this for initialization
	void Start () {
        rbody = GetComponent<Rigidbody>();
        boid = GameObject.Find("BasicBoid");
        enemy = "team2";
        friend = "team1";
        count3 = 200;

		speed = 1600f;
        size_x = 1;
        size_y = 1;
        size_z = 1;
        push_strength = 20;
        push_delay = 90;
        jump_strength = 18;
        jump_delay = 100;
        bounciness = 100;
        cohesion = 0;

    }
	
	// Update is called once per frame
	void Update () {
        float step = speed * Time.deltaTime;
		var heading = center - transform.position;
		var distance = heading.magnitude;
		var direction = heading / distance;

        if (transform.position.y < -40) {
            Destroy(gameObject);
        }

        //if (distance > 5) {
            direction = heading / distance;
            rbody.AddForce(direction * step);
        //} else {
            if (count3 > 60) {
                count3 = 0;
                find_friend();
            }
            count3++;
            move_towards_friend();
        //}

        if (count > push_delay && distance < 20) {
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