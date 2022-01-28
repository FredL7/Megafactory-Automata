public abstract class ProductionElement {
  public string Name { get; private set; }
  public string Description { get; private set; }
  public int ProductionCost { get; private set; }

  public ProductionElement(string name, string description, int productionCost) {
    Name = name;
    Description = description;
    ProductionCost = productionCost;
  }

  public abstract void OnProduced();
}
