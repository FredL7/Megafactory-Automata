using UnityEngine;

public class GameManager : MonoBehaviour {
  [Header("Hex Grid")]
  [SerializeField] private HexGridVue gridVue;
  [SerializeField] private TileSelectionCtrl tileSelectionCtrl;
  [SerializeField] private HexMeshTileSelectCtrl hexMeshTileSelectCtrl;

  [Header("Megafactory")]
  [SerializeField] private MegafactoryVue megafactoryVue;

  [Header("Turn")]
  [SerializeField] private TurnCountVue turnCountVue;
  [SerializeField] private TurnButtonVue turnButtonVue;

  [Header("Production")]
  [SerializeField] private ProductionCurrentVue prodCurrentVue;
  [SerializeField] private ProductionSelectionVue prodSelectVue;

  [Header("Yield & Commodities")]
  [SerializeField] private GlobalYieldVue globalYieldVue;


  private ResourceLoader _resourceLoader;

  private HexGridManager _grid;
  private MegafactoryManager _megafactory;
  private YieldManager _yield;
  private UnitsManager _units;
  private ProductionManager _production;
  private TurnManager _turn;

  void Start() {
    // Create manager components
    _grid = new HexGridManager(gridVue);
    _megafactory = new MegafactoryManager(megafactoryVue, _grid);
    _yield = new YieldManager(globalYieldVue, _megafactory);
    _production = new ProductionManager(prodCurrentVue, prodSelectVue, tileSelectionCtrl, _yield, _megafactory);
    _turn = new TurnManager(
      turnCountVue, turnButtonVue, _production,
      new ITurnProgressible[] { _yield, _production }
    );

    _production.SetTurnManager(_turn);

    // Prepare vues
    _resourceLoader = new ResourceLoader();
    megafactoryVue.SetManagers(_resourceLoader);
    turnButtonVue.SetManagers(_turn);
    tileSelectionCtrl.SetManagers(_grid);
    hexMeshTileSelectCtrl.SetManagers(_grid);

    // Initialize the game and its systems
    _grid.Initialize();
    _megafactory.Initialize();
    _yield.Initialize();
    _production.Initialize();
    _turn.Initialize();
  }
}
