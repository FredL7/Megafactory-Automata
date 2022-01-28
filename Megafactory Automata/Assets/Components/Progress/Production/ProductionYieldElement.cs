
public abstract class ProductionYieldElement : ProductionElement {
  protected Yield _yield;
  public abstract Yield GetYield();

  public ProductionYieldElement(
    string name, string description, int productionCost,
    Yield yield
  ) : base(name, description, productionCost) {
    _yield = yield;
  }
}
