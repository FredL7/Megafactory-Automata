using System.Collections.Generic;

public class ComplexBuilding : Building {
  public bool Built { get; protected set; }

  #region Infrastructure
  private Infrastructure[] _infrastructures;
  #endregion

  public ComplexBuilding(ComplexBuildingData data)
  : base(data.name, data.description, data.productionCost, data.yield) {
    _infrastructures = new Infrastructure[data.infrastructures.Length];
    for (int i = 0; i < data.infrastructures.Length; ++i)
      _infrastructures[i] = new Infrastructure(InfrastructureDB.Instance.Get(data.infrastructures[i]));
  }

  public override Yield GetYield() {
    Yield yield = _yield;
    for (int i = 0; i < _infrastructures.Length; ++i)
      yield += _infrastructures[i].Built ? _infrastructures[i].GetYield() : Yield.Nil;

    return yield;
  }

  public Yield GetBaseYield() {
    return _yield;
  }

  public bool HasInfrastructureToBuild() {
    bool hasInfrastructureToBuild = false;

    for (int i = 0; i < _infrastructures.Length; ++i)
      if (!_infrastructures[i].Built)
        hasInfrastructureToBuild = true;

    return hasInfrastructureToBuild;
  }

  public Infrastructure[] GetInfrastructureAvailForProd() {
    List<Infrastructure> list = new List<Infrastructure>(_infrastructures.Length);
    for (int i = 0; i < _infrastructures.Length; ++i)
      //? Send all and change ui selon state
      if (!_infrastructures[i].Built)
        list.Add(_infrastructures[i]);

    return list.ToArray();
  }

  public override void OnProduced() {
    Built = true;
  }
}
