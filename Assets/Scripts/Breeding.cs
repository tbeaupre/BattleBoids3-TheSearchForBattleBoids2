using System;
using System.CodeDom.Compiler;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using Random = System.Random;

public class Breeding
{
	private int numOfBoids = 20;


	
	BasicBoid[] breedPlayerBoids(BasicBoid[] stock)
	{
		BasicBoid[] boids = new BasicBoid[numOfBoids];
		Random r = new Random();

		for (int i = 0; i < stock.Length; i++)
		{
			boids[i] = stock[i];

		}
		int numToGenerate = numOfBoids - stock.Length;

		for (int i = stock.Length; i < numToGenerate; i++)
		{

			int leftParent = r.Next(0, stock.Length);
			int rightParent = r.Next(0, stock.Length);

			while (leftParent == rightParent)
			{
				rightParent = r.Next(0, stock.Length);
			}
			boids[i] = breedBoid(boids[leftParent], boids[rightParent]);
		}

		return boids;
	}

	BasicBoid breedBoid(BasicBoid left, BasicBoid right)
	{
		float speed = generateSpeed(left, right);
		float strength = generateStrength(left, right);
		float agility = generateAgility(left, right);
		float agression = generateAgression(left, right);
		float mass = generateMass(left, right);
		float fear = generateFear(left, right);
		float bounce = generateBounce(left, right);
	
		BasicBoid newBoid = new BasicBoid();
		newBoid.init(speed, agility, mass, strength, agression, fear, bounce);	
		
		return newBoid;
		
	}

	float generateSpeed(BasicBoid left, BasicBoid right)
	{
		float speed = 0;
		Random r = new Random();
		int pctParent = r.Next(0, 100);

		if (pctParent < 10)
		{
			double num = Math.Pow(r.NextDouble(), r.NextDouble());
		    speed = (float) num % 5000;
		}else if (pctParent < 90)
		{
			float num = (left.speed + right.speed) / 2;

		}
		else if (pctParent < 95)
		{
			speed = left.speed;
		}
		else
		{
			speed = right.speed;
		}
		return speed;
	}
	float generateStrength(BasicBoid left, BasicBoid right)
	{
		float str = 0;
		Random r = new Random();
		int pctParent = r.Next(0, 100);

		if (pctParent < 10)
		{
			double num = Math.Pow(r.NextDouble(), r.NextDouble());
			str = (float) num % 20;
		}else if (pctParent < 90)
		{
			 str = (left.push_strength + right.push_strength) / 2;

		}
		else if (pctParent < 95)
		{
			str = left.push_strength;
		}
		else
		{
			str = right.push_strength;
		}
		return str;
	}
	float generateAgility(BasicBoid left, BasicBoid right)
	{
		float str = 0;
		Random r = new Random();
		int pctParent = r.Next(0, 100);

		if (pctParent < 10)
		{
			double num = Math.Pow(r.NextDouble(), r.NextDouble());
			str = (float) num % 20;
		}else if (pctParent < 90)
		{
			str = (left.agility + right.agility) / 2;

		}
		else if (pctParent < 95)
		{
			str = left.agility;
		}
		else
		{
			str = right.agility;
		}
		return str;
	}
	float generateAgression(BasicBoid left, BasicBoid right)
	{
		float str = 0;
		Random r = new Random();
		int pctParent = r.Next(0, 100);

		if (pctParent < 10)
		{
			double num = Math.Pow(r.NextDouble(), r.NextDouble());
			str = (float) num % 20;
		}else if (pctParent < 90)
		{
			str = (left.agression + right.agression) / 2;

		}
		else if (pctParent < 95)
		{
			str = left.agression;
		}
		else
		{
			str = right.agression;
		}
		return str;
	}
	float generateMass(BasicBoid left, BasicBoid right)
	{
		float str = 0;
		Random r = new Random();
		int pctParent = r.Next(0, 100);

		if (pctParent < 10)
		{
			double num = Math.Pow(r.NextDouble(), r.NextDouble());
			str = (float) num % 20;
		}else if (pctParent < 90)
		{
			str = (left.mass + right.mass) / 2;

		}
		else if (pctParent < 95)
		{
			str = left.mass;
		}
		else
		{
			str = right.mass;
		}
		return str;
	}
	float generateBounce(BasicBoid left, BasicBoid right)
	{
		float str = 0;
		Random r = new Random();
		int pctParent = r.Next(0, 100);

		if (pctParent < 10)
		{
			double num = Math.Pow(r.NextDouble(), r.NextDouble());
			str = (float) num % 20;
		}else if (pctParent < 90)
		{
			str = (left.bounce + right.bounce) / 2;

		}
		else if (pctParent < 95)
		{
			str = left.bounce;
		}
		else
		{
			str = right.bounce;
		}
		return str;
	}
	float generateFear(BasicBoid left, BasicBoid right)
	{
		float str = 0;
		Random r = new Random();
		int pctParent = r.Next(0, 100);

		if (pctParent < 10)
		{
			double num = Math.Pow(r.NextDouble(), r.NextDouble());
			str = (float) num % 20;
		}else if (pctParent < 90)
		{
			str = (left.fear + right.fear) / 2;

		}
		else if (pctParent < 95)
		{
			str = left.fear;
		}
		else
		{
			str = right.fear;
		}
		return str;
	}
	
}