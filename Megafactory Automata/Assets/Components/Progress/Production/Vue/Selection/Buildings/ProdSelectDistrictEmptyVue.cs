using TMPro;
using UnityEngine;

public class ProdSelectDistrictEmptyVue : MonoBehaviour {
  [SerializeField] private TMP_Text namefield;

  public void Write(ComplexBuilding building) {
    namefield.text = building.Name;
  }
}
