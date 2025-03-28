Shader "Custom/UIVerticalGradient"
{
    Properties
    {
        [PerRendererData] _MainTex ("Sprite Texture", 2D) = "white" {}
        [KeywordEnum(Vertical, Horizontal)] _GradientType ("Gradient Type", Float) = 0
        _TopColor ("Top/Right Color", Color) = (1,1,1,1)
        _BottomColor ("Bottom/Left Color", Color) = (0,0,0,1)
        _GradientStart ("Gradient Start", Range(0, 1)) = 0.2
        _GradientEnd ("Gradient End", Range(0, 1)) = 0.8
        _Alpha ("Overall Alpha", Range(0, 1)) = 1
        
        // UI遮罩支持
        [HideInInspector] _StencilComp ("Stencil Comparison", Float) = 8
        [HideInInspector] _Stencil ("Stencil ID", Float) = 0
        [HideInInspector] _StencilOp ("Stencil Operation", Float) = 0
        [HideInInspector] _StencilWriteMask ("Stencil Write Mask", Float) = 255
        [HideInInspector] _StencilReadMask ("Stencil Read Mask", Float) = 255
        [HideInInspector] _ColorMask ("Color Mask", Float) = 15
    }

    SubShader
    {
        Tags
        {
            "Queue"="Transparent"
            "IgnoreProjector"="True"
            "RenderType"="Transparent"
            "PreviewType"="Plane"
            "CanUseSpriteAtlas"="True"
        }

        Stencil
        {
            Ref [_Stencil]
            Comp [_StencilComp]
            Pass [_StencilOp]
            ReadMask [_StencilReadMask]
            WriteMask [_StencilWriteMask]
        }

        ColorMask [_ColorMask]
        ZWrite Off
        ZTest [unity_GUIZTestMode]
        Blend SrcAlpha OneMinusSrcAlpha

        Pass
        {
            HLSLPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #pragma multi_compile _GRADIENTTYPE_VERTICAL _GRADIENTTYPE_HORIZONTAL

            #include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/Core.hlsl"

            struct Attributes
            {
                float4 positionOS : POSITION;
                float2 uv : TEXCOORD0;
                float4 color : COLOR;
            };

            struct Varyings
            {
                float4 positionCS : SV_POSITION;
                float2 uv : TEXCOORD0;
                float4 color : COLOR;
            };

            TEXTURE2D(_MainTex);
            SAMPLER(sampler_MainTex);
            float4 _TopColor;
            float4 _BottomColor;
            float _GradientStart;
            float _GradientEnd;
            float _Alpha;

            Varyings vert(Attributes input)
            {
                Varyings output;
                output.positionCS = TransformObjectToHClip(input.positionOS.xyz);
                output.uv = input.uv;
                output.color = input.color;
                return output;
            }

            float4 frag(Varyings input) : SV_Target
            {
                float4 texColor = SAMPLE_TEXTURE2D(_MainTex, sampler_MainTex, input.uv);
                float gradientFactor;
                
                #if defined(_GRADIENTTYPE_VERTICAL)
                    gradientFactor = smoothstep(_GradientStart, _GradientEnd, input.uv.y);
                #else
                    gradientFactor = smoothstep(_GradientStart, _GradientEnd, input.uv.x);
                #endif
                
                float4 gradientColor = lerp(_BottomColor, _TopColor, gradientFactor);
                float4 finalColor = gradientColor * texColor * input.color;
                finalColor.a *= _Alpha;
                return finalColor;
            }
            ENDHLSL
        }
    }
}
