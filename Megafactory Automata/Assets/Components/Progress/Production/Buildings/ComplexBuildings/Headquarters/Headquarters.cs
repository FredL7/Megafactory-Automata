public class Headquarters : ComplexBuilding {
  // private int _capacity = 10;
  // private int _range = 2;
  private int _vision = 3;

  public Headquarters(ComplexBuildingData data)
  : base(data) {
    Vision = _vision;
    Built = true;
  }
}
