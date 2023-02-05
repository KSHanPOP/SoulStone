Shader "Shader Graphs/Polybrush_Ground_Shader" {
	Properties {
		_Smoothness ("Smoothness", Float) = 0
		Vector1_e266661ecc804b7f8121f14d87b5bd13 ("Contrast", Float) = 1
		_AO ("AO", Float) = 1
		_Metallic ("Metallic", Float) = 0
		_Color ("Color", Vector) = (1,1,1,1)
		_Tiling ("Tiling", Float) = 1
		[NoScaleOffset] _MainTex ("Main Texture", 2D) = "white" {}
		_Tiling_Normal ("Tiling_Normal", Float) = 1
		_Tiling_Normal_1 ("Normal_Strength", Float) = 1
		[NoScaleOffset] _Main_Texture_Normal ("Main Texture_Normal", 2D) = "bump" {}
		_RedTiling ("Red Tiling", Float) = 1
		[NoScaleOffset] _RedDiffuse ("Red Diffuse", 2D) = "black" {}
		[NoScaleOffset] _RedHeightmap ("Red Heightmap", 2D) = "white" {}
		_GreenTiling ("Green Tiling", Float) = 1
		[NoScaleOffset] _GreenDiffuse ("Green Diffuse", 2D) = "black" {}
		[NoScaleOffset] _GreenHeightmap ("Green Heightmap", 2D) = "black" {}
		_BlueTiling ("Blue Tiling", Float) = 1
		[NoScaleOffset] _BlueDiffuse ("Blue Diffuse", 2D) = "black" {}
		[NoScaleOffset] _BlueHeightmap ("Blue Heightmap", 2D) = "black" {}
		_AlphaTiling ("Alpha Tiling", Float) = 1
		[NoScaleOffset] _AlphaDiffuse ("Alpha Diffuse", 2D) = "black" {}
		[NoScaleOffset] _AlphaHeightmap ("Alpha Heightmap", 2D) = "black" {}
		[HideInInspector] [NoScaleOffset] unity_Lightmaps ("unity_Lightmaps", 2DArray) = "" {}
		[HideInInspector] [NoScaleOffset] unity_LightmapsInd ("unity_LightmapsInd", 2DArray) = "" {}
		[HideInInspector] [NoScaleOffset] unity_ShadowMasks ("unity_ShadowMasks", 2DArray) = "" {}
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
	Fallback "Hidden/Shader Graph/FallbackError"
	//CustomEditor "ShaderGraph.PBRMasterGUI"
}