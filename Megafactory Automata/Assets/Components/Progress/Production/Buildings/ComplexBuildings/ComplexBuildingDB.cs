using System.Collections.Generic;

public class ComplexBuildingDB {
  #region Singleton
  private static ComplexBuildingDB _instance;
  public static ComplexBuildingDB Instance {
    get {
      if (_instance == null)
        _instance = new ComplexBuildingDB();
      return _instance;
    }
  }
  #endregion Singleton

  private Dictionary<EComplexBuilding, ComplexBuildingData> _database;
  public ComplexBuildingData Get(EComplexBuilding key) { return _database[key]; }

  public ComplexBuildingData GetHeadquartersData() { return _database[EComplexBuilding.HEADQUARTERS]; }

  private ComplexBuildingData[] _list;
  public ComplexBuildingData[] List { get { return _list; } }

  private ComplexBuildingDB() {
    _database = new Dictionary<EComplexBuilding, ComplexBuildingData>();

    #region Headquarters
    _database[EComplexBuilding.HEADQUARTERS] =
    new ComplexBuildingData(
      "Headquarters", "Control center of the megafactory.",
      0,
      new Yield(1, 1, 1, 1),
      EComplexBuilding.HEADQUARTERS.GetInfrastructureFromBuilding()
    );
    #endregion Headquarters

    #region Districts
    _database[EComplexBuilding.FARM_DISTRICT] =
    new ComplexBuildingData(
      "Farm District", "A complex producer of food.",
      50,
      Yield.OneFood * 2,
      EComplexBuilding.FARM_DISTRICT.GetInfrastructureFromBuilding()
    );

    _database[EComplexBuilding.FACTORY_DISTRICT] =
    new ComplexBuildingData(
      "Factory District", "A complex producer of production.",
      50,
      Yield.OneProduction * 2,
      EComplexBuilding.FACTORY_DISTRICT.GetInfrastructureFromBuilding()
    );

    _database[EComplexBuilding.MONEY_DISTRICT] =
    new ComplexBuildingData(
      "Money District", "A complex producer of money.",
      50,
      Yield.OneMoney * 2,
      EComplexBuilding.MONEY_DISTRICT.GetInfrastructureFromBuilding()
    );

    _database[EComplexBuilding.SCIENCE_DISTRICT] =
    new ComplexBuildingData(
      "Science District", "A complex producer of science.",
      50,
      Yield.OneScience * 2,
      EComplexBuilding.SCIENCE_DISTRICT.GetInfrastructureFromBuilding()
    );
    #endregion Districts

    _list = new ComplexBuildingData[] {
      _database[EComplexBuilding.FARM_DISTRICT],
      _database[EComplexBuilding.FACTORY_DISTRICT],
      _database[EComplexBuilding.MONEY_DISTRICT],
      _database[EComplexBuilding.SCIENCE_DISTRICT]
    };
  }
}
