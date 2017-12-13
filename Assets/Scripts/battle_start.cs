using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class battle_start : MonoBehaviour {
    // Use this for initialization
    private Vector3 pos;
    void Start () {
        var team_one_size = 15;
        var j = 0;
        var l = 0;
        for (var i = 0; i < team_one_size; i++) {
            l++;
            if ((i % 8) == 0 && i != 0) {
                j++;
                l -= 8;
            }
            pos = new Vector3(5, 3+j, (l*1.1f)-(team_one_size / 2));
            var boid_prefab = Resources.Load("BasicBoid") as GameObject;
            var boid = GameObject.Instantiate(boid_prefab, pos, transform.rotation);

            //GameObject myGameObject = new GameObject("Test Object"); // Make a new GO.
            Rigidbody gameObjectsRigidBody = boid.AddComponent<Rigidbody>(); // Add the rigidbody.

            //var boid_script = boid.GetComponent<BasicBoid>();
            //set mass
            //var boid_mass = boid_script.mass;
            gameObjectsRigidBody.mass = 2;
        }

        var team_two_size = 14;
        j = 0;
        l = 0;
        for (var i = 0; i < team_two_size; i++)
        {
            l++;
            if ((i % 8) == 0 && i != 0)
            {
                j++;
                l -= 8;
            }
            pos = new Vector3(-5, 3 + j, (l * 1.1f) - (team_two_size / 2));
            var boid_prefab = Resources.Load("Boid2") as GameObject;
            var boid = GameObject.Instantiate(boid_prefab, pos, transform.rotation);

            //GameObject myGameObject = new GameObject("Test Object"); // Make a new GO.
            Rigidbody gameObjectsRigidBody = boid.AddComponent<Rigidbody>(); // Add the rigidbody.

            //var boid_script = boid.GetComponent<BasicBoid>();
            //set mass
            //var boid_mass = boid_script.mass;
            gameObjectsRigidBody.mass = 2;
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
