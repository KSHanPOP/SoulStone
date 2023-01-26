Shader "Shader Graphs/VFX_Main_Shader" {
	Properties {
		_Emission ("Emission", Range(0, 5)) = 1
		_Color ("Color", Vector) = (1,1,1,0)
		[NoScaleOffset] Main_Texture ("Main_Texture", 2D) = "white" {}
		Texture_Tiling ("Texture_Tiling", Vector) = (1,1,0,0)
		Texture_Speed ("Texture_Speed", Vector) = (0,0,0,0)
		[NoScaleOffset] Noise_Texture ("Noise_Texture", 2D) = "white" {}
		Noise_Power ("Noise_Power", Range(0, 2)) = 0
		Noise_Speed ("Noise_Speed", Vector) = (0,-0.5,0,0)
		Noise_Tiling ("Noise_Tiling", Vector) = (1,1,0,0)
		Cull_Front ("Cull_Front", Range(0, 1)) = 1
		Cull_Back ("Cull_Back", Range(0, 1)) = 0
		_Float ("Float", Float) = 0
		Deformation ("Deformation", Range(0, 5)) = 0
		Deformation_Speed ("Deformation_Speed", Range(0, 5)) = 5
		Deformation_Noise ("Deformation_Noise", Range(0, 20)) = 0
		_Min_Global_Alpha ("Min_Global_Alpha", Range(0, 1)) = 0
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

		fixed4 _Color;
		struct Input
		{
			float2 uv_MainTex;
		};
		
		void surf(Input IN, inout SurfaceOutputStandard o)
		{
			o.Albedo = _Color.rgb;
			o.Alpha = _Color.a;
		}
		ENDCG
	}
	Fallback "Hidden/Shader Graph/FallbackError"
}