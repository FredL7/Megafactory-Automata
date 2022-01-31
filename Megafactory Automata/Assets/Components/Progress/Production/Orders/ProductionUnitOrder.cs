public class ProductionUnitOrder : ProductionOrder {
  private ProductionUnit _unit;

  public ProductionUnitOrder(ProductionUnit unit)
  : base(unit.Name, unit.ProductionCost) {
    _unit = unit;
  }

  public override void OnComplete(ProductionManager production) {
    _unit.OnProduced();
    production.FinishUnitOrder(_unit);
  }
}
