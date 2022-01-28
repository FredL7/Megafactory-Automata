public class TurnManager {
  private TurnCountVue _vueCount;
  private TurnButtonVue _vueBtn;

  private ProductionManager _production;

  private int _turn;
  private ITurnProgressible[] _turnProgressible;

  public TurnManager(
    TurnCountVue vueCount, TurnButtonVue vueBtn,
    ProductionManager production,
    ITurnProgressible[] turnProgressible
  ) {
    _vueCount = vueCount;
    _vueBtn = vueBtn;

    _production = production;
    _turnProgressible = turnProgressible;

    _turn = 1;
  }

  public void Initialize() {
    _vueCount.Write(_turn);
    DrawNextTurnBtn();
  }

  public void DrawNextTurnBtn() {
    if (!_production.HasProduction) {
      _vueBtn.DrawProductionBtn();
    } else {
      _vueBtn.DrawNextTurnBtn();
    }
  }

  public void NextTurn() {
    _turn++;

    for (int i = 0; i < _turnProgressible.Length; ++i)
      _turnProgressible[i].NextTurn();

    _vueCount.Write(_turn);
    DrawNextTurnBtn();
  }
}
