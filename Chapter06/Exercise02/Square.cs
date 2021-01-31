namespace Exercise02
{
  public class Square : Shape
  {

    public Square() { }

    public Square(double side)
    {
      this.height = side;
      this.width = side;
    }

    public override double Area
    {
      get
      {
        return height * width;
      }
    }

  }
}