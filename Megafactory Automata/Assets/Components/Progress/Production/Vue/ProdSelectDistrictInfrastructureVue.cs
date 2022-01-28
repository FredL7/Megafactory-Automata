using TMPro;
using UnityEngine;

public class ProdSelectDistrictInfrastructureVue : MonoBehaviour {
  [SerializeField] private TMP_Text textfield;
  [SerializeField] RectTransform parent;
  [SerializeField] RectTransform panel;

  public RectTransform Parent { get { return parent; } }

  public void Write(ComplexBuilding building) {
    textfield.text = building.Name;
  }

  public void SetHeight(float baseHeight, float dh) {
    panel.sizeDelta = new Vector2(0, baseHeight + dh);
    parent.sizeDelta = new Vector2(0, dh);
  }
}
