using TMPro;
using UnityEngine;

public class TurnCountVue : MonoBehaviour {
  [SerializeField] private TMP_Text textField;

  public void Write(int turn) {
    textField.text = "Turn " + turn;
  }
}
