using UnityEngine;

public class GlobalYieldVue : MonoBehaviour {
  [SerializeField] private GlobalCommodityVue production, food, money, science;

  public void Write(Yield values, Yield perTurn) {
    production.Write(values.production, perTurn.production);
    food.Write(values.food, perTurn.food);
    money.Write(values.money, perTurn.money);
    science.Write(values.science, perTurn.science);
  }
}
