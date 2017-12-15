using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoidParent : MonoBehaviour
{
    private GameObject target;
    private GameObject target_friend;
    public GameObject boid;
    public GameObject controller;
    protected string enemy;
    protected string friend;
    protected Vector3 center = new Vector3(0, 0, 0);
    protected int count = 0;
    protected int count2 = 0;
    protected int count3 = 0;

    public Rigidbody rbody;

    //stats
    protected float speed;
    protected float size_x;
    protected float size_y;
    protected float size_z;
    protected float bounciness;
    protected float fear;
    protected float cohesion;
    protected float push_strength;
    protected float push_delay;
    protected float jump_strength;
    protected float jump_delay;

    private int team;

    // Use this for initialization
    void Start()
    {
        //speed = 100f;
    }

    // Update is called once per frame
    void Update() {
        float step = speed * Time.deltaTime;
        var heading = center - transform.position;
        var distance = heading.magnitude;
        var direction = heading / distance;

        if (transform.position.y < -40 || transform.position.y > 30) {
            Destroy(gameObject);
        }

        if (distance > (20-fear)/2) {
            direction = heading / distance;
            rbody.AddForce(direction * step);
        }

        if (count > push_delay) {
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

    public void push() {
        var dist = 10000f;
        float distance;
        Vector3 heading;
        Vector3 direction;
        GameObject[] boid_array;
        if (team == 1) {
            boid_array = GameObject.FindGameObjectsWithTag("team2");
        }
        else {
            boid_array = GameObject.FindGameObjectsWithTag("team1");
        }
        for (var i = 0; i < boid_array.Length; i++)
        {
            heading = boid_array[i].transform.position - transform.position;
            distance = heading.magnitude;
            if (distance < dist)
            {
                dist = distance;
                target = boid_array[i];
            }
        }
        //if (target != null) {
            heading = target.transform.position - transform.position;
            distance = heading.magnitude;
            direction = heading / distance;
            rbody.AddForce(direction * push_strength, ForceMode.Impulse);
        //}
    }

    public void jump() {
        rbody.AddForce(new Vector3(0, 1, 0) * jump_strength, ForceMode.Impulse);
    }

    public void find_friend() {
        var dist = 10000f;
        GameObject[] boid_array;
        if (team == 1) {
            boid_array = GameObject.FindGameObjectsWithTag("team1");
        } else {
            boid_array = GameObject.FindGameObjectsWithTag("team2");
        }
        for (var i = 0; i < boid_array.Length; i++) {
            if (boid_array[i]) {
                float dist2 = Vector3.Distance(boid_array[i].transform.position, transform.position);
                if (dist2 < dist && dist2 > 5) {
                    dist = dist2;
                    target_friend = boid_array[i];
                }
            }
        }
    }

    public void move_towards_friend () {
        if (target_friend) {
            Vector3 heading = target_friend.transform.position - transform.position;
            float distance = heading.magnitude;
            Vector3 direction = heading / distance;
            rbody.AddForce(direction * cohesion);
        }
    }

    void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.tag == enemy) {
            collision.rigidbody.AddForce(bounciness*(collision.transform.position - transform.position));
        }
    }

    public void set_stats (int player, float Speed, float Mass, float Size_x, float Size_y, float Size_z, float Bounciness, float Fear, float Cohesion, float Push_strength, float Push_delay, float Jump_strength, float Jump_delay, float Color) {
        Mass = 1 + (Mass / 4);
        speed = Speed*1000/Mass;
        size_x = 0.5F+Size_x/12;
        size_y = 0.5F+Size_y/12;
        size_z = 0.5F+Size_x/12;
        bounciness = Bounciness*6/Mass;
        fear = Fear;
        cohesion = Cohesion;

        push_strength = Push_strength*7/Mass;
        push_delay = Push_delay*4;
        jump_strength = Jump_strength*9/Mass;
        jump_delay = Jump_delay*4;

        team = player;

        Renderer rend = GetComponent<Renderer>();
        Color color;
        if (team == 1) {
            color = new Color(0.5F+Color/40, 1F, 0F);
        } else {  
            color = new Color(1F, 0F, 0.5F+Color/40);
        }
        rend.material.SetColor("_Color", color);

        transform.localScale = new Vector3(size_x, size_y, size_z);
        rbody.mass = Mass;
    }
    
}