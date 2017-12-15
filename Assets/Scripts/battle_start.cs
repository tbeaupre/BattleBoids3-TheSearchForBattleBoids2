using System.Collections;
using System.Collections.Generic;
using Manager;
using UnityEngine;

public class battle_start : MonoBehaviour
{
    public GameObject boidPrefab;
    public GameObject battle;

    private GameObject[] team_one;
    private GameObject[] team_two;
    private int team_one_remaining;
    private int team_two_remaining;
    private int count = 0;
    //public GameObject enemyBoidPrefab;

    // Use this for initialization
    private Vector3 pos;
    void Start () {
        var j = 0;
        var l = 10;
        for (var i = 0; i < BoidManager.NUM_BOIDS; i++) {
            l++;
            if ((i % 8) == 0 && i != 0) {
                j++;
                l -= 8;
            }
            pos = new Vector3(3, 3+j, (l*1.1f)-(BoidManager.NUM_BOIDS / 2));
            var boid = GameObject.Instantiate(boidPrefab, pos, transform.rotation);
            
            //GameObject myGameObject = new GameObject("Test Object"); // Make a new GO.
            var script = boid.GetComponent<BoidParent>();
            script.rbody = boid.AddComponent<Rigidbody>();
            List<BoidAttributes> boids = BoidManager.GetCurrentBoids();
            var boid_stats = boids[i];
            boid.gameObject.tag = "team1";
            script.set_stats(1, boid_stats.Speed, boid_stats.Mass, boid_stats.Size_x, boid_stats.Size_y, boid_stats.Size_z, boid_stats.Bounciness, boid_stats.Fear, boid_stats.Cohesion, boid_stats.Push_strength, boid_stats.Push_delay, boid_stats.Jump_strength, boid_stats.Jump_delay, boid_stats.Color);
            //var boid_script = boid.GetComponent<BasicBoid>();
            //set mass
            //var boid_mass = boid_script.mass;
            //gameObjectsRigidBody.mass = 1f;
        }

        j = 0;
        l = 10;
        for (var i = 0; i < BoidManager.NUM_BOIDS; i++)
        {
            l++;
            if ((i % 8) == 0 && i != 0)
            {
                j++;
                l -= 8;
            }
            pos = new Vector3(3, 3 + j, (l * 1.1f) - (BoidManager.NUM_BOIDS / 2));
            var boid = GameObject.Instantiate(boidPrefab, pos, transform.rotation);

            //GameObject myGameObject = new GameObject("Test Object"); // Make a new GO.
            var script = boid.GetComponent<BoidParent>();
            script.rbody = boid.AddComponent<Rigidbody>();
            List<BoidAttributes> boids = BoidManager.GetCurrentBoids();
            var boid_stats = boids[i];
            boid.gameObject.tag = "team2";
            script.set_stats(0, boid_stats.Speed, boid_stats.Mass, boid_stats.Size_x, boid_stats.Size_y, boid_stats.Size_z, boid_stats.Bounciness, boid_stats.Fear, boid_stats.Cohesion, boid_stats.Push_strength, boid_stats.Push_delay, boid_stats.Jump_strength, boid_stats.Jump_delay, boid_stats.Color);
        }
    }
	
	// Update is called once per frame
	void Update () {
        //transform.Rotate(6*new Vector3(1,0,0) * Time.deltaTime);
        if (count > 600 && count < 1200) {
            transform.localScale -= new Vector3(0.06F, 0, 0.06F);
        }
        count++;

        team_one = GameObject.FindGameObjectsWithTag("team1");
        team_two = GameObject.FindGameObjectsWithTag("team2");
        team_one_remaining = team_one.Length;
        team_two_remaining = team_two.Length;
    }

    public GameObject[] get_team_one () {
        return team_one;
    }

    public GameObject[] get_team_two () {
        return team_two;
    }
}
