Shader "Custom/DepthMaskShader"
{
    SubShader
    {
        Tags { "Queue" = "Overlay" } // Ensure that the shader is rendered after other objects

        Pass
        {
            ZTest Always // Always draw the object regardless of depth
            ColorMask RGB // Enable color rendering

            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag

            #include "UnityCG.cginc"

            struct appdata
            {
                float4 vertex : POSITION;
            };

            struct v2f
            {
                float4 vertex : SV_POSITION;
            };

            v2f vert(appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                return o;
            }

            half4 frag(v2f i) : SV_Target
            {
                return half4(0, 0, 0, 0); // Make the fragment fully transparent
            }
            ENDCG
        }
    }
}