using System;
using System.CodeDom.Compiler;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Manager;
using UnityEditor;
using UnityEngine;
using Random = System.Random;

public static class Breeding
{
	public static List<BoidAttributes> BreedPlayerBoids(List<BoidAttributes> stock, int numToGenerate)
	{
		List<BoidAttributes> boids = new List<BoidAttributes>();
		Random r = new Random();

		for (int i = stock.Count; i < numToGenerate; i++)
		{
			int leftParent = r.Next(0, stock.Count);
			int rightParent = r.Next(0, stock.Count);

			while (leftParent == rightParent)
			{
				rightParent = r.Next(0, stock.Count);
			}
			boids.Add(BreedBoid(stock[leftParent], stock[rightParent]));
		}

		return boids;
	}

	private static BoidAttributes BreedBoid(BoidAttributes left, BoidAttributes right)
	{
		float size = GenerateAttribute(left.Size, right.Size);
		float speed = GenerateAttribute(left.Speed, right.Speed);
		float strength = GenerateAttribute(left.Strength, right.Strength);
		float agility = GenerateAttribute(left.TurnSpeed, right.TurnSpeed);
		float agression = GenerateAttribute(left.Agression, right.Agression);
		float mass = GenerateAttribute(left.Mass, right.Mass);
		float fear = GenerateAttribute(left.Fear, right.Fear);
		float bounce = GenerateAttribute(left.Bounciness, right.Bounciness);
		
		return new BoidAttributes(1, size, mass, speed, strength, agression, agility, bounce, fear);
	}

	private static float GenerateAttribute(float left, float right)
	{
		float value = 0;
		Random r = new Random();
		int pctParent = r.Next(0, 100);

		if (pctParent < 10) // Random
		{
			value = r.Next(BoidAttributes.MAX_VALUE);
		} 
		else if (pctParent < 90) // Average
		{
			value = (left + right) / 2;

		}
		else if (pctParent < 95) // One parent or the other
		{
			value = left;
		}
		else
		{
			value = right;
		}
		return value;
	}
}