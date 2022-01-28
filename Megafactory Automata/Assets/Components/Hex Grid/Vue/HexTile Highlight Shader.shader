Shader "Custom/HexTile Highlight Shader" {
  Properties {
      _Color ("Color", Color) = (1, 1, 1, 1)
  }

  SubShader {
    Tags { "Queue"="Transparent" "RenderType"="Transparent" }

    Pass {
      ZWrite Off
      Blend SrcAlpha OneMinusSrcAlpha

      CGPROGRAM
      #pragma vertex vert alpha
      #pragma fragment frag alpha

      #include "UnityCG.cginc"

      struct appdata {
        float4 vertex : POSITION;
        float2 uv : TEXCOORD0;
      };

      struct v2f {
        float2 uv : TEXCOORD0;
        float4 vertex : SV_POSITION;
      };

      float4 _Color;

      v2f vert (appdata v) {
        v2f o;
        o.vertex = UnityObjectToClipPos(v.vertex);
        o.uv = v.uv;
        return o;
      }

      float remap (float s, float a1, float a2, float b1, float b2) {
        return b1 + (s-a1)*(b2-b1)/(a2-a1);
      }

      fixed4 frag (v2f i) : SV_Target {
        float border = i.uv.y > 0.8 && i.uv.y < 0.9;
        border *= 0.8;

        float gradient = (i.uv.y < 0.8) * i.uv.y;
        gradient *= remap(i.uv.y, 0.4, 0.8, 0, 1); // TODO: Remap
        gradient *= 0.75;

        float t = border + gradient;

        return float4(_Color.rgb, t);
      }

      ENDCG
    }
  }
}
