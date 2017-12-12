using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SchutzmanBoids : MonoBehaviour
{
	private float separation;
	private float flocking;
	private float cohesion;
	private float direction;
	private float COH_NEIGHBORDIST = 50;  //radius for boids to be cohesive with
	private float ALI_NEIGHBORDIST = 50;  //radius for boids to align with
	private float SEP_DESIREDDIST = 20;   //desired separation distance
	private float angle;
	
	
	
	private float speed;
	private float mass;
	private float strength;
	private float size;
	private float agression;
	private float turnSpeed;
	private float bounciness;
	private int shape;
	private float fear;
	

	// Use this for initialization
	void Start ()
	{
		Transform[] array;

	}

	// Update is called once per frame
	void Update ()
	{
		
		
		
	}


	void ExplosionDamage(Vector3 center, float radius)
	{
		
		Collider[] hitColliders = Physics.OverlapSphere(center, radius);
		int i = 0;
		while (i < hitColliders.Length)
		{
			hitColliders[i].SendMessage("AddDamage");
			i++;
		}
	}
	
	
	
	
	
	public void init(float separation, float flocking, float cohesion, float direction, float angle, float speed, float mass, float strength, float size, float agression, float turnSpeed, float bounciness, int shape, float fear)
	{
		this.separation = separation;
		this.flocking = flocking;
		this.cohesion = cohesion;
		this.direction = direction;
		this.angle = angle;
		this.speed = speed;
		this.mass = mass;
		this.strength = strength;
		this.size = size;
		this.agression = agression;
		this.turnSpeed = turnSpeed;
		this.bounciness = bounciness;
		this.shape = shape;
		this.fear = fear;
	}

	public float CohNeighbordist
	{
		get { return COH_NEIGHBORDIST; }
		set { COH_NEIGHBORDIST = value; }
	}

	public float AliNeighbordist
	{
		get { return ALI_NEIGHBORDIST; }
		set { ALI_NEIGHBORDIST = value; }
	}

	public float SepDesireddist
	{
		get { return SEP_DESIREDDIST; }
		set { SEP_DESIREDDIST = value; }
	}

	public float Separation
	{
		get { return separation; }
		set { separation = value; }
	}

	public float Flocking
	{
		get { return flocking; }
		set { flocking = value; }
	}

	public float Cohesion
	{
		get { return cohesion; }
		set { cohesion = value; }
	}

	public float Direction
	{
		get { return direction; }
		set { direction = value; }
	}

	public float Angle
	{
		get { return angle; }
		set { angle = value; }
	}

	public float Speed
	{
		get { return speed; }
		set { speed = value; }
	}

	public float Mass
	{
		get { return mass; }
		set { mass = value; }
	}

	public float Strength
	{
		get { return strength; }
		set { strength = value; }
	}

	public float Size
	{
		get { return size; }
		set { size = value; }
	}

	public float Agression
	{
		get { return agression; }
		set { agression = value; }
	}

	public float TurnSpeed
	{
		get { return turnSpeed; }
		set { turnSpeed = value; }
	}

	public float Bounciness
	{
		get { return bounciness; }
		set { bounciness = value; }
	}

	public int Shape
	{
		get { return shape; }
		set { shape = value; }
	}

	public float Fear
	{
		get { return fear; }
		set { fear = value; }
	}
	
	
	
	
}
