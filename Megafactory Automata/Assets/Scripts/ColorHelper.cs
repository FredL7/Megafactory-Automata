using UnityEngine;

public static class ColorHelper {
  public static Color White = new Color(1f, 1f, 1f, 1f);
}

public class ColorDelta {
  private const float randStrength = 0.035f;
  private float randValue;

  public ColorDelta() {
    randValue = Random.Range(-1f, 1f) * randStrength;
  }

  public Color Mix(Color color) {
    return new Color(
        Mathf.Min(1f, randValue + color.r),
        Mathf.Min(1f, randValue + color.g),
        Mathf.Min(1f, randValue + color.b,
        color.a
      )
    );
  }
}

/*
public class ColorDelta {
  private const float randEffect = 0.035f;
  private float r, g, b;

  public ColorDelta() {
    r = Random.Range(-1.0f, 1.0f) * randEffect;
    g = Random.Range(-1.0f, 1.0f) * randEffect;
    b = Random.Range(-1.0f, 1.0f) * randEffect;
  }

  public Color MixHue(Color color) {
    return new Color(
        Mathf.Min(1f, r + color.r),
        Mathf.Min(1f, g + color.g),
        Mathf.Min(1f, b + color.b,
        color.a
      )
    );
  }

  public Color MixBrightness(Color color) {
    return new Color(
        Mathf.Min(1f, r + color.r),
        Mathf.Min(1f, r + color.g),
        Mathf.Min(1f, r + color.b,
        color.a
      )
    );
  }
}
*/

/*
using UnityEngine;

public static class ColorDatabase {
  public static Color Default = Color.black;

  public static Color Green = new Color(76f / 255f, 175f / 255f, 80f / 255f, 1f); // rgb(76, 175, 80)
  public static Color LightGreen = new Color(139f / 255f, 195f / 255f, 74f / 255f, 1f); // rgb(139, 195, 74)
  public static Color Brown = new Color(121f / 255f, 85f / 255f, 72f / 255f, 1f); // rgb(121, 85, 72)
  public static Color Grey = new Color(158f / 255f, 158f / 255f, 158f / 255f, 1f); // rgb(158, 158, 158)

  public static Color Forest { get { return Green; } }
  public static Color Plains { get { return LightGreen; } }
  public static Color Mountain { get { return Brown; } }
}
*/
