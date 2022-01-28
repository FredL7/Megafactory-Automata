public class ProductionInfrastructureOrder : ProductionOrder {
  private Infrastructure _infrastructure;

  public ProductionInfrastructureOrder(Infrastructure infrastructure)
  : base(infrastructure.Name, infrastructure.ProductionCost) {
    _infrastructure = infrastructure;
  }

  public override void OnComplete(ProductionManager production) {
    _infrastructure.OnProduced();
  }
}
