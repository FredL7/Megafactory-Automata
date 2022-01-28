public class ProductionComplexBuildingOrder : ProductionOrderWithTile {
  private ComplexBuilding _building;

  public ProductionComplexBuildingOrder(ComplexBuilding building)
  : base(building.Name, building.ProductionCost) {
    _building = building;
  }

  public override void OnComplete(ProductionManager production) {
    _building.OnProduced();
    production.FinishComplexBuildingOrder(_building, Tile);
  }
}
