using UnityEngine;
using TMPro;

public class GlobalCommodityVue : MonoBehaviour {
  [SerializeField] private TMP_Text textfield;

  public void Write(int value, int perTurn) {
    textfield.text = value + " (" + (perTurn >= 0 ? "+" : "") + perTurn + ")";
  }
}
