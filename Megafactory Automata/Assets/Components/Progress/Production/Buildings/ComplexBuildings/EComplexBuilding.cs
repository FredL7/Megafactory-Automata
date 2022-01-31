public enum EComplexBuilding {
  // Headquarters
  HEADQUARTERS,

  // Districts
  FARM_DISTRICT, FACTORY_DISTRICT, MONEY_DISTRICT, SCIENCE_DISTRICT
}

public static class EComplexBuildingExtension {
  public static EInfrastructure[] GetInfrastructureFromBuilding(this EComplexBuilding building) {
    switch (building) {
      case EComplexBuilding.HEADQUARTERS:
        return new EInfrastructure[] {
          EInfrastructure.FOOD_STORAGE,
          EInfrastructure.COIN_MINER,
          EInfrastructure.EXTRACTOR,
          EInfrastructure.DISTILLER
        };

      case EComplexBuilding.FARM_DISTRICT:
        return new EInfrastructure[] {
          EInfrastructure.FOOD_MARKET,
          EInfrastructure.SUPERMARKET,
          EInfrastructure.SHOPPING_MALL
        };

      case EComplexBuilding.FACTORY_DISTRICT:
        return new EInfrastructure[] {
          EInfrastructure.WORKSHOP,
          EInfrastructure.FACTORY,
          EInfrastructure.POWER_PLANT
        };

      case EComplexBuilding.MONEY_DISTRICT:
        return new EInfrastructure[] {
          EInfrastructure.MARKET,
          EInfrastructure.BANK,
          EInfrastructure.STOCK_EXCHANGE
        };

      case EComplexBuilding.SCIENCE_DISTRICT:
        return new EInfrastructure[] {
          EInfrastructure.LIBRARY,
          EInfrastructure.UNIVERSITY,
          EInfrastructure.RESEARCH_LAB
        };
    }

    return new EInfrastructure[0];
  }
}
