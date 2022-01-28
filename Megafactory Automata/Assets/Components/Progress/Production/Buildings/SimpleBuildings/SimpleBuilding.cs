public class SimpleBuilding : Building {
  public SimpleBuilding(SimpleBuildingData data)
  : base(data.name, data.description, data.productionCost, data.yield) { }

  public override Yield GetYield() {
    return _yield;
  }

  public override void OnProduced() {
    // TODO (later): w/ production flow
  }
}
