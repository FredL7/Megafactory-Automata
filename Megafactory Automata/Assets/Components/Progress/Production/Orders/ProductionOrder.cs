public abstract class ProductionOrder {
  public string Name { get; private set; }
  public int ProductionCost { get; private set; }

  public ProductionOrder(string name, int productionCost) {
    Name = name;
    ProductionCost = productionCost;
  }

  public abstract void OnComplete(ProductionManager production);
}
