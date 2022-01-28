using System.Collections.Generic;
using UnityEngine;

public class ResourceLoader {
  Dictionary<string, GameObject> _resources;

  public ResourceLoader() {
    _resources = new Dictionary<string, GameObject>();
  }

  public GameObject Load(string name) {
    if (!_resources.ContainsKey(name))
      _resources[name] = Resources.Load<GameObject>(name);

    return _resources[name];
  }

  public GameObject LoadOnce(string name) {
    return Resources.Load<GameObject>(name);
  }
}
