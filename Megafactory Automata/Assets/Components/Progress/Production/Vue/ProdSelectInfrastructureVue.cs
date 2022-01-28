using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class ProdSelectInfrastructureVue : MonoBehaviour, IPointerClickHandler {
  [SerializeField] private TMP_Text namefield;
  [SerializeField] private TMP_Text turnfield;

  private ProductionManager _production;
  private Infrastructure _infrastructure;

  public void Write(Infrastructure infrastructure, int turn, ProductionManager production) {
    _infrastructure = infrastructure;
    _production = production;

    namefield.text = _infrastructure.Name;
    turnfield.text = turn.ToString();
  }

  public void OnPointerClick(PointerEventData e) {
    if (e.pointerId == -1) { // Left click
      ProductionInfrastructureOrder order = new ProductionInfrastructureOrder(_infrastructure);
      _production.SetProductionOrder(order);
    }
  }
}
