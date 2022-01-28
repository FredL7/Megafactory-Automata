public class Infrastructure : ProductionYieldElement {
  public bool Built { get; private set; }

  // TODO (later): Prerequisite on other Infrastructure (ex: Civ6 Campus District = Library -> University -> Research Lab)

  public Infrastructure(InfrastructureData data)
  : base(data.name, data.description, data.productionCost, data.yield) { }

  public override Yield GetYield() {
    return _yield;
  }

  public override void OnProduced() {
    Built = true;
  }
}
