using TMPro;
using UnityEngine;

public class ProdSelectSectionTitleVue : MonoBehaviour {
  [SerializeField] private TMP_Text textfield;

  public void Write(string title) {
    textfield.text = title;
  }
}
