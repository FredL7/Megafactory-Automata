public struct SimpleBuildingData {
  public string name, description;
  public int productionCost;
  public Yield yield;

  public SimpleBuildingData(
    string name, string description,
    int productionCost,
    Yield yield
  ) {
    this.name = name;
    this.description = description;

    this.productionCost = productionCost;

    this.yield = yield;
  }
}
