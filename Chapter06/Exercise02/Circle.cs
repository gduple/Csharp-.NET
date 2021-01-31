namespace Exercise02
{
  public class Circle : Shape
  {
    public Circle() { }

    public Circle(double radius)
    {
      this.height = radius * 2;
      this.width = radius * 2;
    }

    public override double Area
    {
      get
      {
        return (height / 2) * (height / 2) * 3.14159;
      }
    }
  }
}