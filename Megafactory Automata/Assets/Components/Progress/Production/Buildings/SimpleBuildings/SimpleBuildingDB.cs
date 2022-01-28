using System.Collections.Generic;

public class SimpleBuildingDB {
  #region Singleton
  private static SimpleBuildingDB _instance;
  public static SimpleBuildingDB Instance {
    get {
      if (_instance == null)
        _instance = new SimpleBuildingDB();
      return _instance;
    }
  }
  #endregion Singleton

  private Dictionary<ESimpleBuilding, SimpleBuildingData> _database;
  public SimpleBuildingData Get(ESimpleBuilding key) { return _database[key]; }

  private SimpleBuildingDB() {
    _database = new Dictionary<ESimpleBuilding, SimpleBuildingData>();

    _database[ESimpleBuilding.FARM] =
    new SimpleBuildingData(
      "Farm", "A simple producer of food.",
      5,
      Yield.OneFood
    );

    _database[ESimpleBuilding.EXCHANGE] =
    new SimpleBuildingData(
      "Exchange", "A simple producer of money.",
      5,
      Yield.OneMoney
    );

    _database[ESimpleBuilding.FACTORY] =
    new SimpleBuildingData(
      "Factory", "A simple producer of production.",
      5,
      Yield.OneProduction
    );

    _database[ESimpleBuilding.LABORATORY] =
    new SimpleBuildingData(
      "Laboratory", "A simple producer of science.",
      5,
      Yield.OneScience
    );
  }
}
