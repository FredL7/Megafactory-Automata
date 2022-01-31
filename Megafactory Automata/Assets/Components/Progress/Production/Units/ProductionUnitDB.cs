using System.Collections.Generic;

//? Generic DB
public class ProductionUnitDB {
  #region Singleton
  private static ProductionUnitDB _instance;
  public static ProductionUnitDB Instance {
    get {
      if (_instance == null)
        _instance = new ProductionUnitDB();
      return _instance;
    }
  }
  #endregion Singleton

  private Dictionary<EProductionUnit, ProductionUnitData> _database;
  public ProductionUnitData Get(EProductionUnit key) { return _database[key]; }

  private ProductionUnitData[] _list;
  public ProductionUnitData[] List { get { return _list; } }

  private ProductionUnitDB() {
    _database = new Dictionary<EProductionUnit, ProductionUnitData>();

    _database[EProductionUnit.BUILDER] =
    new ProductionUnitData(
      "Worker", "Unit able to transform into a simple building",
      20
    );

    _list = new ProductionUnitData[] {
      _database[EProductionUnit.BUILDER]
    };
  }
}
