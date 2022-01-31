using System.Collections.Generic;

public class UnitsManager {
  List<Unit> _units;

  public Unit AddUnit(ProductionUnit data) {
    Unit unit = new Unit(data);
    return unit;
  }
}
