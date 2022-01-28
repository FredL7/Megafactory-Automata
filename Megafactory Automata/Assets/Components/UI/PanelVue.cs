using UnityEngine;

public class PanelVue : MonoBehaviour {
  public void Open() { gameObject.SetActive(true); }
  public void Close() { gameObject.SetActive(false); }
}
