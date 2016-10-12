//Wrote by Andrew M.

Shader "CBG/Dissolve/DissolveDiffuse" 
{

  Properties {
    _Color("Color", Color) = (1,1,1,1)
    _DissolvePower ("Dissolve Power", Range(0.65, -0.05)) = 0.2
    _DissolveEmissionThickness ("Dissolve Emission Thickness", Range(-0.02, -0.05)) = -0.03
    _DissolveEmissionColor ("Dissolve Emission Color", Color) = (1,1,1)
    _MainTex ("Main Texture", 2D) = "white"{}
    _DissolveTex ("Dissolve Texture", 2D) = "white"{}    
  }

  SubShader 
  {
  
    Tags {"IgnoreProjector"="True" "RenderType"="TransparentCutout"}
    LOD 200 
    Cull Off

    CGPROGRAM
    #pragma surface surf Lambert alphatest:Zero addshadow
    #pragma target 3.0
    
    fixed4 _Color;
    sampler2D _MainTex;
    sampler2D _DissolveTex;
    float3 _DissolveEmissionColor;
    fixed _DissolveEmissionThickness;
    fixed _DissolvePower;

   struct Input 
   {
     float2 uv_MainTex;
     float2 uv_DissolveTex;
   };
 
   void surf (Input IN, inout SurfaceOutput o)
   {     
     half4 tex = tex2D(_MainTex, IN.uv_MainTex);
     half4 texd = tex2D(_DissolveTex, IN.uv_DissolveTex);
 
     o.Albedo = tex.rgb * _Color;
     o.Gloss = tex.a; 
     o.Alpha = _DissolvePower - texd.r;
     
     if ((o.Alpha < 0)&&(o.Alpha > _DissolveEmissionThickness/3)){
       o.Alpha = 1;
       o.Albedo = _DissolveEmissionColor;
     }          
     if ((o.Alpha < _DissolveEmissionThickness/3)&&(o.Alpha > _DissolveEmissionThickness/2)){
       o.Alpha = 1;
       o.Albedo = _DissolveEmissionColor * 1.5;
     }
     if ((o.Alpha < _DissolveEmissionThickness/2)&&(o.Alpha > _DissolveEmissionThickness)){
       o.Alpha = 1;
       o.Albedo = (0,0,0,0);
     }
   }  
   ENDCG
  }
}