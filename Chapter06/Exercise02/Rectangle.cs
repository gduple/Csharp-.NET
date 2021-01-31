namespace Exercise02
{
  public class Rectangle : Shape
  {
    
    public Rectangle() { }

    public Rectangle(double h, double w)
    {
      this.height = h;
      this.width = w;
      
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