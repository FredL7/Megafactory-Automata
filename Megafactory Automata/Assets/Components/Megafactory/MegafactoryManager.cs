public class MegafactoryManager {
  private MegafactoryVue _vue;
  private HexGridManager _grid;

  #region Buildings
  private BuildingsManager _buildings;
  public Headquarters Headquarters { get { return _buildings.Headquarters; } }
  public Yield GetYieldPerTurn() { return _buildings.GetYieldPerTurn(); }
  #endregion Buildings


  public MegafactoryManager(MegafactoryVue vue, HexGridManager grid) {
    _vue = vue;
    _grid = grid;

    _buildings = new BuildingsManager();
  }

  public void Initialize() {
    _buildings.Initialize(_grid.Origin);
    _vue.DrawBuilding(_buildings.Headquarters);
    _grid.AddVision(_buildings.Headquarters);
  }

  public void AddComplexBuilding(ComplexBuilding building, HexTile tile) {
    _buildings.AddComplexBuilding(building, tile);
    // TODO: affect neighbouring buildings
    _vue.DrawBuilding(building);
  }
}
