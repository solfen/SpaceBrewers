// Shader created with Shader Forge v1.19 
// Shader Forge (c) Neat Corporation / Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.19;sub:START;pass:START;ps:flbk:,iptp:0,cusa:False,bamd:0,lico:1,lgpr:1,limd:3,spmd:1,trmd:0,grmd:1,uamb:True,mssp:True,bkdf:True,hqlp:False,rprd:True,enco:False,rmgx:True,rpth:1,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:0,bsrc:0,bdst:1,dpts:2,wrdp:True,dith:0,rfrpo:True,rfrpn:Refraction,coma:15,ufog:True,aust:True,igpj:False,qofs:0,qpre:1,rntp:1,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5,fgcg:0.5,fgcb:0.5,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False;n:type:ShaderForge.SFN_Final,id:2865,x:33068,y:32683,varname:node_2865,prsc:2|diff-3489-OUT,spec-2509-R,gloss-7964-OUT,normal-5964-RGB,emission-2256-OUT;n:type:ShaderForge.SFN_Color,id:6665,x:29923,y:32603,ptovrint:False,ptlb:Shirt Color,ptin:_ShirtColor,varname:_Color,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0,c2:1,c3:0.006896496,c4:1;n:type:ShaderForge.SFN_Tex2d,id:7736,x:29923,y:32174,ptovrint:True,ptlb:Base Color,ptin:_MainTex,varname:_MainTex,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:b289d1633e60bb246ab9eeb505a07f72,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Tex2d,id:5964,x:32119,y:32943,ptovrint:True,ptlb:Normal Map,ptin:_BumpMap,varname:_BumpMap,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:459a3b9be79e7104080ffa935a442c2e,ntxv:3,isnm:True;n:type:ShaderForge.SFN_Tex2d,id:2509,x:32189,y:32476,ptovrint:False,ptlb:Metallic,ptin:_Metallic,varname:node_2509,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:6fd05ae5d3ecfa543be871e73f266488,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Tex2d,id:6920,x:31801,y:32890,ptovrint:False,ptlb:Roughness,ptin:_Roughness,varname:node_6920,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:1ec06fa1bb71867498b1140f3018b866,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Add,id:7964,x:32066,y:32724,varname:node_7964,prsc:2|A-906-OUT,B-6920-R;n:type:ShaderForge.SFN_OneMinus,id:906,x:31801,y:32715,varname:node_906,prsc:2|IN-304-OUT;n:type:ShaderForge.SFN_Lerp,id:1571,x:30628,y:32109,varname:node_1571,prsc:2|A-4882-OUT,B-2241-OUT,T-3352-R;n:type:ShaderForge.SFN_Tex2d,id:3352,x:29923,y:32391,ptovrint:False,ptlb:Masks,ptin:_Masks,varname:node_3352,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:b91d16493fb3725409433d051117b75f,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Lerp,id:4801,x:30621,y:32366,varname:node_4801,prsc:2|A-4882-OUT,B-967-OUT,T-3352-G;n:type:ShaderForge.SFN_Lerp,id:9151,x:30618,y:32623,varname:node_9151,prsc:2|A-4882-OUT,B-8081-OUT,T-3352-B;n:type:ShaderForge.SFN_Color,id:7726,x:29923,y:31958,ptovrint:False,ptlb:Scarf Color,ptin:_ScarfColor,varname:_Color_copy,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0.9926471,c2:0.058391,c3:0.058391,c4:1;n:type:ShaderForge.SFN_Color,id:9967,x:29923,y:32789,ptovrint:False,ptlb:Pants Color,ptin:_PantsColor,varname:_Color_copy_copy,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0.1999998,c2:0,c3:1,c4:1;n:type:ShaderForge.SFN_Multiply,id:2241,x:30267,y:32038,varname:node_2241,prsc:2|A-7726-RGB,B-7736-RGB;n:type:ShaderForge.SFN_Multiply,id:967,x:30274,y:32383,varname:node_967,prsc:2|A-7736-RGB,B-6665-RGB;n:type:ShaderForge.SFN_Multiply,id:8081,x:30328,y:32637,varname:node_8081,prsc:2|A-7736-RGB,B-9967-RGB;n:type:ShaderForge.SFN_Vector1,id:4882,x:30274,y:32315,varname:node_4882,prsc:2,v1:0;n:type:ShaderForge.SFN_Add,id:6363,x:30824,y:32235,varname:node_6363,prsc:2|A-1571-OUT,B-4801-OUT;n:type:ShaderForge.SFN_Add,id:6979,x:31047,y:32397,varname:node_6979,prsc:2|A-6363-OUT,B-9151-OUT;n:type:ShaderForge.SFN_Lerp,id:3489,x:31593,y:32558,varname:node_3489,prsc:2|A-7736-RGB,B-7566-OUT,T-4913-OUT;n:type:ShaderForge.SFN_Add,id:4625,x:30884,y:32551,varname:node_4625,prsc:2|A-3352-R,B-3352-G;n:type:ShaderForge.SFN_Add,id:8683,x:30884,y:32669,varname:node_8683,prsc:2|A-4625-OUT,B-3352-B;n:type:ShaderForge.SFN_Tex2d,id:4978,x:29921,y:33170,ptovrint:False,ptlb:Masks 2,ptin:_Masks2,varname:node_4978,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:b124635f4a5d1484fb7c919c7189f72b,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Color,id:3377,x:29921,y:32988,ptovrint:False,ptlb:Coat Color,ptin:_CoatColor,varname:_PantsColor_copy,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0,c2:0.9803922,c3:0.9803922,c4:1;n:type:ShaderForge.SFN_Color,id:5731,x:29921,y:33372,ptovrint:False,ptlb:Fur Color,ptin:_FurColor,varname:_PantsColor_copy_copy,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0.9862069,c2:1,c3:0,c4:1;n:type:ShaderForge.SFN_Multiply,id:8068,x:30295,y:32890,varname:node_8068,prsc:2|A-7736-RGB,B-3377-RGB;n:type:ShaderForge.SFN_Multiply,id:8416,x:30282,y:33352,varname:node_8416,prsc:2|A-7736-RGB,B-5731-RGB;n:type:ShaderForge.SFN_Lerp,id:109,x:30613,y:32926,varname:node_109,prsc:2|A-4882-OUT,B-8068-OUT,T-4978-B;n:type:ShaderForge.SFN_Lerp,id:2213,x:30611,y:33201,varname:node_2213,prsc:2|A-4882-OUT,B-8416-OUT,T-4978-G;n:type:ShaderForge.SFN_Add,id:7932,x:30855,y:33008,varname:node_7932,prsc:2|A-109-OUT,B-2213-OUT;n:type:ShaderForge.SFN_Add,id:7566,x:31357,y:32715,varname:node_7566,prsc:2|A-6979-OUT,B-550-OUT;n:type:ShaderForge.SFN_Add,id:4913,x:30884,y:32795,varname:node_4913,prsc:2|A-8683-OUT,B-1600-OUT;n:type:ShaderForge.SFN_Add,id:3057,x:30242,y:33153,varname:node_3057,prsc:2|A-4978-G,B-4978-B;n:type:ShaderForge.SFN_Hue,id:1436,x:29418,y:33591,varname:node_1436,prsc:2|IN-9269-OUT;n:type:ShaderForge.SFN_Subtract,id:9589,x:29598,y:33591,varname:node_9589,prsc:2|A-1436-OUT,B-4055-OUT;n:type:ShaderForge.SFN_Vector1,id:4055,x:29403,y:33756,varname:node_4055,prsc:2,v1:0.2;n:type:ShaderForge.SFN_Desaturate,id:4821,x:29775,y:33591,varname:node_4821,prsc:2|COL-9589-OUT,DES-9596-OUT;n:type:ShaderForge.SFN_Vector1,id:9596,x:29588,y:33756,varname:node_9596,prsc:2,v1:0.5;n:type:ShaderForge.SFN_Multiply,id:5819,x:30282,y:33554,varname:node_5819,prsc:2|A-7736-RGB,B-421-OUT;n:type:ShaderForge.SFN_Lerp,id:6569,x:30611,y:33408,varname:node_6569,prsc:2|A-4882-OUT,B-5819-OUT,T-4978-R;n:type:ShaderForge.SFN_Add,id:1600,x:30401,y:33061,varname:node_1600,prsc:2|A-4978-R,B-3057-OUT;n:type:ShaderForge.SFN_Vector1,id:304,x:31502,y:32894,varname:node_304,prsc:2,v1:0.741;n:type:ShaderForge.SFN_Slider,id:9269,x:29056,y:33816,ptovrint:False,ptlb:Skin Tone,ptin:_SkinTone,varname:node_9269,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0.04,cur:0.04,max:0.15;n:type:ShaderForge.SFN_Add,id:550,x:31058,y:33029,varname:node_550,prsc:2|A-7932-OUT,B-6569-OUT;n:type:ShaderForge.SFN_Add,id:1755,x:29950,y:33591,varname:node_1755,prsc:2|A-4821-OUT,B-8099-OUT;n:type:ShaderForge.SFN_Vector1,id:8099,x:29775,y:33756,varname:node_8099,prsc:2,v1:0.4;n:type:ShaderForge.SFN_Multiply,id:421,x:30140,y:33741,varname:node_421,prsc:2|A-1755-OUT,B-1715-OUT;n:type:ShaderForge.SFN_Slider,id:1715,x:29707,y:33927,ptovrint:False,ptlb:Skin Brightness,ptin:_SkinBrightness,varname:node_1715,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0.2,cur:0.5,max:1;n:type:ShaderForge.SFN_Fresnel,id:4352,x:31994,y:33595,varname:node_4352,prsc:2|EXP-2618-OUT;n:type:ShaderForge.SFN_ValueProperty,id:2618,x:31967,y:33774,ptovrint:False,ptlb:Fresnel Exponent,ptin:_FresnelExponent,varname:node_7540,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:4;n:type:ShaderForge.SFN_Multiply,id:4979,x:32464,y:33254,varname:node_4979,prsc:2|A-5410-OUT,B-2118-RGB;n:type:ShaderForge.SFN_Color,id:2118,x:32447,y:33437,ptovrint:False,ptlb:Fresnel Color,ptin:_FresnelColor,varname:node_7717,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:1,c2:0,c3:0,c4:1;n:type:ShaderForge.SFN_Multiply,id:5410,x:32115,y:33379,varname:node_5410,prsc:2|A-9057-OUT,B-4352-OUT;n:type:ShaderForge.SFN_Time,id:5393,x:30981,y:33325,varname:node_5393,prsc:2;n:type:ShaderForge.SFN_Sin,id:6089,x:31354,y:33379,varname:node_6089,prsc:2|IN-2640-OUT;n:type:ShaderForge.SFN_Multiply,id:2640,x:31178,y:33379,varname:node_2640,prsc:2|A-5393-T,B-2494-OUT;n:type:ShaderForge.SFN_ValueProperty,id:2494,x:30957,y:33500,ptovrint:False,ptlb:Pulsing Speed,ptin:_PulsingSpeed,varname:node_1592,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:5;n:type:ShaderForge.SFN_Add,id:8868,x:31556,y:33405,varname:node_8868,prsc:2|A-6089-OUT,B-4102-OUT;n:type:ShaderForge.SFN_Vector1,id:4102,x:31558,y:33576,varname:node_4102,prsc:2,v1:1;n:type:ShaderForge.SFN_Multiply,id:9057,x:31756,y:33405,varname:node_9057,prsc:2|A-8868-OUT,B-3535-OUT;n:type:ShaderForge.SFN_Vector1,id:3535,x:31772,y:33569,varname:node_3535,prsc:2,v1:0.5;n:type:ShaderForge.SFN_Vector1,id:7778,x:32508,y:33046,varname:node_7778,prsc:2,v1:0;n:type:ShaderForge.SFN_Lerp,id:2256,x:32729,y:33063,varname:node_2256,prsc:2|A-7778-OUT,B-4979-OUT,T-2790-OUT;n:type:ShaderForge.SFN_ValueProperty,id:2790,x:32751,y:33259,ptovrint:False,ptlb:Enable,ptin:_Enable,varname:node_2790,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:0;proporder:7736-2509-6920-5964-3352-6665-7726-9967-4978-3377-5731-9269-1715-2618-2118-2494-2790;pass:END;sub:END;*/

Shader "Shader Forge/MainSailor" {
    Properties {
        _MainTex ("Base Color", 2D) = "white" {}
        _Metallic ("Metallic", 2D) = "white" {}
        _Roughness ("Roughness", 2D) = "white" {}
        _BumpMap ("Normal Map", 2D) = "bump" {}
        _Masks ("Masks", 2D) = "white" {}
        _ShirtColor ("Shirt Color", Color) = (0,1,0.006896496,1)
        _ScarfColor ("Scarf Color", Color) = (0.9926471,0.058391,0.058391,1)
        _PantsColor ("Pants Color", Color) = (0.1999998,0,1,1)
        _Masks2 ("Masks 2", 2D) = "white" {}
        _CoatColor ("Coat Color", Color) = (0,0.9803922,0.9803922,1)
        _FurColor ("Fur Color", Color) = (0.9862069,1,0,1)
        _SkinTone ("Skin Tone", Range(0.04, 0.15)) = 0.04
        _SkinBrightness ("Skin Brightness", Range(0.2, 1)) = 0.5
        _FresnelExponent ("Fresnel Exponent", Float ) = 4
        _FresnelColor ("Fresnel Color", Color) = (1,0,0,1)
        _PulsingSpeed ("Pulsing Speed", Float ) = 5
        _Enable ("Enable", Float ) = 0
    }
    SubShader {
        Tags {
            "RenderType"="Opaque"
        }
        Pass {
            Name "DEFERRED"
            Tags {
                "LightMode"="Deferred"
            }
            
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_DEFERRED
            #define SHOULD_SAMPLE_SH ( defined (LIGHTMAP_OFF) && defined(DYNAMICLIGHTMAP_OFF) )
            #define _GLOSSYENV 1
            #include "UnityCG.cginc"
            #include "Lighting.cginc"
            #include "UnityPBSLighting.cginc"
            #include "UnityStandardBRDF.cginc"
            #pragma fragmentoption ARB_precision_hint_fastest
            #pragma multi_compile_shadowcaster
            #pragma multi_compile ___ UNITY_HDR_ON
            #pragma multi_compile LIGHTMAP_OFF LIGHTMAP_ON
            #pragma multi_compile DIRLIGHTMAP_OFF DIRLIGHTMAP_COMBINED DIRLIGHTMAP_SEPARATE
            #pragma multi_compile DYNAMICLIGHTMAP_OFF DYNAMICLIGHTMAP_ON
            #pragma multi_compile_fog
            #pragma exclude_renderers gles3 metal d3d11_9x xbox360 xboxone ps3 ps4 psp2 
            #pragma target 3.0
            uniform float4 _TimeEditor;
            uniform float4 _ShirtColor;
            uniform sampler2D _MainTex; uniform float4 _MainTex_ST;
            uniform sampler2D _BumpMap; uniform float4 _BumpMap_ST;
            uniform sampler2D _Metallic; uniform float4 _Metallic_ST;
            uniform sampler2D _Roughness; uniform float4 _Roughness_ST;
            uniform sampler2D _Masks; uniform float4 _Masks_ST;
            uniform float4 _ScarfColor;
            uniform float4 _PantsColor;
            uniform sampler2D _Masks2; uniform float4 _Masks2_ST;
            uniform float4 _CoatColor;
            uniform float4 _FurColor;
            uniform float _SkinTone;
            uniform float _SkinBrightness;
            uniform float _FresnelExponent;
            uniform float4 _FresnelColor;
            uniform float _PulsingSpeed;
            uniform float _Enable;
            struct VertexInput {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
                float4 tangent : TANGENT;
                float2 texcoord0 : TEXCOORD0;
                float2 texcoord1 : TEXCOORD1;
                float2 texcoord2 : TEXCOORD2;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float2 uv0 : TEXCOORD0;
                float2 uv1 : TEXCOORD1;
                float2 uv2 : TEXCOORD2;
                float4 posWorld : TEXCOORD3;
                float3 normalDir : TEXCOORD4;
                float3 tangentDir : TEXCOORD5;
                float3 bitangentDir : TEXCOORD6;
                #if defined(LIGHTMAP_ON) || defined(UNITY_SHOULD_SAMPLE_SH)
                    float4 ambientOrLightmapUV : TEXCOORD7;
                #endif
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.uv1 = v.texcoord1;
                o.uv2 = v.texcoord2;
                #ifdef LIGHTMAP_ON
                    o.ambientOrLightmapUV.xy = v.texcoord1.xy * unity_LightmapST.xy + unity_LightmapST.zw;
                    o.ambientOrLightmapUV.zw = 0;
                #elif UNITY_SHOULD_SAMPLE_SH
                #endif
                #ifdef DYNAMICLIGHTMAP_ON
                    o.ambientOrLightmapUV.zw = v.texcoord2.xy * unity_DynamicLightmapST.xy + unity_DynamicLightmapST.zw;
                #endif
                o.normalDir = UnityObjectToWorldNormal(v.normal);
                o.tangentDir = normalize( mul( _Object2World, float4( v.tangent.xyz, 0.0 ) ).xyz );
                o.bitangentDir = normalize(cross(o.normalDir, o.tangentDir) * v.tangent.w);
                o.posWorld = mul(_Object2World, v.vertex);
                o.pos = mul(UNITY_MATRIX_MVP, v.vertex );
                return o;
            }
            void frag(
                VertexOutput i,
                out half4 outDiffuse : SV_Target0,
                out half4 outSpecSmoothness : SV_Target1,
                out half4 outNormal : SV_Target2,
                out half4 outEmission : SV_Target3 )
            {
                i.normalDir = normalize(i.normalDir);
                float3x3 tangentTransform = float3x3( i.tangentDir, i.bitangentDir, i.normalDir);
/////// Vectors:
                float3 viewDirection = normalize(_WorldSpaceCameraPos.xyz - i.posWorld.xyz);
                float3 _BumpMap_var = UnpackNormal(tex2D(_BumpMap,TRANSFORM_TEX(i.uv0, _BumpMap)));
                float3 normalLocal = _BumpMap_var.rgb;
                float3 normalDirection = normalize(mul( normalLocal, tangentTransform )); // Perturbed normals
                float3 viewReflectDirection = reflect( -viewDirection, normalDirection );
////// Lighting:
                float Pi = 3.141592654;
                float InvPi = 0.31830988618;
///////// Gloss:
                float4 _Roughness_var = tex2D(_Roughness,TRANSFORM_TEX(i.uv0, _Roughness));
                float gloss = 1.0 - ((1.0 - 0.741)+_Roughness_var.r); // Convert roughness to gloss
/////// GI Data:
                UnityLight light; // Dummy light
                light.color = 0;
                light.dir = half3(0,1,0);
                light.ndotl = max(0,dot(normalDirection,light.dir));
                UnityGIInput d;
                d.light = light;
                d.worldPos = i.posWorld.xyz;
                d.worldViewDir = viewDirection;
                d.atten = 1;
                #if defined(LIGHTMAP_ON) || defined(DYNAMICLIGHTMAP_ON)
                    d.ambient = 0;
                    d.lightmapUV = i.ambientOrLightmapUV;
                #else
                    d.ambient = i.ambientOrLightmapUV;
                #endif
                d.boxMax[0] = unity_SpecCube0_BoxMax;
                d.boxMin[0] = unity_SpecCube0_BoxMin;
                d.probePosition[0] = unity_SpecCube0_ProbePosition;
                d.probeHDR[0] = unity_SpecCube0_HDR;
                d.boxMax[1] = unity_SpecCube1_BoxMax;
                d.boxMin[1] = unity_SpecCube1_BoxMin;
                d.probePosition[1] = unity_SpecCube1_ProbePosition;
                d.probeHDR[1] = unity_SpecCube1_HDR;
                UnityGI gi = UnityGlobalIllumination (d, 1, gloss, normalDirection);
////// Specular:
                float4 _MainTex_var = tex2D(_MainTex,TRANSFORM_TEX(i.uv0, _MainTex));
                float node_4882 = 0.0;
                float4 _Masks_var = tex2D(_Masks,TRANSFORM_TEX(i.uv0, _Masks));
                float4 _Masks2_var = tex2D(_Masks2,TRANSFORM_TEX(i.uv0, _Masks2));
                float3 diffuseColor = lerp(_MainTex_var.rgb,(((lerp(float3(node_4882,node_4882,node_4882),(_ScarfColor.rgb*_MainTex_var.rgb),_Masks_var.r)+lerp(float3(node_4882,node_4882,node_4882),(_MainTex_var.rgb*_ShirtColor.rgb),_Masks_var.g))+lerp(float3(node_4882,node_4882,node_4882),(_MainTex_var.rgb*_PantsColor.rgb),_Masks_var.b))+((lerp(float3(node_4882,node_4882,node_4882),(_MainTex_var.rgb*_CoatColor.rgb),_Masks2_var.b)+lerp(float3(node_4882,node_4882,node_4882),(_MainTex_var.rgb*_FurColor.rgb),_Masks2_var.g))+lerp(float3(node_4882,node_4882,node_4882),(_MainTex_var.rgb*((lerp((saturate(3.0*abs(1.0-2.0*frac(_SkinTone+float3(0.0,-1.0/3.0,1.0/3.0)))-1)-0.2),dot((saturate(3.0*abs(1.0-2.0*frac(_SkinTone+float3(0.0,-1.0/3.0,1.0/3.0)))-1)-0.2),float3(0.3,0.59,0.11)),0.5)+0.4)*_SkinBrightness)),_Masks2_var.r))),(((_Masks_var.r+_Masks_var.g)+_Masks_var.b)+(_Masks2_var.r+(_Masks2_var.g+_Masks2_var.b)))); // Need this for specular when using metallic
                float specularMonochrome;
                float3 specularColor;
                float4 _Metallic_var = tex2D(_Metallic,TRANSFORM_TEX(i.uv0, _Metallic));
                diffuseColor = DiffuseAndSpecularFromMetallic( diffuseColor, _Metallic_var.r, specularColor, specularMonochrome );
                specularMonochrome = 1-specularMonochrome;
                float NdotV = max(0.0,dot( normalDirection, viewDirection ));
                half grazingTerm = saturate( gloss + specularMonochrome );
                float3 indirectSpecular = (gi.indirect.specular);
                indirectSpecular *= FresnelLerp (specularColor, grazingTerm, NdotV);
/////// Diffuse:
                float3 indirectDiffuse = float3(0,0,0);
                indirectDiffuse += gi.indirect.diffuse;
////// Emissive:
                float node_7778 = 0.0;
                float4 node_5393 = _Time + _TimeEditor;
                float3 node_4979 = ((((sin((node_5393.g*_PulsingSpeed))+1.0)*0.5)*pow(1.0-max(0,dot(normalDirection, viewDirection)),_FresnelExponent))*_FresnelColor.rgb);
                float3 emissive = lerp(float3(node_7778,node_7778,node_7778),node_4979,_Enable);
/// Final Color:
                outDiffuse = half4( diffuseColor, 1 );
                outSpecSmoothness = half4( specularColor, gloss );
                outNormal = half4( normalDirection * 0.5 + 0.5, 1 );
                outEmission = half4( lerp(float3(node_7778,node_7778,node_7778),node_4979,_Enable), 1 );
                outEmission.rgb += indirectSpecular * 1;
                outEmission.rgb += indirectDiffuse * diffuseColor;
                #ifndef UNITY_HDR_ON
                    outEmission.rgb = exp2(-outEmission.rgb);
                #endif
            }
            ENDCG
        }
        Pass {
            Name "FORWARD"
            Tags {
                "LightMode"="ForwardBase"
            }
            
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_FORWARDBASE
            #define SHOULD_SAMPLE_SH ( defined (LIGHTMAP_OFF) && defined(DYNAMICLIGHTMAP_OFF) )
            #define _GLOSSYENV 1
            #include "UnityCG.cginc"
            #include "AutoLight.cginc"
            #include "Lighting.cginc"
            #include "UnityPBSLighting.cginc"
            #include "UnityStandardBRDF.cginc"
            #pragma multi_compile_fwdbase_fullshadows
            #pragma multi_compile LIGHTMAP_OFF LIGHTMAP_ON
            #pragma multi_compile DIRLIGHTMAP_OFF DIRLIGHTMAP_COMBINED DIRLIGHTMAP_SEPARATE
            #pragma multi_compile DYNAMICLIGHTMAP_OFF DYNAMICLIGHTMAP_ON
            #pragma multi_compile_fog
            #pragma exclude_renderers gles3 metal d3d11_9x xbox360 xboxone ps3 ps4 psp2 
            #pragma target 3.0
            uniform float4 _TimeEditor;
            uniform float4 _ShirtColor;
            uniform sampler2D _MainTex; uniform float4 _MainTex_ST;
            uniform sampler2D _BumpMap; uniform float4 _BumpMap_ST;
            uniform sampler2D _Metallic; uniform float4 _Metallic_ST;
            uniform sampler2D _Roughness; uniform float4 _Roughness_ST;
            uniform sampler2D _Masks; uniform float4 _Masks_ST;
            uniform float4 _ScarfColor;
            uniform float4 _PantsColor;
            uniform sampler2D _Masks2; uniform float4 _Masks2_ST;
            uniform float4 _CoatColor;
            uniform float4 _FurColor;
            uniform float _SkinTone;
            uniform float _SkinBrightness;
            uniform float _FresnelExponent;
            uniform float4 _FresnelColor;
            uniform float _PulsingSpeed;
            uniform float _Enable;
            struct VertexInput {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
                float4 tangent : TANGENT;
                float2 texcoord0 : TEXCOORD0;
                float2 texcoord1 : TEXCOORD1;
                float2 texcoord2 : TEXCOORD2;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float2 uv0 : TEXCOORD0;
                float2 uv1 : TEXCOORD1;
                float2 uv2 : TEXCOORD2;
                float4 posWorld : TEXCOORD3;
                float3 normalDir : TEXCOORD4;
                float3 tangentDir : TEXCOORD5;
                float3 bitangentDir : TEXCOORD6;
                LIGHTING_COORDS(7,8)
                UNITY_FOG_COORDS(9)
                #if defined(LIGHTMAP_ON) || defined(UNITY_SHOULD_SAMPLE_SH)
                    float4 ambientOrLightmapUV : TEXCOORD10;
                #endif
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.uv1 = v.texcoord1;
                o.uv2 = v.texcoord2;
                #ifdef LIGHTMAP_ON
                    o.ambientOrLightmapUV.xy = v.texcoord1.xy * unity_LightmapST.xy + unity_LightmapST.zw;
                    o.ambientOrLightmapUV.zw = 0;
                #elif UNITY_SHOULD_SAMPLE_SH
                #endif
                #ifdef DYNAMICLIGHTMAP_ON
                    o.ambientOrLightmapUV.zw = v.texcoord2.xy * unity_DynamicLightmapST.xy + unity_DynamicLightmapST.zw;
                #endif
                o.normalDir = UnityObjectToWorldNormal(v.normal);
                o.tangentDir = normalize( mul( _Object2World, float4( v.tangent.xyz, 0.0 ) ).xyz );
                o.bitangentDir = normalize(cross(o.normalDir, o.tangentDir) * v.tangent.w);
                o.posWorld = mul(_Object2World, v.vertex);
                float3 lightColor = _LightColor0.rgb;
                o.pos = mul(UNITY_MATRIX_MVP, v.vertex );
                UNITY_TRANSFER_FOG(o,o.pos);
                TRANSFER_VERTEX_TO_FRAGMENT(o)
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
                i.normalDir = normalize(i.normalDir);
                float3x3 tangentTransform = float3x3( i.tangentDir, i.bitangentDir, i.normalDir);
/////// Vectors:
                float3 viewDirection = normalize(_WorldSpaceCameraPos.xyz - i.posWorld.xyz);
                float3 _BumpMap_var = UnpackNormal(tex2D(_BumpMap,TRANSFORM_TEX(i.uv0, _BumpMap)));
                float3 normalLocal = _BumpMap_var.rgb;
                float3 normalDirection = normalize(mul( normalLocal, tangentTransform )); // Perturbed normals
                float3 viewReflectDirection = reflect( -viewDirection, normalDirection );
                float3 lightDirection = normalize(_WorldSpaceLightPos0.xyz);
                float3 lightColor = _LightColor0.rgb;
                float3 halfDirection = normalize(viewDirection+lightDirection);
////// Lighting:
                float attenuation = LIGHT_ATTENUATION(i);
                float3 attenColor = attenuation * _LightColor0.xyz;
                float Pi = 3.141592654;
                float InvPi = 0.31830988618;
///////// Gloss:
                float4 _Roughness_var = tex2D(_Roughness,TRANSFORM_TEX(i.uv0, _Roughness));
                float gloss = 1.0 - ((1.0 - 0.741)+_Roughness_var.r); // Convert roughness to gloss
                float specPow = exp2( gloss * 10.0+1.0);
/////// GI Data:
                UnityLight light;
                #ifdef LIGHTMAP_OFF
                    light.color = lightColor;
                    light.dir = lightDirection;
                    light.ndotl = LambertTerm (normalDirection, light.dir);
                #else
                    light.color = half3(0.f, 0.f, 0.f);
                    light.ndotl = 0.0f;
                    light.dir = half3(0.f, 0.f, 0.f);
                #endif
                UnityGIInput d;
                d.light = light;
                d.worldPos = i.posWorld.xyz;
                d.worldViewDir = viewDirection;
                d.atten = attenuation;
                #if defined(LIGHTMAP_ON) || defined(DYNAMICLIGHTMAP_ON)
                    d.ambient = 0;
                    d.lightmapUV = i.ambientOrLightmapUV;
                #else
                    d.ambient = i.ambientOrLightmapUV;
                #endif
                d.boxMax[0] = unity_SpecCube0_BoxMax;
                d.boxMin[0] = unity_SpecCube0_BoxMin;
                d.probePosition[0] = unity_SpecCube0_ProbePosition;
                d.probeHDR[0] = unity_SpecCube0_HDR;
                d.boxMax[1] = unity_SpecCube1_BoxMax;
                d.boxMin[1] = unity_SpecCube1_BoxMin;
                d.probePosition[1] = unity_SpecCube1_ProbePosition;
                d.probeHDR[1] = unity_SpecCube1_HDR;
                UnityGI gi = UnityGlobalIllumination (d, 1, gloss, normalDirection);
                lightDirection = gi.light.dir;
                lightColor = gi.light.color;
////// Specular:
                float NdotL = max(0, dot( normalDirection, lightDirection ));
                float LdotH = max(0.0,dot(lightDirection, halfDirection));
                float4 _MainTex_var = tex2D(_MainTex,TRANSFORM_TEX(i.uv0, _MainTex));
                float node_4882 = 0.0;
                float4 _Masks_var = tex2D(_Masks,TRANSFORM_TEX(i.uv0, _Masks));
                float4 _Masks2_var = tex2D(_Masks2,TRANSFORM_TEX(i.uv0, _Masks2));
                float3 diffuseColor = lerp(_MainTex_var.rgb,(((lerp(float3(node_4882,node_4882,node_4882),(_ScarfColor.rgb*_MainTex_var.rgb),_Masks_var.r)+lerp(float3(node_4882,node_4882,node_4882),(_MainTex_var.rgb*_ShirtColor.rgb),_Masks_var.g))+lerp(float3(node_4882,node_4882,node_4882),(_MainTex_var.rgb*_PantsColor.rgb),_Masks_var.b))+((lerp(float3(node_4882,node_4882,node_4882),(_MainTex_var.rgb*_CoatColor.rgb),_Masks2_var.b)+lerp(float3(node_4882,node_4882,node_4882),(_MainTex_var.rgb*_FurColor.rgb),_Masks2_var.g))+lerp(float3(node_4882,node_4882,node_4882),(_MainTex_var.rgb*((lerp((saturate(3.0*abs(1.0-2.0*frac(_SkinTone+float3(0.0,-1.0/3.0,1.0/3.0)))-1)-0.2),dot((saturate(3.0*abs(1.0-2.0*frac(_SkinTone+float3(0.0,-1.0/3.0,1.0/3.0)))-1)-0.2),float3(0.3,0.59,0.11)),0.5)+0.4)*_SkinBrightness)),_Masks2_var.r))),(((_Masks_var.r+_Masks_var.g)+_Masks_var.b)+(_Masks2_var.r+(_Masks2_var.g+_Masks2_var.b)))); // Need this for specular when using metallic
                float specularMonochrome;
                float3 specularColor;
                float4 _Metallic_var = tex2D(_Metallic,TRANSFORM_TEX(i.uv0, _Metallic));
                diffuseColor = DiffuseAndSpecularFromMetallic( diffuseColor, _Metallic_var.r, specularColor, specularMonochrome );
                specularMonochrome = 1-specularMonochrome;
                float NdotV = max(0.0,dot( normalDirection, viewDirection ));
                float NdotH = max(0.0,dot( normalDirection, halfDirection ));
                float VdotH = max(0.0,dot( viewDirection, halfDirection ));
                float visTerm = SmithBeckmannVisibilityTerm( NdotL, NdotV, 1.0-gloss );
                float normTerm = max(0.0, NDFBlinnPhongNormalizedTerm(NdotH, RoughnessToSpecPower(1.0-gloss)));
                float specularPBL = max(0, (NdotL*visTerm*normTerm) * unity_LightGammaCorrectionConsts_PIDiv4 );
                float3 directSpecular = 1 * pow(max(0,dot(halfDirection,normalDirection)),specPow)*specularPBL*lightColor*FresnelTerm(specularColor, LdotH);
                half grazingTerm = saturate( gloss + specularMonochrome );
                float3 indirectSpecular = (gi.indirect.specular);
                indirectSpecular *= FresnelLerp (specularColor, grazingTerm, NdotV);
                float3 specular = (directSpecular + indirectSpecular);
/////// Diffuse:
                NdotL = max(0.0,dot( normalDirection, lightDirection ));
                half fd90 = 0.5 + 2 * LdotH * LdotH * (1-gloss);
                float3 directDiffuse = ((1 +(fd90 - 1)*pow((1.00001-NdotL), 5)) * (1 + (fd90 - 1)*pow((1.00001-NdotV), 5)) * NdotL) * attenColor;
                float3 indirectDiffuse = float3(0,0,0);
                indirectDiffuse += gi.indirect.diffuse;
                float3 diffuse = (directDiffuse + indirectDiffuse) * diffuseColor;
////// Emissive:
                float node_7778 = 0.0;
                float4 node_5393 = _Time + _TimeEditor;
                float3 node_4979 = ((((sin((node_5393.g*_PulsingSpeed))+1.0)*0.5)*pow(1.0-max(0,dot(normalDirection, viewDirection)),_FresnelExponent))*_FresnelColor.rgb);
                float3 emissive = lerp(float3(node_7778,node_7778,node_7778),node_4979,_Enable);
/// Final Color:
                float3 finalColor = diffuse + specular + emissive;
                fixed4 finalRGBA = fixed4(finalColor,1);
                UNITY_APPLY_FOG(i.fogCoord, finalRGBA);
                return finalRGBA;
            }
            ENDCG
        }
        Pass {
            Name "FORWARD_DELTA"
            Tags {
                "LightMode"="ForwardAdd"
            }
            Blend One One
            
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_FORWARDADD
            #define SHOULD_SAMPLE_SH ( defined (LIGHTMAP_OFF) && defined(DYNAMICLIGHTMAP_OFF) )
            #define _GLOSSYENV 1
            #include "UnityCG.cginc"
            #include "AutoLight.cginc"
            #include "Lighting.cginc"
            #include "UnityPBSLighting.cginc"
            #include "UnityStandardBRDF.cginc"
            #pragma multi_compile_fwdadd_fullshadows
            #pragma multi_compile LIGHTMAP_OFF LIGHTMAP_ON
            #pragma multi_compile DIRLIGHTMAP_OFF DIRLIGHTMAP_COMBINED DIRLIGHTMAP_SEPARATE
            #pragma multi_compile DYNAMICLIGHTMAP_OFF DYNAMICLIGHTMAP_ON
            #pragma multi_compile_fog
            #pragma exclude_renderers gles3 metal d3d11_9x xbox360 xboxone ps3 ps4 psp2 
            #pragma target 3.0
            uniform float4 _TimeEditor;
            uniform float4 _ShirtColor;
            uniform sampler2D _MainTex; uniform float4 _MainTex_ST;
            uniform sampler2D _BumpMap; uniform float4 _BumpMap_ST;
            uniform sampler2D _Metallic; uniform float4 _Metallic_ST;
            uniform sampler2D _Roughness; uniform float4 _Roughness_ST;
            uniform sampler2D _Masks; uniform float4 _Masks_ST;
            uniform float4 _ScarfColor;
            uniform float4 _PantsColor;
            uniform sampler2D _Masks2; uniform float4 _Masks2_ST;
            uniform float4 _CoatColor;
            uniform float4 _FurColor;
            uniform float _SkinTone;
            uniform float _SkinBrightness;
            uniform float _FresnelExponent;
            uniform float4 _FresnelColor;
            uniform float _PulsingSpeed;
            uniform float _Enable;
            struct VertexInput {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
                float4 tangent : TANGENT;
                float2 texcoord0 : TEXCOORD0;
                float2 texcoord1 : TEXCOORD1;
                float2 texcoord2 : TEXCOORD2;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float2 uv0 : TEXCOORD0;
                float2 uv1 : TEXCOORD1;
                float2 uv2 : TEXCOORD2;
                float4 posWorld : TEXCOORD3;
                float3 normalDir : TEXCOORD4;
                float3 tangentDir : TEXCOORD5;
                float3 bitangentDir : TEXCOORD6;
                LIGHTING_COORDS(7,8)
                UNITY_FOG_COORDS(9)
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.uv1 = v.texcoord1;
                o.uv2 = v.texcoord2;
                o.normalDir = UnityObjectToWorldNormal(v.normal);
                o.tangentDir = normalize( mul( _Object2World, float4( v.tangent.xyz, 0.0 ) ).xyz );
                o.bitangentDir = normalize(cross(o.normalDir, o.tangentDir) * v.tangent.w);
                o.posWorld = mul(_Object2World, v.vertex);
                float3 lightColor = _LightColor0.rgb;
                o.pos = mul(UNITY_MATRIX_MVP, v.vertex );
                UNITY_TRANSFER_FOG(o,o.pos);
                TRANSFER_VERTEX_TO_FRAGMENT(o)
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
                i.normalDir = normalize(i.normalDir);
                float3x3 tangentTransform = float3x3( i.tangentDir, i.bitangentDir, i.normalDir);
/////// Vectors:
                float3 viewDirection = normalize(_WorldSpaceCameraPos.xyz - i.posWorld.xyz);
                float3 _BumpMap_var = UnpackNormal(tex2D(_BumpMap,TRANSFORM_TEX(i.uv0, _BumpMap)));
                float3 normalLocal = _BumpMap_var.rgb;
                float3 normalDirection = normalize(mul( normalLocal, tangentTransform )); // Perturbed normals
                float3 lightDirection = normalize(lerp(_WorldSpaceLightPos0.xyz, _WorldSpaceLightPos0.xyz - i.posWorld.xyz,_WorldSpaceLightPos0.w));
                float3 lightColor = _LightColor0.rgb;
                float3 halfDirection = normalize(viewDirection+lightDirection);
////// Lighting:
                float attenuation = LIGHT_ATTENUATION(i);
                float3 attenColor = attenuation * _LightColor0.xyz;
                float Pi = 3.141592654;
                float InvPi = 0.31830988618;
///////// Gloss:
                float4 _Roughness_var = tex2D(_Roughness,TRANSFORM_TEX(i.uv0, _Roughness));
                float gloss = 1.0 - ((1.0 - 0.741)+_Roughness_var.r); // Convert roughness to gloss
                float specPow = exp2( gloss * 10.0+1.0);
////// Specular:
                float NdotL = max(0, dot( normalDirection, lightDirection ));
                float LdotH = max(0.0,dot(lightDirection, halfDirection));
                float4 _MainTex_var = tex2D(_MainTex,TRANSFORM_TEX(i.uv0, _MainTex));
                float node_4882 = 0.0;
                float4 _Masks_var = tex2D(_Masks,TRANSFORM_TEX(i.uv0, _Masks));
                float4 _Masks2_var = tex2D(_Masks2,TRANSFORM_TEX(i.uv0, _Masks2));
                float3 diffuseColor = lerp(_MainTex_var.rgb,(((lerp(float3(node_4882,node_4882,node_4882),(_ScarfColor.rgb*_MainTex_var.rgb),_Masks_var.r)+lerp(float3(node_4882,node_4882,node_4882),(_MainTex_var.rgb*_ShirtColor.rgb),_Masks_var.g))+lerp(float3(node_4882,node_4882,node_4882),(_MainTex_var.rgb*_PantsColor.rgb),_Masks_var.b))+((lerp(float3(node_4882,node_4882,node_4882),(_MainTex_var.rgb*_CoatColor.rgb),_Masks2_var.b)+lerp(float3(node_4882,node_4882,node_4882),(_MainTex_var.rgb*_FurColor.rgb),_Masks2_var.g))+lerp(float3(node_4882,node_4882,node_4882),(_MainTex_var.rgb*((lerp((saturate(3.0*abs(1.0-2.0*frac(_SkinTone+float3(0.0,-1.0/3.0,1.0/3.0)))-1)-0.2),dot((saturate(3.0*abs(1.0-2.0*frac(_SkinTone+float3(0.0,-1.0/3.0,1.0/3.0)))-1)-0.2),float3(0.3,0.59,0.11)),0.5)+0.4)*_SkinBrightness)),_Masks2_var.r))),(((_Masks_var.r+_Masks_var.g)+_Masks_var.b)+(_Masks2_var.r+(_Masks2_var.g+_Masks2_var.b)))); // Need this for specular when using metallic
                float specularMonochrome;
                float3 specularColor;
                float4 _Metallic_var = tex2D(_Metallic,TRANSFORM_TEX(i.uv0, _Metallic));
                diffuseColor = DiffuseAndSpecularFromMetallic( diffuseColor, _Metallic_var.r, specularColor, specularMonochrome );
                specularMonochrome = 1-specularMonochrome;
                float NdotV = max(0.0,dot( normalDirection, viewDirection ));
                float NdotH = max(0.0,dot( normalDirection, halfDirection ));
                float VdotH = max(0.0,dot( viewDirection, halfDirection ));
                float visTerm = SmithBeckmannVisibilityTerm( NdotL, NdotV, 1.0-gloss );
                float normTerm = max(0.0, NDFBlinnPhongNormalizedTerm(NdotH, RoughnessToSpecPower(1.0-gloss)));
                float specularPBL = max(0, (NdotL*visTerm*normTerm) * unity_LightGammaCorrectionConsts_PIDiv4 );
                float3 directSpecular = attenColor * pow(max(0,dot(halfDirection,normalDirection)),specPow)*specularPBL*lightColor*FresnelTerm(specularColor, LdotH);
                float3 specular = directSpecular;
/////// Diffuse:
                NdotL = max(0.0,dot( normalDirection, lightDirection ));
                half fd90 = 0.5 + 2 * LdotH * LdotH * (1-gloss);
                float3 directDiffuse = ((1 +(fd90 - 1)*pow((1.00001-NdotL), 5)) * (1 + (fd90 - 1)*pow((1.00001-NdotV), 5)) * NdotL) * attenColor;
                float3 diffuse = directDiffuse * diffuseColor;
/// Final Color:
                float3 finalColor = diffuse + specular;
                fixed4 finalRGBA = fixed4(finalColor * 1,0);
                UNITY_APPLY_FOG(i.fogCoord, finalRGBA);
                return finalRGBA;
            }
            ENDCG
        }
        Pass {
            Name "Meta"
            Tags {
                "LightMode"="Meta"
            }
            Cull Off
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_META 1
            #define SHOULD_SAMPLE_SH ( defined (LIGHTMAP_OFF) && defined(DYNAMICLIGHTMAP_OFF) )
            #define _GLOSSYENV 1
            #include "UnityCG.cginc"
            #include "Lighting.cginc"
            #include "UnityPBSLighting.cginc"
            #include "UnityStandardBRDF.cginc"
            #include "UnityMetaPass.cginc"
            #pragma fragmentoption ARB_precision_hint_fastest
            #pragma multi_compile_shadowcaster
            #pragma multi_compile LIGHTMAP_OFF LIGHTMAP_ON
            #pragma multi_compile DIRLIGHTMAP_OFF DIRLIGHTMAP_COMBINED DIRLIGHTMAP_SEPARATE
            #pragma multi_compile DYNAMICLIGHTMAP_OFF DYNAMICLIGHTMAP_ON
            #pragma multi_compile_fog
            #pragma exclude_renderers gles3 metal d3d11_9x xbox360 xboxone ps3 ps4 psp2 
            #pragma target 3.0
            uniform float4 _TimeEditor;
            uniform float4 _ShirtColor;
            uniform sampler2D _MainTex; uniform float4 _MainTex_ST;
            uniform sampler2D _Metallic; uniform float4 _Metallic_ST;
            uniform sampler2D _Roughness; uniform float4 _Roughness_ST;
            uniform sampler2D _Masks; uniform float4 _Masks_ST;
            uniform float4 _ScarfColor;
            uniform float4 _PantsColor;
            uniform sampler2D _Masks2; uniform float4 _Masks2_ST;
            uniform float4 _CoatColor;
            uniform float4 _FurColor;
            uniform float _SkinTone;
            uniform float _SkinBrightness;
            uniform float _FresnelExponent;
            uniform float4 _FresnelColor;
            uniform float _PulsingSpeed;
            uniform float _Enable;
            struct VertexInput {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
                float2 texcoord0 : TEXCOORD0;
                float2 texcoord1 : TEXCOORD1;
                float2 texcoord2 : TEXCOORD2;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float2 uv0 : TEXCOORD0;
                float2 uv1 : TEXCOORD1;
                float2 uv2 : TEXCOORD2;
                float4 posWorld : TEXCOORD3;
                float3 normalDir : TEXCOORD4;
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.uv1 = v.texcoord1;
                o.uv2 = v.texcoord2;
                o.normalDir = UnityObjectToWorldNormal(v.normal);
                o.posWorld = mul(_Object2World, v.vertex);
                o.pos = UnityMetaVertexPosition(v.vertex, v.texcoord1.xy, v.texcoord2.xy, unity_LightmapST, unity_DynamicLightmapST );
                return o;
            }
            float4 frag(VertexOutput i) : SV_Target {
                i.normalDir = normalize(i.normalDir);
/////// Vectors:
                float3 viewDirection = normalize(_WorldSpaceCameraPos.xyz - i.posWorld.xyz);
                float3 normalDirection = i.normalDir;
                UnityMetaInput o;
                UNITY_INITIALIZE_OUTPUT( UnityMetaInput, o );
                
                float node_7778 = 0.0;
                float4 node_5393 = _Time + _TimeEditor;
                float3 node_4979 = ((((sin((node_5393.g*_PulsingSpeed))+1.0)*0.5)*pow(1.0-max(0,dot(normalDirection, viewDirection)),_FresnelExponent))*_FresnelColor.rgb);
                o.Emission = lerp(float3(node_7778,node_7778,node_7778),node_4979,_Enable);
                
                float4 _MainTex_var = tex2D(_MainTex,TRANSFORM_TEX(i.uv0, _MainTex));
                float node_4882 = 0.0;
                float4 _Masks_var = tex2D(_Masks,TRANSFORM_TEX(i.uv0, _Masks));
                float4 _Masks2_var = tex2D(_Masks2,TRANSFORM_TEX(i.uv0, _Masks2));
                float3 diffColor = lerp(_MainTex_var.rgb,(((lerp(float3(node_4882,node_4882,node_4882),(_ScarfColor.rgb*_MainTex_var.rgb),_Masks_var.r)+lerp(float3(node_4882,node_4882,node_4882),(_MainTex_var.rgb*_ShirtColor.rgb),_Masks_var.g))+lerp(float3(node_4882,node_4882,node_4882),(_MainTex_var.rgb*_PantsColor.rgb),_Masks_var.b))+((lerp(float3(node_4882,node_4882,node_4882),(_MainTex_var.rgb*_CoatColor.rgb),_Masks2_var.b)+lerp(float3(node_4882,node_4882,node_4882),(_MainTex_var.rgb*_FurColor.rgb),_Masks2_var.g))+lerp(float3(node_4882,node_4882,node_4882),(_MainTex_var.rgb*((lerp((saturate(3.0*abs(1.0-2.0*frac(_SkinTone+float3(0.0,-1.0/3.0,1.0/3.0)))-1)-0.2),dot((saturate(3.0*abs(1.0-2.0*frac(_SkinTone+float3(0.0,-1.0/3.0,1.0/3.0)))-1)-0.2),float3(0.3,0.59,0.11)),0.5)+0.4)*_SkinBrightness)),_Masks2_var.r))),(((_Masks_var.r+_Masks_var.g)+_Masks_var.b)+(_Masks2_var.r+(_Masks2_var.g+_Masks2_var.b))));
                float specularMonochrome;
                float3 specColor;
                float4 _Metallic_var = tex2D(_Metallic,TRANSFORM_TEX(i.uv0, _Metallic));
                diffColor = DiffuseAndSpecularFromMetallic( diffColor, _Metallic_var.r, specColor, specularMonochrome );
                float4 _Roughness_var = tex2D(_Roughness,TRANSFORM_TEX(i.uv0, _Roughness));
                float roughness = ((1.0 - 0.741)+_Roughness_var.r);
                o.Albedo = diffColor + specColor * roughness * roughness * 0.5;
                
                return UnityMetaFragment( o );
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
    CustomEditor "ShaderForgeMaterialInspector"
}
