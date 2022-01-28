using UnityEngine;

public class ProductionSelectionVue : PanelVue {
  [SerializeField] private ProductionSelectionListVue listVue;

  //? Create a second child script for current Production (to be drawn in the header of the selection panel)

  public void DrawProductionElementsList(ProductionManager manager) {
    listVue.Draw(manager);
  }
}
