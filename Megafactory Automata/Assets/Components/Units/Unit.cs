public class Unit {
  public string Name { get; private set; }
  public string Description { get; private set; }

  public Unit(ProductionUnit data) {
    Name = data.Name;
    Description = data.Description;
  }
}
