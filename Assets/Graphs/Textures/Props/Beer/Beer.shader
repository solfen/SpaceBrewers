// Shader created with Shader Forge v1.19 
// Shader Forge (c) Neat Corporation / Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.19;sub:START;pass:START;ps:flbk:,iptp:0,cusa:False,bamd:0,lico:1,lgpr:1,limd:3,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:True,hqlp:False,rprd:True,enco:False,rmgx:True,rpth:0,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:0,bsrc:0,bdst:1,dpts:2,wrdp:True,dith:0,rfrpo:True,rfrpn:Refraction,coma:15,ufog:True,aust:True,igpj:False,qofs:0,qpre:1,rntp:1,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5,fgcg:0.5,fgcb:0.5,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False;n:type:ShaderForge.SFN_Final,id:2865,x:33652,y:32720,varname:node_2865,prsc:2|diff-5080-OUT,spec-358-OUT,gloss-1813-OUT,emission-4117-OUT;n:type:ShaderForge.SFN_Color,id:6665,x:31755,y:32384,ptovrint:False,ptlb:Color1,ptin:_Color1,varname:_Color,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0.9921569,c2:0.8039216,c3:0.003921569,c4:1;n:type:ShaderForge.SFN_Tex2d,id:7736,x:31899,y:32821,ptovrint:True,ptlb:Blur Mask,ptin:_MainTex,varname:_MainTex,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:1890057c282c74a4f89d1585bd849490,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Slider,id:358,x:32893,y:32938,ptovrint:False,ptlb:Metallic,ptin:_Metallic,varname:node_358,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0,max:1;n:type:ShaderForge.SFN_Slider,id:1813,x:32893,y:33040,ptovrint:False,ptlb:Gloss,ptin:_Gloss,varname:_Metallic_copy,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0.8,max:1;n:type:ShaderForge.SFN_Lerp,id:9881,x:32360,y:32580,varname:node_9881,prsc:2|A-2814-RGB,B-6665-RGB,T-7736-RGB;n:type:ShaderForge.SFN_Color,id:2814,x:31755,y:32572,ptovrint:False,ptlb:Color2,ptin:_Color2,varname:_Color_copy,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0.7607844,c2:0.3137255,c3:0,c4:1;n:type:ShaderForge.SFN_TexCoord,id:2639,x:30161,y:32615,varname:node_2639,prsc:2,uv:0;n:type:ShaderForge.SFN_OneMinus,id:4329,x:30336,y:32659,varname:node_4329,prsc:2|IN-2639-V;n:type:ShaderForge.SFN_Multiply,id:9884,x:33113,y:32610,varname:node_9884,prsc:2|A-5282-OUT,B-5080-OUT;n:type:ShaderForge.SFN_ValueProperty,id:5282,x:32839,y:32581,ptovrint:False,ptlb:Emissive,ptin:_Emissive,varname:node_5282,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:1;n:type:ShaderForge.SFN_Multiply,id:4117,x:33326,y:32747,varname:node_4117,prsc:2|A-9884-OUT,B-2929-OUT;n:type:ShaderForge.SFN_Tex2d,id:6758,x:32075,y:32138,varname:node_6758,prsc:2,tex:df5f991d641acba42be0d90d3b2c89ad,ntxv:0,isnm:False|UVIN-8306-OUT,TEX-6791-TEX;n:type:ShaderForge.SFN_Time,id:2432,x:30998,y:32080,varname:node_2432,prsc:2;n:type:ShaderForge.SFN_Multiply,id:9571,x:31305,y:32043,varname:node_9571,prsc:2|A-6080-OUT,B-2432-TSL;n:type:ShaderForge.SFN_ValueProperty,id:1967,x:30821,y:31925,ptovrint:False,ptlb:Bubbles Speed,ptin:_BubblesSpeed,varname:node_1967,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:1;n:type:ShaderForge.SFN_Add,id:7186,x:32828,y:32400,varname:node_7186,prsc:2|A-6854-OUT,B-1582-OUT;n:type:ShaderForge.SFN_Tex2d,id:3556,x:30795,y:32169,varname:node_3556,prsc:2,ntxv:3,isnm:False|UVIN-2512-OUT,TEX-9995-TEX;n:type:ShaderForge.SFN_Add,id:8306,x:31829,y:32138,varname:node_8306,prsc:2|A-1787-UVOUT,B-9086-OUT;n:type:ShaderForge.SFN_ComponentMask,id:9086,x:31124,y:32278,varname:node_9086,prsc:2,cc1:0,cc2:1,cc3:-1,cc4:-1|IN-3556-RGB;n:type:ShaderForge.SFN_Vector1,id:4089,x:30434,y:32542,varname:node_4089,prsc:2,v1:0.7;n:type:ShaderForge.SFN_Add,id:4307,x:31124,y:32447,varname:node_4307,prsc:2|A-4089-OUT,B-4329-OUT;n:type:ShaderForge.SFN_Lerp,id:1980,x:32337,y:32426,varname:node_1980,prsc:2|A-2814-RGB,B-6665-RGB,T-4307-OUT;n:type:ShaderForge.SFN_Multiply,id:1582,x:32566,y:32461,varname:node_1582,prsc:2|A-1980-OUT,B-9881-OUT;n:type:ShaderForge.SFN_Multiply,id:2929,x:32541,y:32889,varname:node_2929,prsc:2|A-4329-OUT,B-7736-RGB;n:type:ShaderForge.SFN_Panner,id:1787,x:31545,y:31999,varname:node_1787,prsc:2,spu:0,spv:1|UVIN-7133-OUT,DIST-9571-OUT;n:type:ShaderForge.SFN_Panner,id:2897,x:31777,y:31844,varname:node_2897,prsc:2,spu:0,spv:1|UVIN-7733-OUT,DIST-9080-OUT;n:type:ShaderForge.SFN_Multiply,id:9080,x:31545,y:31825,varname:node_9080,prsc:2|A-5319-OUT,B-2432-TSL;n:type:ShaderForge.SFN_Add,id:2936,x:32037,y:31933,varname:node_2936,prsc:2|A-2897-UVOUT,B-9086-OUT;n:type:ShaderForge.SFN_Vector1,id:6860,x:30320,y:32829,varname:node_6860,prsc:2,v1:50;n:type:ShaderForge.SFN_Tex2d,id:8342,x:32399,y:31912,varname:_Bubbles_copy,prsc:2,tex:df5f991d641acba42be0d90d3b2c89ad,ntxv:0,isnm:False|UVIN-2936-OUT,TEX-6791-TEX;n:type:ShaderForge.SFN_Add,id:523,x:32410,y:32183,varname:node_523,prsc:2|A-8342-RGB,B-6758-RGB;n:type:ShaderForge.SFN_Multiply,id:6080,x:30998,y:31925,varname:node_6080,prsc:2|A-1122-OUT,B-1967-OUT;n:type:ShaderForge.SFN_Vector1,id:1122,x:30832,y:31835,varname:node_1122,prsc:2,v1:-1;n:type:ShaderForge.SFN_Multiply,id:5319,x:31319,y:31787,varname:node_5319,prsc:2|A-7033-OUT,B-6080-OUT;n:type:ShaderForge.SFN_Blend,id:6854,x:32621,y:32227,varname:node_6854,prsc:2,blmd:3,clmp:True|SRC-523-OUT,DST-7736-RGB;n:type:ShaderForge.SFN_Negate,id:1622,x:30694,y:32751,varname:node_1622,prsc:2|IN-1454-OUT;n:type:ShaderForge.SFN_ValueProperty,id:3992,x:30659,y:32950,ptovrint:False,ptlb:Foam Volume,ptin:_FoamVolume,varname:node_3992,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:9;n:type:ShaderForge.SFN_Tex2d,id:4794,x:31275,y:33015,ptovrint:False,ptlb:Foam,ptin:_Foam,varname:node_4794,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:df5f991d641acba42be0d90d3b2c89ad,ntxv:0,isnm:False|UVIN-4439-OUT;n:type:ShaderForge.SFN_OneMinus,id:445,x:31479,y:33032,varname:node_445,prsc:2|IN-4794-R;n:type:ShaderForge.SFN_Multiply,id:4416,x:30871,y:32633,varname:node_4416,prsc:2|A-8590-G,B-6863-OUT;n:type:ShaderForge.SFN_ValueProperty,id:6863,x:30626,y:32633,ptovrint:False,ptlb:Foam Waves Variation,ptin:_FoamWavesVariation,varname:node_6863,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:1.5;n:type:ShaderForge.SFN_Add,id:9585,x:31042,y:32790,varname:node_9585,prsc:2|A-4416-OUT,B-9754-OUT;n:type:ShaderForge.SFN_Tex2d,id:8590,x:30421,y:32380,varname:node_8590,prsc:2,ntxv:3,isnm:False|UVIN-9655-UVOUT,TEX-9995-TEX;n:type:ShaderForge.SFN_Add,id:9754,x:30871,y:32837,varname:node_9754,prsc:2|A-1622-OUT,B-3992-OUT;n:type:ShaderForge.SFN_Lerp,id:5080,x:33065,y:32429,varname:node_5080,prsc:2|A-7186-OUT,B-90-OUT,T-6945-OUT;n:type:ShaderForge.SFN_Add,id:7782,x:32391,y:32777,varname:node_7782,prsc:2|A-7736-RGB,B-834-OUT;n:type:ShaderForge.SFN_Vector1,id:834,x:32150,y:32944,varname:node_834,prsc:2,v1:0.3;n:type:ShaderForge.SFN_Multiply,id:1457,x:31710,y:33008,varname:node_1457,prsc:2|A-6809-OUT,B-445-OUT;n:type:ShaderForge.SFN_Multiply,id:90,x:32591,y:32681,varname:node_90,prsc:2|A-1457-OUT,B-7782-OUT;n:type:ShaderForge.SFN_Clamp01,id:4650,x:31275,y:32800,varname:node_4650,prsc:2|IN-9585-OUT;n:type:ShaderForge.SFN_Multiply,id:1454,x:30491,y:32730,varname:node_1454,prsc:2|A-4329-OUT,B-6860-OUT;n:type:ShaderForge.SFN_Blend,id:6809,x:31556,y:32838,varname:node_6809,prsc:2,blmd:10,clmp:True|SRC-2814-RGB,DST-4650-OUT;n:type:ShaderForge.SFN_Multiply,id:6945,x:31455,y:32623,varname:node_6945,prsc:2|A-7002-OUT,B-4650-OUT;n:type:ShaderForge.SFN_ToggleProperty,id:7002,x:31253,y:32588,ptovrint:False,ptlb:Foam Active,ptin:_FoamActive,varname:node_7002,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,on:True;n:type:ShaderForge.SFN_Tex2dAsset,id:6791,x:31747,y:31636,ptovrint:False,ptlb:Bubbles,ptin:_Bubbles,varname:node_6791,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:df5f991d641acba42be0d90d3b2c89ad,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Multiply,id:7733,x:31338,y:31385,varname:node_7733,prsc:2|A-1290-OUT,B-6506-UVOUT;n:type:ShaderForge.SFN_Vector1,id:1290,x:31307,y:31304,varname:node_1290,prsc:2,v1:3;n:type:ShaderForge.SFN_TexCoord,id:6506,x:31036,y:31278,varname:node_6506,prsc:2,uv:0;n:type:ShaderForge.SFN_Multiply,id:7133,x:31338,y:31541,varname:node_7133,prsc:2|A-6506-UVOUT,B-7033-OUT;n:type:ShaderForge.SFN_Vector1,id:7033,x:31140,y:31562,varname:node_7033,prsc:2,v1:1.5;n:type:ShaderForge.SFN_Tex2dAsset,id:9995,x:30213,y:32079,ptovrint:False,ptlb:Beer Normal,ptin:_BeerNormal,varname:node_9995,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,ntxv:3,isnm:False;n:type:ShaderForge.SFN_Multiply,id:2512,x:30608,y:31643,varname:node_2512,prsc:2|A-6506-UVOUT,B-5494-OUT;n:type:ShaderForge.SFN_ValueProperty,id:2691,x:30238,y:31798,ptovrint:False,ptlb:Bubbles Distrortion,ptin:_BubblesDistrortion,varname:node_2691,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:1;n:type:ShaderForge.SFN_Multiply,id:5494,x:30432,y:31711,varname:node_5494,prsc:2|A-9407-OUT,B-2691-OUT;n:type:ShaderForge.SFN_Vector1,id:9407,x:30238,y:31711,varname:node_9407,prsc:2,v1:0.15;n:type:ShaderForge.SFN_Panner,id:9655,x:30123,y:32300,varname:node_9655,prsc:2,spu:1,spv:1|DIST-7240-OUT;n:type:ShaderForge.SFN_Multiply,id:7240,x:29950,y:32288,varname:node_7240,prsc:2|A-2432-TSL,B-2801-OUT;n:type:ShaderForge.SFN_ValueProperty,id:2801,x:29712,y:32413,ptovrint:False,ptlb:Foam Waves Speed,ptin:_FoamWavesSpeed,varname:node_2801,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:2;n:type:ShaderForge.SFN_Multiply,id:8036,x:30724,y:33057,varname:node_8036,prsc:2|A-2432-TSL,B-1830-OUT;n:type:ShaderForge.SFN_ValueProperty,id:1906,x:30337,y:33136,ptovrint:False,ptlb:Foam Speed,ptin:_FoamSpeed,varname:node_1906,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:1;n:type:ShaderForge.SFN_Panner,id:7504,x:30890,y:33024,varname:node_7504,prsc:2,spu:0,spv:1|UVIN-3158-OUT,DIST-8036-OUT;n:type:ShaderForge.SFN_Multiply,id:1830,x:30534,y:33078,varname:node_1830,prsc:2|A-2364-OUT,B-1906-OUT;n:type:ShaderForge.SFN_Vector1,id:2364,x:30347,y:32987,varname:node_2364,prsc:2,v1:-0.1;n:type:ShaderForge.SFN_Multiply,id:3158,x:30184,y:32920,varname:node_3158,prsc:2|A-2639-UVOUT,B-4638-OUT;n:type:ShaderForge.SFN_Vector1,id:4638,x:29991,y:33064,varname:node_4638,prsc:2,v1:10;n:type:ShaderForge.SFN_Tex2d,id:3022,x:30568,y:32256,varname:node_3022,prsc:2,ntxv:0,isnm:False|TEX-9995-TEX;n:type:ShaderForge.SFN_Add,id:4439,x:31106,y:32946,varname:node_4439,prsc:2|A-627-OUT,B-7504-UVOUT;n:type:ShaderForge.SFN_ComponentMask,id:1821,x:30740,y:32323,varname:node_1821,prsc:2,cc1:0,cc2:1,cc3:-1,cc4:-1|IN-3022-RGB;n:type:ShaderForge.SFN_Multiply,id:627,x:30914,y:32393,varname:node_627,prsc:2|A-1821-OUT,B-6772-OUT;n:type:ShaderForge.SFN_ValueProperty,id:6772,x:30715,y:32508,ptovrint:False,ptlb:Foam Variation,ptin:_FoamVariation,varname:node_6772,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:1;proporder:7736-6665-2814-358-1813-5282-9995-6791-1967-2691-7002-4794-3992-6863-2801-1906-6772;pass:END;sub:END;*/

Shader "Shader Forge/Beer" {
    Properties {
        _MainTex ("Blur Mask", 2D) = "white" {}
        _Color1 ("Color1", Color) = (0.9921569,0.8039216,0.003921569,1)
        _Color2 ("Color2", Color) = (0.7607844,0.3137255,0,1)
        _Metallic ("Metallic", Range(0, 1)) = 0
        _Gloss ("Gloss", Range(0, 1)) = 0.8
        _Emissive ("Emissive", Float ) = 1
        _BeerNormal ("Beer Normal", 2D) = "bump" {}
        _Bubbles ("Bubbles", 2D) = "white" {}
        _BubblesSpeed ("Bubbles Speed", Float ) = 1
        _BubblesDistrortion ("Bubbles Distrortion", Float ) = 1
        [MaterialToggle] _FoamActive ("Foam Active", Float ) = 1
        _Foam ("Foam", 2D) = "white" {}
        _FoamVolume ("Foam Volume", Float ) = 9
        _FoamWavesVariation ("Foam Waves Variation", Float ) = 1.5
        _FoamWavesSpeed ("Foam Waves Speed", Float ) = 2
        _FoamSpeed ("Foam Speed", Float ) = 1
        _FoamVariation ("Foam Variation", Float ) = 1
    }
    SubShader {
        Tags {
            "RenderType"="Opaque"
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
            uniform float4 _Color1;
            uniform sampler2D _MainTex; uniform float4 _MainTex_ST;
            uniform float _Metallic;
            uniform float _Gloss;
            uniform float4 _Color2;
            uniform float _Emissive;
            uniform float _BubblesSpeed;
            uniform float _FoamVolume;
            uniform sampler2D _Foam; uniform float4 _Foam_ST;
            uniform float _FoamWavesVariation;
            uniform fixed _FoamActive;
            uniform sampler2D _Bubbles; uniform float4 _Bubbles_ST;
            uniform sampler2D _BeerNormal; uniform float4 _BeerNormal_ST;
            uniform float _BubblesDistrortion;
            uniform float _FoamWavesSpeed;
            uniform float _FoamSpeed;
            uniform float _FoamVariation;
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
                float3 normalDirection = i.normalDir;
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
                float gloss = _Gloss;
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
                float node_7033 = 1.5;
                float node_6080 = ((-1.0)*_BubblesSpeed);
                float4 node_2432 = _Time + _TimeEditor;
                float2 node_2512 = (i.uv0*(0.15*_BubblesDistrortion));
                float4 node_3556 = tex2D(_BeerNormal,TRANSFORM_TEX(node_2512, _BeerNormal));
                float2 node_9086 = node_3556.rgb.rg;
                float2 node_2936 = (((3.0*i.uv0)+((node_7033*node_6080)*node_2432.r)*float2(0,1))+node_9086);
                float4 _Bubbles_copy = tex2D(_Bubbles,TRANSFORM_TEX(node_2936, _Bubbles));
                float2 node_8306 = (((i.uv0*node_7033)+(node_6080*node_2432.r)*float2(0,1))+node_9086);
                float4 node_6758 = tex2D(_Bubbles,TRANSFORM_TEX(node_8306, _Bubbles));
                float4 _MainTex_var = tex2D(_MainTex,TRANSFORM_TEX(i.uv0, _MainTex));
                float node_4329 = (1.0 - i.uv0.g);
                float2 node_9655 = (i.uv0+(node_2432.r*_FoamWavesSpeed)*float2(1,1));
                float4 node_8590 = tex2D(_BeerNormal,TRANSFORM_TEX(node_9655, _BeerNormal));
                float node_4650 = saturate(((node_8590.g*_FoamWavesVariation)+((-1*(node_4329*50.0))+_FoamVolume)));
                float4 node_3022 = tex2D(_BeerNormal,TRANSFORM_TEX(i.uv0, _BeerNormal));
                float2 node_4439 = ((node_3022.rgb.rg*_FoamVariation)+((i.uv0*10.0)+(node_2432.r*((-0.1)*_FoamSpeed))*float2(0,1)));
                float4 _Foam_var = tex2D(_Foam,TRANSFORM_TEX(node_4439, _Foam));
                float3 node_5080 = lerp((saturate(((_Bubbles_copy.rgb+node_6758.rgb)+_MainTex_var.rgb-1.0))+(lerp(_Color2.rgb,_Color1.rgb,(0.7+node_4329))*lerp(_Color2.rgb,_Color1.rgb,_MainTex_var.rgb))),((saturate(( node_4650 > 0.5 ? (1.0-(1.0-2.0*(node_4650-0.5))*(1.0-_Color2.rgb)) : (2.0*node_4650*_Color2.rgb) ))*(1.0 - _Foam_var.r))*(_MainTex_var.rgb+0.3)),(_FoamActive*node_4650));
                float3 diffuseColor = node_5080; // Need this for specular when using metallic
                float specularMonochrome;
                float3 specularColor;
                diffuseColor = DiffuseAndSpecularFromMetallic( diffuseColor, _Metallic, specularColor, specularMonochrome );
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
                float3 emissive = ((_Emissive*node_5080)*(node_4329*_MainTex_var.rgb));
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
            uniform float4 _Color1;
            uniform sampler2D _MainTex; uniform float4 _MainTex_ST;
            uniform float _Metallic;
            uniform float _Gloss;
            uniform float4 _Color2;
            uniform float _Emissive;
            uniform float _BubblesSpeed;
            uniform float _FoamVolume;
            uniform sampler2D _Foam; uniform float4 _Foam_ST;
            uniform float _FoamWavesVariation;
            uniform fixed _FoamActive;
            uniform sampler2D _Bubbles; uniform float4 _Bubbles_ST;
            uniform sampler2D _BeerNormal; uniform float4 _BeerNormal_ST;
            uniform float _BubblesDistrortion;
            uniform float _FoamWavesSpeed;
            uniform float _FoamSpeed;
            uniform float _FoamVariation;
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
                float3 normalDirection = i.normalDir;
                float3 lightDirection = normalize(lerp(_WorldSpaceLightPos0.xyz, _WorldSpaceLightPos0.xyz - i.posWorld.xyz,_WorldSpaceLightPos0.w));
                float3 lightColor = _LightColor0.rgb;
                float3 halfDirection = normalize(viewDirection+lightDirection);
////// Lighting:
                float attenuation = LIGHT_ATTENUATION(i);
                float3 attenColor = attenuation * _LightColor0.xyz;
                float Pi = 3.141592654;
                float InvPi = 0.31830988618;
///////// Gloss:
                float gloss = _Gloss;
                float specPow = exp2( gloss * 10.0+1.0);
////// Specular:
                float NdotL = max(0, dot( normalDirection, lightDirection ));
                float LdotH = max(0.0,dot(lightDirection, halfDirection));
                float node_7033 = 1.5;
                float node_6080 = ((-1.0)*_BubblesSpeed);
                float4 node_2432 = _Time + _TimeEditor;
                float2 node_2512 = (i.uv0*(0.15*_BubblesDistrortion));
                float4 node_3556 = tex2D(_BeerNormal,TRANSFORM_TEX(node_2512, _BeerNormal));
                float2 node_9086 = node_3556.rgb.rg;
                float2 node_2936 = (((3.0*i.uv0)+((node_7033*node_6080)*node_2432.r)*float2(0,1))+node_9086);
                float4 _Bubbles_copy = tex2D(_Bubbles,TRANSFORM_TEX(node_2936, _Bubbles));
                float2 node_8306 = (((i.uv0*node_7033)+(node_6080*node_2432.r)*float2(0,1))+node_9086);
                float4 node_6758 = tex2D(_Bubbles,TRANSFORM_TEX(node_8306, _Bubbles));
                float4 _MainTex_var = tex2D(_MainTex,TRANSFORM_TEX(i.uv0, _MainTex));
                float node_4329 = (1.0 - i.uv0.g);
                float2 node_9655 = (i.uv0+(node_2432.r*_FoamWavesSpeed)*float2(1,1));
                float4 node_8590 = tex2D(_BeerNormal,TRANSFORM_TEX(node_9655, _BeerNormal));
                float node_4650 = saturate(((node_8590.g*_FoamWavesVariation)+((-1*(node_4329*50.0))+_FoamVolume)));
                float4 node_3022 = tex2D(_BeerNormal,TRANSFORM_TEX(i.uv0, _BeerNormal));
                float2 node_4439 = ((node_3022.rgb.rg*_FoamVariation)+((i.uv0*10.0)+(node_2432.r*((-0.1)*_FoamSpeed))*float2(0,1)));
                float4 _Foam_var = tex2D(_Foam,TRANSFORM_TEX(node_4439, _Foam));
                float3 node_5080 = lerp((saturate(((_Bubbles_copy.rgb+node_6758.rgb)+_MainTex_var.rgb-1.0))+(lerp(_Color2.rgb,_Color1.rgb,(0.7+node_4329))*lerp(_Color2.rgb,_Color1.rgb,_MainTex_var.rgb))),((saturate(( node_4650 > 0.5 ? (1.0-(1.0-2.0*(node_4650-0.5))*(1.0-_Color2.rgb)) : (2.0*node_4650*_Color2.rgb) ))*(1.0 - _Foam_var.r))*(_MainTex_var.rgb+0.3)),(_FoamActive*node_4650));
                float3 diffuseColor = node_5080; // Need this for specular when using metallic
                float specularMonochrome;
                float3 specularColor;
                diffuseColor = DiffuseAndSpecularFromMetallic( diffuseColor, _Metallic, specularColor, specularMonochrome );
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
            uniform float4 _Color1;
            uniform sampler2D _MainTex; uniform float4 _MainTex_ST;
            uniform float _Metallic;
            uniform float _Gloss;
            uniform float4 _Color2;
            uniform float _Emissive;
            uniform float _BubblesSpeed;
            uniform float _FoamVolume;
            uniform sampler2D _Foam; uniform float4 _Foam_ST;
            uniform float _FoamWavesVariation;
            uniform fixed _FoamActive;
            uniform sampler2D _Bubbles; uniform float4 _Bubbles_ST;
            uniform sampler2D _BeerNormal; uniform float4 _BeerNormal_ST;
            uniform float _BubblesDistrortion;
            uniform float _FoamWavesSpeed;
            uniform float _FoamSpeed;
            uniform float _FoamVariation;
            struct VertexInput {
                float4 vertex : POSITION;
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
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.uv1 = v.texcoord1;
                o.uv2 = v.texcoord2;
                o.posWorld = mul(_Object2World, v.vertex);
                o.pos = UnityMetaVertexPosition(v.vertex, v.texcoord1.xy, v.texcoord2.xy, unity_LightmapST, unity_DynamicLightmapST );
                return o;
            }
            float4 frag(VertexOutput i) : SV_Target {
/////// Vectors:
                float3 viewDirection = normalize(_WorldSpaceCameraPos.xyz - i.posWorld.xyz);
                UnityMetaInput o;
                UNITY_INITIALIZE_OUTPUT( UnityMetaInput, o );
                
                float node_7033 = 1.5;
                float node_6080 = ((-1.0)*_BubblesSpeed);
                float4 node_2432 = _Time + _TimeEditor;
                float2 node_2512 = (i.uv0*(0.15*_BubblesDistrortion));
                float4 node_3556 = tex2D(_BeerNormal,TRANSFORM_TEX(node_2512, _BeerNormal));
                float2 node_9086 = node_3556.rgb.rg;
                float2 node_2936 = (((3.0*i.uv0)+((node_7033*node_6080)*node_2432.r)*float2(0,1))+node_9086);
                float4 _Bubbles_copy = tex2D(_Bubbles,TRANSFORM_TEX(node_2936, _Bubbles));
                float2 node_8306 = (((i.uv0*node_7033)+(node_6080*node_2432.r)*float2(0,1))+node_9086);
                float4 node_6758 = tex2D(_Bubbles,TRANSFORM_TEX(node_8306, _Bubbles));
                float4 _MainTex_var = tex2D(_MainTex,TRANSFORM_TEX(i.uv0, _MainTex));
                float node_4329 = (1.0 - i.uv0.g);
                float2 node_9655 = (i.uv0+(node_2432.r*_FoamWavesSpeed)*float2(1,1));
                float4 node_8590 = tex2D(_BeerNormal,TRANSFORM_TEX(node_9655, _BeerNormal));
                float node_4650 = saturate(((node_8590.g*_FoamWavesVariation)+((-1*(node_4329*50.0))+_FoamVolume)));
                float4 node_3022 = tex2D(_BeerNormal,TRANSFORM_TEX(i.uv0, _BeerNormal));
                float2 node_4439 = ((node_3022.rgb.rg*_FoamVariation)+((i.uv0*10.0)+(node_2432.r*((-0.1)*_FoamSpeed))*float2(0,1)));
                float4 _Foam_var = tex2D(_Foam,TRANSFORM_TEX(node_4439, _Foam));
                float3 node_5080 = lerp((saturate(((_Bubbles_copy.rgb+node_6758.rgb)+_MainTex_var.rgb-1.0))+(lerp(_Color2.rgb,_Color1.rgb,(0.7+node_4329))*lerp(_Color2.rgb,_Color1.rgb,_MainTex_var.rgb))),((saturate(( node_4650 > 0.5 ? (1.0-(1.0-2.0*(node_4650-0.5))*(1.0-_Color2.rgb)) : (2.0*node_4650*_Color2.rgb) ))*(1.0 - _Foam_var.r))*(_MainTex_var.rgb+0.3)),(_FoamActive*node_4650));
                o.Emission = ((_Emissive*node_5080)*(node_4329*_MainTex_var.rgb));
                
                float3 diffColor = node_5080;
                float specularMonochrome;
                float3 specColor;
                diffColor = DiffuseAndSpecularFromMetallic( diffColor, _Metallic, specColor, specularMonochrome );
                float roughness = 1.0 - _Gloss;
                o.Albedo = diffColor + specColor * roughness * roughness * 0.5;
                
                return UnityMetaFragment( o );
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
    CustomEditor "ShaderForgeMaterialInspector"
}
