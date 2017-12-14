using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;

public struct BoidAttributes
{
    public const int MAX_VALUE = 20;
    public const int MAX_SUM = 100;
    
    private static Random random = new Random();
    
    public BoidAttributes(int shape, float size, float mass, float speed, float strength, float agression, float turnSpeed, float bounciness, float fear) : this()
    {
        Shape = shape;
        Size = size;
        Mass = mass;
        Speed = speed;
        Strength = strength;
        Agression = agression;
        TurnSpeed = turnSpeed;
        Bounciness = bounciness;
        Fear = fear;
    }

    public float Speed { get; private set; }
    public float Mass { get; private set; }
    public float Strength { get; private set; }
    public float Size { get; private set; }
    public float Agression { get; private set; }
    public float TurnSpeed { get; private set; }
    public float Bounciness { get; private set; }
    public int Shape { get; private set; }
    public float Fear { get; private set; }

    public static BoidAttributes GenerateRandomBoid()
    {
        int[] values = new int[8];
        
        do
        {
            for(int i = 0; i < values.Length; i++)
            {
                values[i] = random.Next(1, MAX_VALUE);
            }
        } while (values.Sum() > MAX_SUM);

        int diff = MAX_SUM - values.Sum();
        if (diff != 0)
        {
            List<int> potentialIndices = new List<int>() {0, 1, 2, 3, 4, 5, 6, 7};
            for (int i = 0; i < diff; i++)
            {
                int index;
                do
                {
                    int randomPos = random.Next(potentialIndices.Count);
                    index = potentialIndices[randomPos];
                    if (values[index] == 20)
                    {
                        potentialIndices.Remove(index);
                    }
                } while (!potentialIndices.Contains(index));

                values[index]++;
            }
        }
        
        return new BoidAttributes(1, values[0], values[1], values[2], values[3], values[4], values[5], values[6], values[7]);
    }
}