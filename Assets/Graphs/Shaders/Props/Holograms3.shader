// Shader created with Shader Forge v1.19 
// Shader Forge (c) Neat Corporation / Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.19;sub:START;pass:START;ps:flbk:,iptp:0,cusa:False,bamd:0,lico:1,lgpr:1,limd:0,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:False,hqlp:False,rprd:False,enco:False,rmgx:True,rpth:0,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:0,bsrc:0,bdst:0,dpts:2,wrdp:False,dith:0,rfrpo:True,rfrpn:Refraction,coma:15,ufog:True,aust:True,igpj:True,qofs:0,qpre:3,rntp:2,fgom:False,fgoc:True,fgod:False,fgor:False,fgmd:0,fgcr:0,fgcg:0,fgcb:0,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False;n:type:ShaderForge.SFN_Final,id:4795,x:32306,y:32864,varname:node_4795,prsc:2|emission-2393-OUT;n:type:ShaderForge.SFN_Multiply,id:2393,x:32128,y:32965,varname:node_2393,prsc:2|A-9502-OUT,B-2053-RGB,C-9248-OUT;n:type:ShaderForge.SFN_VertexColor,id:2053,x:31883,y:33044,varname:node_2053,prsc:2;n:type:ShaderForge.SFN_Vector1,id:9248,x:31915,y:33215,varname:node_9248,prsc:2,v1:2;n:type:ShaderForge.SFN_Multiply,id:6987,x:31402,y:32631,varname:node_6987,prsc:2|A-6917-RGB,B-6917-A;n:type:ShaderForge.SFN_Tex2d,id:6917,x:31127,y:32672,ptovrint:True,ptlb:Hologram_copy,ptin:_MainTex,varname:_MainTex,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:937a7b5e5dfa2ba4dafdb2e4df8144fe,ntxv:2,isnm:False|UVIN-3875-UVOUT;n:type:ShaderForge.SFN_Slider,id:3166,x:30873,y:33509,ptovrint:False,ptlb:Emission,ptin:_Emission,varname:node_9741,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0.8,max:2;n:type:ShaderForge.SFN_Time,id:3262,x:30075,y:33204,varname:node_3262,prsc:2;n:type:ShaderForge.SFN_Multiply,id:2882,x:30260,y:33360,varname:node_2882,prsc:2|A-3262-TSL,B-9489-OUT;n:type:ShaderForge.SFN_Multiply,id:1697,x:30633,y:32405,varname:node_1697,prsc:2|A-5475-OUT,B-1881-OUT;n:type:ShaderForge.SFN_Sin,id:8550,x:30806,y:32405,varname:node_8550,prsc:2|IN-1697-OUT;n:type:ShaderForge.SFN_Panner,id:6958,x:30074,y:32360,varname:node_6958,prsc:2,spu:0.04,spv:-0.04;n:type:ShaderForge.SFN_ComponentMask,id:4208,x:30268,y:32360,varname:node_4208,prsc:2,cc1:0,cc2:1,cc3:-1,cc4:-1|IN-6958-UVOUT;n:type:ShaderForge.SFN_Multiply,id:7030,x:31843,y:32602,varname:node_7030,prsc:2|A-7654-OUT,B-5436-OUT;n:type:ShaderForge.SFN_Add,id:1238,x:31200,y:32385,varname:node_1238,prsc:2|A-8856-OUT,B-2189-OUT;n:type:ShaderForge.SFN_Vector1,id:8856,x:30996,y:32314,varname:node_8856,prsc:2,v1:0.75;n:type:ShaderForge.SFN_Clamp01,id:2189,x:30996,y:32405,varname:node_2189,prsc:2|IN-8550-OUT;n:type:ShaderForge.SFN_Clamp01,id:5436,x:31507,y:32446,varname:node_5436,prsc:2|IN-1238-OUT;n:type:ShaderForge.SFN_Tex2d,id:7402,x:30671,y:33381,ptovrint:False,ptlb:Glitter Ramp,ptin:_GlitterRamp,varname:node_1071,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:38167fec73ed1de4485500923092dcc7,ntxv:0,isnm:False|UVIN-4976-OUT;n:type:ShaderForge.SFN_Vector1,id:5193,x:30236,y:33568,varname:node_5193,prsc:2,v1:0.5;n:type:ShaderForge.SFN_Append,id:4976,x:30448,y:33416,varname:node_4976,prsc:2|A-2882-OUT,B-5193-OUT;n:type:ShaderForge.SFN_Multiply,id:9502,x:31884,y:32860,varname:node_9502,prsc:2|A-7030-OUT,B-7753-OUT;n:type:ShaderForge.SFN_Add,id:4429,x:30889,y:33287,varname:node_4429,prsc:2|A-7365-OUT,B-7402-R;n:type:ShaderForge.SFN_Clamp01,id:1448,x:31060,y:33318,varname:node_1448,prsc:2|IN-4429-OUT;n:type:ShaderForge.SFN_Multiply,id:7753,x:31263,y:33427,varname:node_7753,prsc:2|A-1448-OUT,B-3166-OUT;n:type:ShaderForge.SFN_ValueProperty,id:9489,x:30003,y:33421,ptovrint:False,ptlb:Glitter Speed,ptin:_GlitterSpeed,varname:node_5093,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:1;n:type:ShaderForge.SFN_UVTile,id:3875,x:30947,y:32639,varname:node_3875,prsc:2|UVIN-9506-UVOUT,WDT-642-OUT,HGT-642-OUT,TILE-1424-OUT;n:type:ShaderForge.SFN_TexCoord,id:9506,x:30728,y:32601,varname:node_9506,prsc:2,uv:0;n:type:ShaderForge.SFN_Vector1,id:642,x:30728,y:32765,varname:node_642,prsc:2,v1:3;n:type:ShaderForge.SFN_ValueProperty,id:1424,x:30728,y:32869,ptovrint:False,ptlb:Patern,ptin:_Patern,varname:node_587,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:3;n:type:ShaderForge.SFN_Multiply,id:7164,x:31402,y:32815,varname:node_7164,prsc:2|A-9526-RGB,B-9526-A;n:type:ShaderForge.SFN_Multiply,id:4900,x:31402,y:32977,varname:node_4900,prsc:2|A-4649-RGB,B-4649-A;n:type:ShaderForge.SFN_Add,id:7654,x:31632,y:32712,varname:node_7654,prsc:2|A-6987-OUT,B-7164-OUT,C-4900-OUT;n:type:ShaderForge.SFN_Tex2d,id:9526,x:31127,y:32881,ptovrint:False,ptlb:Hologram_Background,ptin:_Hologram_Background,varname:node_504,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:5b8acae61381adc489edb070a0f947e3,ntxv:2,isnm:False;n:type:ShaderForge.SFN_Tex2d,id:4649,x:31127,y:33089,ptovrint:False,ptlb:Hologram_Foreground,ptin:_Hologram_Foreground,varname:_Hologram_Background_copy,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:600a807dbfb0eab43b8a1803a3ca9a66,ntxv:2,isnm:False;n:type:ShaderForge.SFN_SwitchProperty,id:5475,x:30461,y:32337,ptovrint:False,ptlb:Horizontal,ptin:_Horizontal,varname:node_7060,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,on:True|A-4208-R,B-4208-G;n:type:ShaderForge.SFN_ValueProperty,id:1881,x:30461,y:32511,ptovrint:False,ptlb:Lines finess,ptin:_Linesfiness,varname:node_8693,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:60;n:type:ShaderForge.SFN_ValueProperty,id:7365,x:30635,y:33208,ptovrint:False,ptlb:Glitter Power,ptin:_GlitterPower,varname:node_6870,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:0.8;proporder:3166-1881-7402-9489-7365-6917-1424-5475-4649-9526;pass:END;sub:END;*/

Shader "Shader Forge/Holograms3" {
    Properties {
        _Emission ("Emission", Range(0, 2)) = 0.8
        _Linesfiness ("Lines finess", Float ) = 60
        _GlitterRamp ("Glitter Ramp", 2D) = "white" {}
        _GlitterSpeed ("Glitter Speed", Float ) = 1
        _GlitterPower ("Glitter Power", Float ) = 0.8
        _MainTex ("Hologram_copy", 2D) = "black" {}
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
            ZWrite Off
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_FORWARDBASE
            #include "UnityCG.cginc"
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
                float4 vertexColor : COLOR;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float2 uv0 : TEXCOORD0;
                float4 vertexColor : COLOR;
                UNITY_FOG_COORDS(1)
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.vertexColor = v.vertexColor;
                o.pos = mul(UNITY_MATRIX_MVP, v.vertex );
                UNITY_TRANSFER_FOG(o,o.pos);
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
/////// Vectors:
////// Lighting:
////// Emissive:
                float node_642 = 3.0;
                float2 node_3875_tc_rcp = float2(1.0,1.0)/float2( node_642, node_642 );
                float node_3875_ty = floor(_Patern * node_3875_tc_rcp.x);
                float node_3875_tx = _Patern - node_642 * node_3875_ty;
                float2 node_3875 = (i.uv0 + float2(node_3875_tx, node_3875_ty)) * node_3875_tc_rcp;
                float4 _MainTex_var = tex2D(_MainTex,TRANSFORM_TEX(node_3875, _MainTex));
                float4 _Hologram_Background_var = tex2D(_Hologram_Background,TRANSFORM_TEX(i.uv0, _Hologram_Background));
                float4 _Hologram_Foreground_var = tex2D(_Hologram_Foreground,TRANSFORM_TEX(i.uv0, _Hologram_Foreground));
                float4 node_127 = _Time + _TimeEditor;
                float2 node_4208 = (i.uv0+node_127.g*float2(0.04,-0.04)).rg;
                float4 node_3262 = _Time + _TimeEditor;
                float2 node_4976 = float2((node_3262.r*_GlitterSpeed),0.5);
                float4 _GlitterRamp_var = tex2D(_GlitterRamp,TRANSFORM_TEX(node_4976, _GlitterRamp));
                float3 emissive = (((((_MainTex_var.rgb*_MainTex_var.a)+(_Hologram_Background_var.rgb*_Hologram_Background_var.a)+(_Hologram_Foreground_var.rgb*_Hologram_Foreground_var.a))*saturate((0.75+saturate(sin((lerp( node_4208.r, node_4208.g, _Horizontal )*_Linesfiness))))))*(saturate((_GlitterPower+_GlitterRamp_var.r))*_Emission))*i.vertexColor.rgb*2.0);
                float3 finalColor = emissive;
                fixed4 finalRGBA = fixed4(finalColor,1);
                UNITY_APPLY_FOG_COLOR(i.fogCoord, finalRGBA, fixed4(0,0,0,1));
                return finalRGBA;
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
    CustomEditor "ShaderForgeMaterialInspector"
}
