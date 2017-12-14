using System.Collections;
using System.Collections.Generic;
using Manager;
using UnityEngine;

public class battle_start : MonoBehaviour
{
    public GameObject boidPrefab;
    public GameObject enemyBoidPrefab;
    
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
            Rigidbody gameObjectsRigidBody = boid.AddComponent<Rigidbody>(); // Add the rigidbody.

            //var boid_script = boid.GetComponent<BasicBoid>();
            //set mass
            //var boid_mass = boid_script.mass;
            gameObjectsRigidBody.mass = 1f;
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
            pos = new Vector3(-3, 3 + j, (l * 1.1f) - (BoidManager.NUM_BOIDS / 2));
            var boid = GameObject.Instantiate(enemyBoidPrefab, pos, transform.rotation);

            //GameObject myGameObject = new GameObject("Test Object"); // Make a new GO.
            Rigidbody gameObjectsRigidBody = boid.AddComponent<Rigidbody>(); // Add the rigidbody.

            //var boid_script = boid.GetComponent<BasicBoid>();
            //set mass
            //var boid_mass = boid_script.mass;
            gameObjectsRigidBody.mass = 1f;
        }
    }
	
	// Update is called once per frame
	void Update () {
       //transform.Rotate(6*new Vector3(1,0,0) * Time.deltaTime);

    }
}
