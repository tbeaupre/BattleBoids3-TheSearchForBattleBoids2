using System.Collections.Generic;

namespace Manager
{
	public static class BoidManager
	{
		public const int NUM_BOIDS = 20;
		private static List<BoidAttributes> boids = InitialFlock();

		public static List<BoidAttributes> GetCurrentBoids()
		{
			return boids;
		}

		public static void AddBoid(BoidAttributes boid)
		{
			boids.Add(boid);
		}

		public static void AddBoids(List<BoidAttributes> newBoids)
		{
			boids.AddRange(newBoids);
		}

		public static void RemoveBoid(BoidAttributes boid)
		{
			boids.Remove(boid);
		}

		private static List<BoidAttributes> InitialFlock()
		{
			var init = new List<BoidAttributes>();
			
			for (int i = 0; i < NUM_BOIDS; i++)
			{
				init.Add(BoidAttributes.GenerateRandomBoid());
			}
			
			return init;
		}
	}
}
