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

		for (int i = 0; i < numToGenerate; i++)
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
        float speed = GenerateAttribute(left.Speed, right.Speed);
        float mass = GenerateAttribute(left.Mass, right.Mass);
        float size_x = GenerateAttribute(left.Size_x, right.Size_x);
        float size_y = GenerateAttribute(left.Size_y, right.Size_y);
        float size_z = GenerateAttribute(left.Size_z, right.Size_z);

        float bounce = GenerateAttribute(left.Bounciness, right.Bounciness);
        float fear = GenerateAttribute(left.Fear, right.Fear);
        float cohesion = GenerateAttribute(left.Cohesion, right.Cohesion);

        float push_strength = GenerateAttribute(left.Push_strength, right.Push_strength);
        float push_delay = GenerateAttribute(left.Push_delay, right.Push_delay);
        float jump_strength = GenerateAttribute(left.Jump_strength, right.Jump_strength);
        float jump_delay = GenerateAttribute(left.Jump_delay, right.Jump_delay);

        float color = GenerateAttribute(left.Color, right.Color);

        return new BoidAttributes(speed, mass, size_x, size_y, size_z, bounce, fear, cohesion, push_strength, push_delay, jump_strength, jump_delay, color);
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