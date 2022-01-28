public struct ComplexBuildingData {
  public string name, description;
  public int productionCost;
  public Yield yield;

  public EInfrastructure[] infrastructures;

  public ComplexBuildingData(
    string name, string description,
    int productionCost,
    Yield yield, EInfrastructure[] infrastructures
  ) {
    this.name = name;
    this.description = description;

    this.productionCost = productionCost;

    this.yield = yield;
    this.infrastructures = infrastructures;
  }
}
