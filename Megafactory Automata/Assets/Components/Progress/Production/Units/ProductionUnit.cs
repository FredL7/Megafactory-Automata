public class ProductionUnit : ProductionElement {
  public ProductionUnit(ProductionUnitData data)
  : base(data.name, data.description, data.productionCost) { }

  public override void OnProduced() { }
}
