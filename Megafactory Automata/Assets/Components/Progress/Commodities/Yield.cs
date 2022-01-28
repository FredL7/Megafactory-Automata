using System.Text;
using UnityEngine;

public struct Yield {
  public int food, money, production, science;

  public static Yield Nil = new Yield(0, 0, 0, 0);
  public static Yield OneFood = new Yield(1, 0, 0, 0);
  public static Yield OneMoney = new Yield(0, 1, 0, 0);
  public static Yield OneProduction = new Yield(0, 0, 1, 0);
  public static Yield OneScience = new Yield(0, 0, 0, 1);

  //? Use dictionnary to map ECommodities
  public Yield(int food, int money, int production, int science) {
    this.food = food; this.money = money; this.production = production; this.science = science;
  }

  public static Yield operator +(Yield a, Yield b) => new Yield(
      a.food + b.food,
      a.money + b.money,
      a.production + b.production,
      a.science + b.science
    );

  public static Yield operator *(Yield a, int i) => new Yield(
    a.food * i,
    a.money * i,
    a.production * i,
    a.science * i
  );

  public string ToDebugString() {
    return "Food: " + food + ", Money: " + money + ", Prod: " + production + ", Science: " + science;
  }

  public string ToNumberIconString() {
    StringBuilder sb = new StringBuilder();
    if (food > 0)
      sb.Append(" <sprite index=1 color=#1B5E20>+" + food + "  ");
    if (money > 0)
      sb.Append("<sprite index=2 color=#FF6F00>+" + money + "  ");
    if (production > 0)
      sb.Append("<sprite index=0 color=#BF360C>+" + production + "  ");
    if (science > 0)
      sb.Append("<sprite index=3 color=#0D47A1>+" + science + "  ");

    return sb.ToString();
  }

  public string ToIconString() {
    StringBuilder sb = new StringBuilder();
    if (food > 0)
      sb.Append("<sprite index=" + ((5 - Mathf.Min(5, food)) * 4 + 1) + " color=#1B5E20>");
    if (money > 0)
      sb.Append("<sprite index=" + ((5 - Mathf.Min(5, money)) * 4 + 2) + " color=#FF6F00>");
    if (production > 0)
      sb.Append("<sprite index=" + ((5 - Mathf.Min(5, production)) * 4 + 0) + " color=#BF360C>");
    if (science > 0)
      sb.Append("<sprite index=" + ((5 - Mathf.Min(5, science)) * 4 + 3) + " color=#0D47A1>");

    return sb.ToString();
  }
}
