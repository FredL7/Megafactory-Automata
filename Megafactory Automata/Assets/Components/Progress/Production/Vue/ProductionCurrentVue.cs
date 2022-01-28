using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ProductionCurrentVue : MonoBehaviour, IPointerClickHandler {
  [SerializeField] private ProductionSelectionVue prodSelectVue;

  [SerializeField] private TMP_Text textfield, countdownField;
  [SerializeField] private Slider slider;

  private bool _empty;

  public void SetNoOrder() {
    textfield.text = "Select production";
    slider.value = 0;
    _empty = true;
    countdownField.text = "N/A";
  }

  public void Write(ProductionOrder order, int countdown) {
    textfield.text = order.Name;
    slider.value = 0;
    _empty = false;
    countdownField.text = countdown.ToString();
  }

  public void WriteProgress(int production, int total, int countdown) {
    float percent = Mathf.Min((float)production / (float)total, 1f);
    slider.value = percent;
    countdownField.text = countdown.ToString();
  }

  public void OnPointerClick(PointerEventData ev) {
    if (_empty)
      prodSelectVue.Open();
  }
}
