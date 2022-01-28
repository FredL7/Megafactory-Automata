public abstract class ProductionOrderWithTile : ProductionOrder {
  public HexTile Tile { get; set; }

  public ProductionOrderWithTile(string name, int productionCost)
  : base(name, productionCost) { }
}
