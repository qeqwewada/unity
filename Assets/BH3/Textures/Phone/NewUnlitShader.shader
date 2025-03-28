Shader "UI/EdgeGlow" {
    Properties {
        _MainTex ("Texture", 2D) = "white" {}
        _GlowColor ("Glow Color", Color) = (1,1,1,1)
        _GlowWidth ("Glow Width", Range(0, 0.5)) = 0.1
    }
    SubShader {
        Tags { "Queue"="Transparent" "RenderType"="Transparent" }
        Blend SrcAlpha OneMinusSrcAlpha

        Pass {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #include "UnityCG.cginc"

            struct appdata {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };

            struct v2f {
                float2 uv : TEXCOORD0;
                float4 vertex : SV_POSITION;
            };

            sampler2D _MainTex;
            float4 _GlowColor;
            float _GlowWidth;

            v2f vert (appdata v) {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = v.uv;
                return o;
            }

            fixed4 frag (v2f i) : SV_Target {
                // 边缘检测
                float edge = max(
                    step(_GlowWidth, i.uv.x) + step(_GlowWidth, 1 - i.uv.x),
                    step(_GlowWidth, i.uv.y) + step(_GlowWidth, 1 - i.uv.y)
                );
                // 混合原图与发光
                fixed4 col = tex2D(_MainTex, i.uv);
                col.rgb += _GlowColor.rgb * edge * _GlowColor.a;
                return col;
            }
            ENDCG
        }
    }
}