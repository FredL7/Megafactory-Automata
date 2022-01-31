public struct ProductionUnitData {
  public string name, description;
  public int productionCost;

  public ProductionUnitData(
    string name, string description,
    int productionCost
  ) {
    this.name = name;
    this.description = description;

    this.productionCost = productionCost;
  }
}
