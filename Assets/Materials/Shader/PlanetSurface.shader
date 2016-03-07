Shader "Custom/PlanetSurface" 
{
	//
	// Versão com Rim do shader de Tessellation (Normal Map Removido também para performance)
	//

	Properties {
		_Color ("Main Color", Color) = (1,1,1,1)
		_MainTex ("Base (RGB) Gloss (A)", 2D) = "white" {}

		_EdgeLength ("Edge length", Range(3,50)) = 10
		_Smoothness ("Smoothness", Range(0,1)) = 0.5

	    _RimColor ("Rim Color", Color) = (0,0,0,0.0)
	    _RimPower ("Rim Power", Range(0.5,8.0)) = 3.0
	}

	SubShader { 
		Tags { "RenderType"="Opaque" }
		LOD 700


		CGPROGRAM
		#pragma surface surf BlinnPhong addshadow vertex:disp tessellate:tessEdge tessphong:_Smoothness
		#include "Tessellation.cginc"

		struct appdata {
			float4 vertex : POSITION;
			float4 tangent : TANGENT;
			float3 normal : NORMAL;
			float2 texcoord : TEXCOORD0;
			float2 texcoord1 : TEXCOORD1;
			float2 texcoord2 : TEXCOORD2;
		};

		float _EdgeLength;
		float _Smoothness;

		float4 tessEdge (appdata v0, appdata v1, appdata v2)
		{
			return UnityEdgeLengthBasedTessCull (v0.vertex, v1.vertex, v2.vertex, _EdgeLength, 0.0);
		}

		void disp (inout appdata v)
		{
			// do nothing
		}

		sampler2D _MainTex;
		fixed4 _Color;
		float4 _RimColor;
		float _RimPower;

		struct Input {
			float2 uv_MainTex;
			float3 viewDir;
		};

		void surf (Input IN, inout SurfaceOutput o) {
			fixed4 tex = tex2D(_MainTex, IN.uv_MainTex);
			o.Albedo = tex.rgb * _Color.rgb;
			o.Gloss = tex.a;
			o.Alpha = tex.a * _Color.a;

			//
			// Add Rim glow
			//
			half rim = 1.0 - saturate(dot (normalize(IN.viewDir), o.Normal));
			o.Emission = _RimColor.rgb * pow (rim, _RimPower);
		}
		ENDCG
	}

	FallBack "Bumped Specular"
}