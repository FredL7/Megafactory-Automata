public struct InfrastructureData {
  public string name, description;
  public int productionCost;
  public Yield yield;

  // TODO (later): Prerequisite

  public InfrastructureData(
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
