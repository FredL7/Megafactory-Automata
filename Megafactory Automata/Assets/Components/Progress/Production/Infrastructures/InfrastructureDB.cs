using System.Collections.Generic;

public class InfrastructureDB {
  #region Singleton
  private static InfrastructureDB _instance;
  public static InfrastructureDB Instance {
    get {
      if (_instance == null)
        _instance = new InfrastructureDB();
      return _instance;
    }
  }
  #endregion Singleton

  private Dictionary<EInfrastructure, InfrastructureData> _database;
  public InfrastructureData Get(EInfrastructure key) { return _database[key]; }

  private InfrastructureDB() {
    _database = new Dictionary<EInfrastructure, InfrastructureData>();

    DBHeadquarters();
    DBFarmDistrict();
    DBFactoryDistrict();
    DBMoneyDistrict();
    DBScienceDistrict();
  }

  private void DBHeadquarters() {
    _database[EInfrastructure.FOOD_STORAGE] =
    new InfrastructureData(
      "Food Storage", "Provides a small bonus to food.",
      10,
      Yield.OneFood
    );

    _database[EInfrastructure.COIN_MINER] =
    new InfrastructureData(
      "Coin Miner", "Provides a small bonus to money.",
      10,
      Yield.OneMoney
    );

    _database[EInfrastructure.EXTRACTOR] =
    new InfrastructureData(
      "Extractor", "Provides a small bonus to production.",
      10,
      Yield.OneProduction
    );

    _database[EInfrastructure.DISTILLER] =
    new InfrastructureData(
      "Distiller", "Provides a small bonus to science.",
      10,
      Yield.OneScience
    );
  }

  private void DBFarmDistrict() {
    _database[EInfrastructure.FOOD_MARKET] =
    new InfrastructureData(
      "Food Market", "Provides a small bonus to food.",
      15,
      Yield.OneFood
    );

    _database[EInfrastructure.SUPERMARKET] =
    new InfrastructureData(
      "Supermarket", "Provides a medium bonus to food.",
      25,
      Yield.OneFood * 2
    );

    _database[EInfrastructure.SHOPPING_MALL] =
    new InfrastructureData(
      "Shopping Mall", "Provides a large bonus to food.",
      40,
      Yield.OneFood * 3
    );
  }

  private void DBFactoryDistrict() {
    _database[EInfrastructure.WORKSHOP] =
    new InfrastructureData(
      "Workshop", "provides a small bonus to production.",
      15,
      Yield.OneProduction
    );

    _database[EInfrastructure.FACTORY] =
    new InfrastructureData(
      "Factory", "provides a medium bonus to production.",
      25,
      Yield.OneProduction * 2
    );

    _database[EInfrastructure.POWER_PLANT] =
    new InfrastructureData(
      "Power Plant", "provides a large bonus to production.",
      40,
      Yield.OneProduction * 3
    );
  }

  private void DBMoneyDistrict() {
    _database[EInfrastructure.MARKET] =
    new InfrastructureData(
      "Market", "provides a small bonus to money.",
      15,
      Yield.OneMoney
    );

    _database[EInfrastructure.BANK] =
    new InfrastructureData(
      "Bank", "provides a medium bonus to money.",
      25,
      Yield.OneMoney * 2
    );

    _database[EInfrastructure.STOCK_EXCHANGE] =
    new InfrastructureData(
      "Stock Exchange", "provides a large bonus to money.",
      40,
      Yield.OneMoney * 3
    );
  }

  private void DBScienceDistrict() {
    _database[EInfrastructure.LIBRARY] =
    new InfrastructureData(
      "Library", "provides a small bonus to science.",
      15,
      Yield.OneScience
    );

    _database[EInfrastructure.UNIVERSITY] =
    new InfrastructureData(
      "University", "provides a medium bonus to science.",
      25,
      Yield.OneScience * 2
    );

    _database[EInfrastructure.RESEARCH_LAB] =
    new InfrastructureData(
      "Research Lab", "provides a large bonus to science.",
      40,
      Yield.OneScience * 3
    );
  }

}
