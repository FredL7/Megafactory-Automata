public class YieldManager : ITurnProgressible {
  private GlobalYieldVue _vue;
  private MegafactoryManager _factory;

  private Yield _accumulated;
  private Yield _perTurn;

  public int ProductionPerTurn { get { return _perTurn.production; } }
  public int ProductionAccumulated { get { return _accumulated.production; } }
  public void ResetProduction(int cost) {
    _accumulated.production -= cost;
  }

  public YieldManager(GlobalYieldVue vue, MegafactoryManager factory) {
    _vue = vue;
    _factory = factory;

    _perTurn = Yield.Nil;
    _accumulated = Yield.Nil;
  }

  public void Initialize() {
    _perTurn = _factory.GetYieldPerTurn();
    Write();
  }

  public void YieldChanged() {
    _perTurn = _factory.GetYieldPerTurn();
    Write();
  }

  public void NextTurn() {
    _accumulated += _perTurn;
    Write();
  }

  private void Write() {
    _vue.Write(_accumulated, _perTurn);
  }
}
