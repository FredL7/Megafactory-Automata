using UnityEngine;
using UnityEngine.EventSystems;

public class TurnButtonVue : MonoBehaviour, IPointerClickHandler {
  [SerializeField] private ProductionSelectionVue prodSelectVue;

  [SerializeField] private GameObject nextTurnBtn;
  [SerializeField] private GameObject productionBtn;

  private TurnManager _turn;

  private enum State { NEXT_TURN, PRODUCTION_SELECT };
  private State _state;

  public void SetManagers(TurnManager turn) { _turn = turn; }

  public void DrawNextTurnBtn() {
    productionBtn.SetActive(false);
    nextTurnBtn.SetActive(true);
    _state = State.NEXT_TURN;
  }

  public void DrawProductionBtn() {
    nextTurnBtn.SetActive(false);
    productionBtn.SetActive(true);
    _state = State.PRODUCTION_SELECT;
  }

  public void OnPointerClick(PointerEventData ev) {
    switch (_state) {
      case State.NEXT_TURN: _turn.NextTurn(); break;
      case State.PRODUCTION_SELECT: prodSelectVue.Open(); break;
    }
  }
}
