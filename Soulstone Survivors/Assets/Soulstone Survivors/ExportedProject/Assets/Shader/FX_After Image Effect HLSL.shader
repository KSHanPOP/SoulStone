Shader "FX/After Image Effect HLSL" {
	Properties {
		_Color ("Extra Color", Vector) = (1,1,1,1)
		_RimColor ("Rim Color", Vector) = (0,1,1,1)
		_MainTex ("Main Texture", 2D) = "black" {}
		_RimPower ("Rim Power", Range(1, 50)) = 20
		[PerRendererData] _Fade ("Fade Amount", Range(0, 1)) = 1
		_Grow ("Grow", Range(0, 1)) = 0.05
	}
	//DummyShaderTextExporter
	SubShader{
		Tags { "RenderType"="Opaque" }
		LOD 200
		CGPROGRAM
#pragma surface surf Standard
#pragma target 3.0

		sampler2D _MainTex;
		fixed4 _Color;
		struct Input
		{
			float2 uv_MainTex;
		};
		
		void surf(Input IN, inout SurfaceOutputStandard o)
		{
			fixed4 c = tex2D(_MainTex, IN.uv_MainTex) * _Color;
			o.Albedo = c.rgb;
			o.Alpha = c.a;
		}
		ENDCG
	}
}