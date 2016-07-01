// Shader created with Shader Forge v1.19 
// Shader Forge (c) Neat Corporation / Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.19;sub:START;pass:START;ps:flbk:,iptp:0,cusa:False,bamd:0,lico:1,lgpr:1,limd:3,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:True,hqlp:False,rprd:True,enco:False,rmgx:True,rpth:0,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:0,bsrc:0,bdst:0,dpts:3,wrdp:False,dith:0,rfrpo:True,rfrpn:Refraction,coma:15,ufog:True,aust:True,igpj:True,qofs:0,qpre:3,rntp:2,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5,fgcg:0.5,fgcb:0.5,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False;n:type:ShaderForge.SFN_Final,id:2865,x:32719,y:32712,varname:node_2865,prsc:2|emission-2213-OUT;n:type:ShaderForge.SFN_Multiply,id:1502,x:31820,y:32534,varname:node_1502,prsc:2|A-3171-RGB,B-3171-A;n:type:ShaderForge.SFN_Tex2d,id:3171,x:31545,y:32575,ptovrint:True,ptlb:Hologram,ptin:_MainTex,varname:_MainTex,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:937a7b5e5dfa2ba4dafdb2e4df8144fe,ntxv:2,isnm:False|UVIN-1467-UVOUT;n:type:ShaderForge.SFN_Slider,id:8261,x:31542,y:33620,ptovrint:False,ptlb:Emission,ptin:_Emission,varname:node_9741,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:1.126214,max:2;n:type:ShaderForge.SFN_Time,id:2095,x:30744,y:33315,varname:node_2095,prsc:2;n:type:ShaderForge.SFN_Multiply,id:3816,x:30929,y:33471,varname:node_3816,prsc:2|A-2095-TSL,B-1697-OUT;n:type:ShaderForge.SFN_Multiply,id:2653,x:31051,y:32308,varname:node_2653,prsc:2|A-7060-OUT,B-8693-OUT;n:type:ShaderForge.SFN_Sin,id:6860,x:31224,y:32308,varname:node_6860,prsc:2|IN-2653-OUT;n:type:ShaderForge.SFN_Panner,id:3523,x:30492,y:32263,varname:node_3523,prsc:2,spu:0.04,spv:-0.04;n:type:ShaderForge.SFN_ComponentMask,id:7339,x:30686,y:32263,varname:node_7339,prsc:2,cc1:0,cc2:1,cc3:-1,cc4:-1|IN-3523-UVOUT;n:type:ShaderForge.SFN_Multiply,id:9275,x:32261,y:32505,varname:node_9275,prsc:2|A-7700-OUT,B-1988-OUT;n:type:ShaderForge.SFN_Add,id:98,x:31618,y:32288,varname:node_98,prsc:2|A-2097-OUT,B-6219-OUT;n:type:ShaderForge.SFN_Vector1,id:2097,x:31414,y:32217,varname:node_2097,prsc:2,v1:0.75;n:type:ShaderForge.SFN_Clamp01,id:6219,x:31414,y:32308,varname:node_6219,prsc:2|IN-6860-OUT;n:type:ShaderForge.SFN_Clamp01,id:1988,x:31925,y:32349,varname:node_1988,prsc:2|IN-98-OUT;n:type:ShaderForge.SFN_Tex2d,id:3909,x:31340,y:33492,ptovrint:False,ptlb:Glitter Ramp,ptin:_GlitterRamp,varname:node_1071,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,ntxv:0,isnm:False|UVIN-3186-OUT;n:type:ShaderForge.SFN_Vector1,id:3038,x:30905,y:33679,varname:node_3038,prsc:2,v1:0.5;n:type:ShaderForge.SFN_Append,id:3186,x:31117,y:33527,varname:node_3186,prsc:2|A-3816-OUT,B-3038-OUT;n:type:ShaderForge.SFN_Multiply,id:2213,x:32302,y:32763,varname:node_2213,prsc:2|A-9275-OUT,B-3787-OUT;n:type:ShaderForge.SFN_Add,id:4891,x:31558,y:33398,varname:node_4891,prsc:2|A-6870-OUT,B-3909-R;n:type:ShaderForge.SFN_Clamp01,id:3995,x:31729,y:33429,varname:node_3995,prsc:2|IN-4891-OUT;n:type:ShaderForge.SFN_Multiply,id:3787,x:31932,y:33538,varname:node_3787,prsc:2|A-3995-OUT,B-8261-OUT;n:type:ShaderForge.SFN_ValueProperty,id:1697,x:30672,y:33532,ptovrint:False,ptlb:Glitter Speed,ptin:_GlitterSpeed,varname:node_5093,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:1;n:type:ShaderForge.SFN_UVTile,id:1467,x:31365,y:32542,varname:node_1467,prsc:2|UVIN-7066-UVOUT,WDT-6961-OUT,HGT-6961-OUT,TILE-587-OUT;n:type:ShaderForge.SFN_TexCoord,id:7066,x:31146,y:32504,varname:node_7066,prsc:2,uv:0;n:type:ShaderForge.SFN_Vector1,id:6961,x:31146,y:32668,varname:node_6961,prsc:2,v1:3;n:type:ShaderForge.SFN_ValueProperty,id:587,x:31146,y:32772,ptovrint:False,ptlb:Patern,ptin:_Patern,varname:node_587,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:3;n:type:ShaderForge.SFN_Multiply,id:1236,x:31820,y:32718,varname:node_1236,prsc:2|A-504-RGB,B-504-A;n:type:ShaderForge.SFN_Multiply,id:9947,x:31820,y:32880,varname:node_9947,prsc:2|A-4503-RGB,B-4503-A;n:type:ShaderForge.SFN_Add,id:7700,x:32050,y:32615,varname:node_7700,prsc:2|A-1502-OUT,B-1236-OUT,C-9947-OUT;n:type:ShaderForge.SFN_Tex2d,id:504,x:31545,y:32784,ptovrint:False,ptlb:Hologram_Background,ptin:_Hologram_Background,varname:node_504,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:5b8acae61381adc489edb070a0f947e3,ntxv:2,isnm:False;n:type:ShaderForge.SFN_Tex2d,id:4503,x:31545,y:32992,ptovrint:False,ptlb:Hologram_Foreground,ptin:_Hologram_Foreground,varname:_Hologram_Background_copy,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:600a807dbfb0eab43b8a1803a3ca9a66,ntxv:2,isnm:False;n:type:ShaderForge.SFN_SwitchProperty,id:7060,x:30879,y:32240,ptovrint:False,ptlb:Horizontal,ptin:_Horizontal,varname:node_7060,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,on:True|A-7339-R,B-7339-G;n:type:ShaderForge.SFN_ValueProperty,id:8693,x:30879,y:32414,ptovrint:False,ptlb:Lines finess,ptin:_Linesfiness,varname:node_8693,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:100;n:type:ShaderForge.SFN_ValueProperty,id:6870,x:31304,y:33319,ptovrint:False,ptlb:Glitter Power,ptin:_GlitterPower,varname:node_6870,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:0.8;n:type:ShaderForge.SFN_VertexColor,id:7563,x:31998,y:33092,varname:node_7563,prsc:2;proporder:8261-8693-3909-1697-6870-3171-587-7060-4503-504;pass:END;sub:END;*/

Shader "Shader Forge/Holograms2" {
    Properties {
        _Emission ("Emission", Range(0, 2)) = 1.126214
        _Linesfiness ("Lines finess", Float ) = 100
        _GlitterRamp ("Glitter Ramp", 2D) = "white" {}
        _GlitterSpeed ("Glitter Speed", Float ) = 1
        _GlitterPower ("Glitter Power", Float ) = 0.8
        _MainTex ("Hologram", 2D) = "black" {}
        _Patern ("Patern", Float ) = 3
        [MaterialToggle] _Horizontal ("Horizontal", Float ) = 0
        _Hologram_Foreground ("Hologram_Foreground", 2D) = "black" {}
        _Hologram_Background ("Hologram_Background", 2D) = "black" {}
    }
    SubShader {
        Tags {
            "IgnoreProjector"="True"
            "Queue"="Transparent"
            "RenderType"="Transparent"
        }
        Pass {
            Name "FORWARD"
            Tags {
                "LightMode"="ForwardBase"
            }
            Blend One One
            ZTest GEqual
            ZWrite Off
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_FORWARDBASE
            #define _GLOSSYENV 1
            #include "UnityCG.cginc"
            #include "UnityPBSLighting.cginc"
            #include "UnityStandardBRDF.cginc"
            #pragma multi_compile_fwdbase
            #pragma multi_compile_fog
            #pragma exclude_renderers gles3 metal d3d11_9x xbox360 xboxone ps3 ps4 psp2 
            #pragma target 3.0
            uniform float4 _TimeEditor;
            uniform sampler2D _MainTex; uniform float4 _MainTex_ST;
            uniform float _Emission;
            uniform sampler2D _GlitterRamp; uniform float4 _GlitterRamp_ST;
            uniform float _GlitterSpeed;
            uniform float _Patern;
            uniform sampler2D _Hologram_Background; uniform float4 _Hologram_Background_ST;
            uniform sampler2D _Hologram_Foreground; uniform float4 _Hologram_Foreground_ST;
            uniform fixed _Horizontal;
            uniform float _Linesfiness;
            uniform float _GlitterPower;
            struct VertexInput {
                float4 vertex : POSITION;
                float2 texcoord0 : TEXCOORD0;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float2 uv0 : TEXCOORD0;
                UNITY_FOG_COORDS(1)
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.pos = mul(UNITY_MATRIX_MVP, v.vertex );
                UNITY_TRANSFER_FOG(o,o.pos);
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
/////// Vectors:
////// Lighting:
////// Emissive:
                float node_6961 = 3.0;
                float2 node_1467_tc_rcp = float2(1.0,1.0)/float2( node_6961, node_6961 );
                float node_1467_ty = floor(_Patern * node_1467_tc_rcp.x);
                float node_1467_tx = _Patern - node_6961 * node_1467_ty;
                float2 node_1467 = (i.uv0 + float2(node_1467_tx, node_1467_ty)) * node_1467_tc_rcp;
                float4 _MainTex_var = tex2D(_MainTex,TRANSFORM_TEX(node_1467, _MainTex));
                float4 _Hologram_Background_var = tex2D(_Hologram_Background,TRANSFORM_TEX(i.uv0, _Hologram_Background));
                float4 _Hologram_Foreground_var = tex2D(_Hologram_Foreground,TRANSFORM_TEX(i.uv0, _Hologram_Foreground));
                float4 node_1711 = _Time + _TimeEditor;
                float2 node_7339 = (i.uv0+node_1711.g*float2(0.04,-0.04)).rg;
                float4 node_2095 = _Time + _TimeEditor;
                float2 node_3186 = float2((node_2095.r*_GlitterSpeed),0.5);
                float4 _GlitterRamp_var = tex2D(_GlitterRamp,TRANSFORM_TEX(node_3186, _GlitterRamp));
                float3 emissive = ((((_MainTex_var.rgb*_MainTex_var.a)+(_Hologram_Background_var.rgb*_Hologram_Background_var.a)+(_Hologram_Foreground_var.rgb*_Hologram_Foreground_var.a))*saturate((0.75+saturate(sin((lerp( node_7339.r, node_7339.g, _Horizontal )*_Linesfiness))))))*(saturate((_GlitterPower+_GlitterRamp_var.r))*_Emission));
                float3 finalColor = emissive;
                fixed4 finalRGBA = fixed4(finalColor,1);
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
            #define _GLOSSYENV 1
            #include "UnityCG.cginc"
            #include "UnityPBSLighting.cginc"
            #include "UnityStandardBRDF.cginc"
            #include "UnityMetaPass.cginc"
            #pragma fragmentoption ARB_precision_hint_fastest
            #pragma multi_compile_shadowcaster
            #pragma multi_compile_fog
            #pragma exclude_renderers gles3 metal d3d11_9x xbox360 xboxone ps3 ps4 psp2 
            #pragma target 3.0
            uniform float4 _TimeEditor;
            uniform sampler2D _MainTex; uniform float4 _MainTex_ST;
            uniform float _Emission;
            uniform sampler2D _GlitterRamp; uniform float4 _GlitterRamp_ST;
            uniform float _GlitterSpeed;
            uniform float _Patern;
            uniform sampler2D _Hologram_Background; uniform float4 _Hologram_Background_ST;
            uniform sampler2D _Hologram_Foreground; uniform float4 _Hologram_Foreground_ST;
            uniform fixed _Horizontal;
            uniform float _Linesfiness;
            uniform float _GlitterPower;
            struct VertexInput {
                float4 vertex : POSITION;
                float2 texcoord0 : TEXCOORD0;
                float2 texcoord1 : TEXCOORD1;
                float2 texcoord2 : TEXCOORD2;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float2 uv0 : TEXCOORD0;
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.pos = UnityMetaVertexPosition(v.vertex, v.texcoord1.xy, v.texcoord2.xy, unity_LightmapST, unity_DynamicLightmapST );
                return o;
            }
            float4 frag(VertexOutput i) : SV_Target {
/////// Vectors:
                UnityMetaInput o;
                UNITY_INITIALIZE_OUTPUT( UnityMetaInput, o );
                
                float node_6961 = 3.0;
                float2 node_1467_tc_rcp = float2(1.0,1.0)/float2( node_6961, node_6961 );
                float node_1467_ty = floor(_Patern * node_1467_tc_rcp.x);
                float node_1467_tx = _Patern - node_6961 * node_1467_ty;
                float2 node_1467 = (i.uv0 + float2(node_1467_tx, node_1467_ty)) * node_1467_tc_rcp;
                float4 _MainTex_var = tex2D(_MainTex,TRANSFORM_TEX(node_1467, _MainTex));
                float4 _Hologram_Background_var = tex2D(_Hologram_Background,TRANSFORM_TEX(i.uv0, _Hologram_Background));
                float4 _Hologram_Foreground_var = tex2D(_Hologram_Foreground,TRANSFORM_TEX(i.uv0, _Hologram_Foreground));
                float4 node_5621 = _Time + _TimeEditor;
                float2 node_7339 = (i.uv0+node_5621.g*float2(0.04,-0.04)).rg;
                float4 node_2095 = _Time + _TimeEditor;
                float2 node_3186 = float2((node_2095.r*_GlitterSpeed),0.5);
                float4 _GlitterRamp_var = tex2D(_GlitterRamp,TRANSFORM_TEX(node_3186, _GlitterRamp));
                o.Emission = ((((_MainTex_var.rgb*_MainTex_var.a)+(_Hologram_Background_var.rgb*_Hologram_Background_var.a)+(_Hologram_Foreground_var.rgb*_Hologram_Foreground_var.a))*saturate((0.75+saturate(sin((lerp( node_7339.r, node_7339.g, _Horizontal )*_Linesfiness))))))*(saturate((_GlitterPower+_GlitterRamp_var.r))*_Emission));
                
                float3 diffColor = float3(0,0,0);
                float specularMonochrome;
                float3 specColor;
                diffColor = DiffuseAndSpecularFromMetallic( diffColor, 0, specColor, specularMonochrome );
                o.Albedo = diffColor;
                
                return UnityMetaFragment( o );
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
    CustomEditor "ShaderForgeMaterialInspector"
}
