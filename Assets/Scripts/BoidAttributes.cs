using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;

public struct BoidAttributes
{
    public const int MAX_VALUE = 20;
    public const int MAX_SUM = 100;
    
    private static Random random = new Random();
    
    public BoidAttributes(float speed, float mass, float size_x, float size_y, float size_z, float cohesion, float bounciness, float fear, float push_strength, float push_delay, float jump_strength, float jump_delay, float color) : this()
    {

        Speed = speed;
        Mass = mass;
        Size_x = size_x;
        Size_y = size_y;
        Size_z = size_z;

        Bounciness = bounciness;
        Fear = fear;
        Cohesion = cohesion;

        Push_strength = push_strength;
        Push_delay = push_delay;
        Jump_strength = jump_strength;
        Jump_delay = jump_delay;
        Color = color;

    }

    public float Speed { get; private set; }
    public float Mass { get; private set; }
    public float Size_x { get; private set; }
    public float Size_y { get; private set; }
    public float Size_z { get; private set; }
    public float Bounciness { get; private set; }
    public float Fear { get; private set; }
    public float Cohesion { get; private set; }

    public float Push_strength { get; private set; }
    public float Push_delay { get; private set; }
    public float Jump_strength { get; private set; }
    public float Jump_delay { get; private set; }

    public float Color { get; private set; }

    public static BoidAttributes GenerateRandomBoid()
    {
        int[] values = new int[13];
        
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
            List<int> potentialIndices = new List<int>() {0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12};
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
        
        return new BoidAttributes(values[0], values[1], values[2], values[3], values[4], values[5], values[6], values[7], values[8], values[9], values[10], values[11], values[12]);
    }
}