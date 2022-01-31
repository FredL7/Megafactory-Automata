using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class ProdSelectUnitVue : MonoBehaviour, IPointerClickHandler {
  [SerializeField] private TMP_Text namefield;
  [SerializeField] private TMP_Text turnfield;

  private ProductionManager _production;
  private ProductionUnit _unit;

  public void Write(ProductionUnit unit, int turn, ProductionManager production) {
    _unit = unit;
    _production = production;

    namefield.text = _unit.Name;
    turnfield.text = turn.ToString();
  }

  public void OnPointerClick(PointerEventData e) {
    if (e.pointerId == -1) {
      ProductionUnitOrder order = new ProductionUnitOrder(_unit);
      _production.SetProductionOrder(order);
    }
  }
}
