Shader "Custom/bunnyshader"
{
    Properties {
      _MainTex ("Texture", 2D) = "white" {}
      _ColorTint ("Tint", Color) = (1.0, 0.6, 0.6, 1.0)
      
      _BumpMap ("Bumpmap", 2D) = "bump" {}
    }
    SubShader {
      Tags { "RenderType" = "Opaque" }
      CGPROGRAM
      #pragma surface surf Lambert finalcolor:mycolor
      
      struct Input {
          float2 uv_MainTex;
          float2 uv_BumpMap; //norml
      };
      fixed4 _ColorTint;

      sampler2D _BumpMap;

      void mycolor (Input IN, SurfaceOutput o, inout fixed4 color)
      {
          color *= _ColorTint;
      }
      sampler2D _MainTex;
      void surf (Input IN, inout SurfaceOutput o) {
           o.Albedo = tex2D (_MainTex, IN.uv_MainTex).rgb;
           o.Normal = UnpackNormal (tex2D (_BumpMap, IN.uv_BumpMap));// norm
      }
      ENDCG
    } 
    Fallback "Diffuse"
}
