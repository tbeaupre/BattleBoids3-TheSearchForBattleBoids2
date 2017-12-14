using UnityEngine;

public class BasicBoid : BoidParent {
	public float agility = 0f;
	public float agression = 0;
	public float fear = 0;
	public float bounce = 0;

	public float push_strength;
	// Use this for initialization
	void Start ()
	{
		
		

        rbody = GetComponent<Rigidbody>();
        boid = GameObject.Find("BasicBoid");
        enemy = "team2";
		

		
		
		speed = 2000f;
        mass = 2;
        size_x = 1;
        size_y = 1;
        size_z = 1;
        push_strength = 20;
        push_delay = 40;
        jump_strength = 60;
        jump_delay = 100;
    }
	
	// Update is called once per frame
	void Update () {
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
	

	public void init(float speed, float agility, float mass, float strength, float agression, float fear, float bounce)
	{
		this.speed = speed;
		this.mass = mass;
		this.push_strength = strength;
		this.agression = agression;
		this.fear = fear;
		this.agility = agility;
		this.bounce = bounce;


	}
}