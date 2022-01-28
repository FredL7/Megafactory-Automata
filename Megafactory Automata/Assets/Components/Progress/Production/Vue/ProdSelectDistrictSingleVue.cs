using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class ProdSelectDistrictSingleVue : MonoBehaviour, IPointerClickHandler {
  [SerializeField] private TMP_Text namefield;
  [SerializeField] private TMP_Text turnfield;

  private ProductionManager _production;
  private ComplexBuilding _building;

  public void Write(ComplexBuilding building, int turn, ProductionManager production) {
    _building = building;
    _production = production;

    namefield.text = _building.Name;
    turnfield.text = turn.ToString();
  }

  public void OnPointerClick(PointerEventData e) {
    if (e.pointerId == -1) {
      ProductionComplexBuildingOrder order = new ProductionComplexBuildingOrder(_building);
      _production.SetProductionOrderWithTileSelect(order);
    }
  }
}
