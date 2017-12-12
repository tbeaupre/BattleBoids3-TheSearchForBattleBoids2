public struct BoidAttributes
{
    public BoidAttributes(float speed, float mass, float strength, float size, float agression, float turnSpeed, float bounciness, int shape, float fear) : this()
    {
        Speed = speed;
        Mass = mass;
        Strength = strength;
        Size = size;
        Agression = agression;
        TurnSpeed = turnSpeed;
        Bounciness = bounciness;
        Shape = shape;
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
}