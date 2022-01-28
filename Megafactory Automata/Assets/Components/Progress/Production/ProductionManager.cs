using System.Collections.Generic;
using UnityEngine;

public class ProductionManager : ITurnProgressible, ITileSelectionCallback {
  private ProductionCurrentVue _currentVue;
  private ProductionSelectionVue _selectVue;
  private TileSelectionCtrl _tileSelectCtrl;

  private ProductionOrderWithTile _currentOrderBuffer;
  private ProductionOrder _currentOrder;
  public bool HasProduction { get { return _currentOrder != null; } }

  private YieldManager _yield;
  private MegafactoryManager _megafactory;
  private TurnManager _turn;
  public void SetTurnManager(TurnManager turn) { _turn = turn; }

  private ComplexBuilding[] _complexBuildings;
  private ComplexBuilding[] _complexBuildingsWithHQ;
  public ComplexBuilding[] ComplexBuildingsWithHQ { get { return _complexBuildingsWithHQ; } }

  public ProductionManager(
    ProductionCurrentVue currentVue, ProductionSelectionVue selectVue,
    TileSelectionCtrl tileSelectCtrl,
    YieldManager yield, MegafactoryManager megafactory
  ) {
    _currentVue = currentVue;
    _selectVue = selectVue;

    _tileSelectCtrl = tileSelectCtrl;

    _yield = yield;
    _megafactory = megafactory;
  }

  public void Initialize() {
    _currentOrder = null;

    InitDistricts();

    _currentVue.SetNoOrder();
    _selectVue.DrawProductionElementsList(this);
    _selectVue.Close();
  }

  private void InitDistricts() {
    // Complex buildings
    ComplexBuildingData[] _d = ComplexBuildingDB.Instance.List;
    _complexBuildings = new ComplexBuilding[_d.Length];
    for (int i = 0; i < _d.Length; ++i)
      _complexBuildings[i] = new ComplexBuilding(_d[i]);

    // Complex buildings w/ Headquarters
    _complexBuildingsWithHQ = new ComplexBuilding[_complexBuildings.Length + 1];
    _complexBuildingsWithHQ[0] = _megafactory.Headquarters;
    for (int i = 0; i < _complexBuildings.Length; ++i)
      _complexBuildingsWithHQ[i + 1] = _complexBuildings[i];
  }

  /*public ComplexBuilding[] GetComplexBuildingsAvailForProd() {
    List<ComplexBuilding> list = new List<ComplexBuilding>(_complexBuildings.Length + 1);

    list.Add(_megafactory.Headquarters);
    for (int i = 0; i < _complexBuildings.Length; ++i)
      //? Send all and change ui selon state
      if (!_complexBuildings[i].Built || _complexBuildings[i].HasInfrastructureToBuild())
        list.Add(_complexBuildings[i]);

    return list.ToArray();
  }*/

  public int GetProductionTime(int productionCost) {
    return Mathf.CeilToInt((float)(productionCost - _yield.ProductionAccumulated) / (float)_yield.ProductionPerTurn);
  }

  public void SetProductionOrder(ProductionOrder order) {
    if (HasProduction)
      UnityEngine.Debug.LogError("Overriding current order from " + _currentOrder.Name + " to " + order.Name);
    _currentOrder = order;

    _currentVue.Write(_currentOrder, GetProductionTime(_currentOrder.ProductionCost));
    _selectVue.Close();
    _selectVue.DrawProductionElementsList(this);
    _turn.DrawNextTurnBtn();
  }

  public void SetProductionOrderWithTileSelect(ProductionOrderWithTile order) {
    _currentOrderBuffer = order;
    _tileSelectCtrl.BeginSelection(this);
  }

  public void OnTileSelection(HexTile tile) {
    _currentOrderBuffer.Tile = tile;
    SetProductionOrder(_currentOrderBuffer);
    _currentOrderBuffer = null;
  }

  public void NextTurn() {
    if (HasProduction) {
      int progress = _yield.ProductionAccumulated;
      _currentVue.WriteProgress(progress, _currentOrder.ProductionCost, GetProductionTime(_currentOrder.ProductionCost));

      if (progress >= _currentOrder.ProductionCost)
        CompleteCurrentOrder();
    }
  }

  private void CompleteCurrentOrder() {
    int cost = _currentOrder.ProductionCost;

    _currentOrder.OnComplete(this);
    // TODO: Draw if complex
    _currentOrder = null;

    _turn.DrawNextTurnBtn();
    _yield.ResetProduction(cost);
    _yield.YieldChanged();
    _selectVue.DrawProductionElementsList(this);
    _currentVue.SetNoOrder();
  }

  //? Rename to AddBuildingToMegafactory
  public void FinishComplexBuildingOrder(ComplexBuilding building, HexTile tile) {
    _megafactory.AddComplexBuilding(building, tile);
  }
}
