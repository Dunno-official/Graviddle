Shader "Unlit/SpriteOutline"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
        _OutlineColor("Outline color", Color) = (1,1,1,1)
        _OutlineThickness("Outline thickness", Range(0, 0.1)) = 0.01
    }
    SubShader
    {
        Tags
        {
            "RenderType"="Transparent" "Queue" = "Transparent"
        }
        LOD 100

        Blend SrcAlpha OneMinusSrcAlpha
        Cull Off

        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #include "UnityCG.cginc"

            struct appdata
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
                fixed4 color : COLOR;
            };

            struct v2f
            {
                float2 uv : TEXCOORD0;
                float4 vertex : SV_POSITION;
                fixed4 color : COLOR;
            };

            sampler2D _MainTex;
            float4 _MainTex_ST;
            half4 _OutlineColor;
            float _OutlineThickness;
            static float DiagonalLength = 0.7f; // 0.7 * 0.7 ~ 1
            static float2 sampleDirections[8] =
            {
                float2(1, 0), float2(-1, 0), float2(0, 1), float2(0, -1),
                float2(DiagonalLength, DiagonalLength), float2(-DiagonalLength, -DiagonalLength),
                float2(-DiagonalLength, DiagonalLength), float2(DiagonalLength, -DiagonalLength)
            };

            v2f vert(appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = TRANSFORM_TEX(v.uv, _MainTex);
                o.color = v.color;
                return o;
            }

            float GetMaxAlpha(float2 uv)
            {
                float maxAlpha = 0;
            
                for (int i = 0; i < 8; ++i)
                {
                    const float2 sampleUv = uv + sampleDirections[i] * _OutlineThickness;
                    maxAlpha = max(maxAlpha, tex2D(_MainTex, sampleUv).a);
                }
            
                return maxAlpha;
            }

            fixed4 frag(v2f i) : SV_Target
            {
                fixed4 color = tex2D(_MainTex, i.uv);
                
                color.rgb = lerp(_OutlineColor, color.rgb, color.a);
                color.a = GetMaxAlpha(i.uv);
                
                return color;
            }
            ENDCG
        }
    }
}