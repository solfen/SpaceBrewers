// Shader created with Shader Forge v1.19 
// Shader Forge (c) Neat Corporation / Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.19;sub:START;pass:START;ps:flbk:,iptp:0,cusa:False,bamd:0,lico:1,lgpr:1,limd:0,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:False,hqlp:False,rprd:False,enco:False,rmgx:True,rpth:0,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:0,bsrc:3,bdst:7,dpts:2,wrdp:False,dith:0,rfrpo:True,rfrpn:Refraction,coma:15,ufog:False,aust:True,igpj:True,qofs:0,qpre:3,rntp:2,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5,fgcg:0.5,fgcb:0.5,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False;n:type:ShaderForge.SFN_Final,id:3138,x:33082,y:32620,varname:node_3138,prsc:2|emission-4823-OUT,alpha-8333-OUT;n:type:ShaderForge.SFN_Color,id:7241,x:31815,y:32404,ptovrint:False,ptlb:Color,ptin:_Color,varname:node_7241,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0.07843138,c2:0.3921569,c3:0.7843137,c4:1;n:type:ShaderForge.SFN_Tex2d,id:4023,x:31959,y:32830,ptovrint:False,ptlb:Grid Texture,ptin:_GridTexture,varname:node_4023,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:92d6743cfb8b42647ae6f1fb49da609a,ntxv:0,isnm:False|UVIN-9350-OUT;n:type:ShaderForge.SFN_TexCoord,id:1662,x:31517,y:32793,varname:node_1662,prsc:2,uv:0;n:type:ShaderForge.SFN_Multiply,id:9350,x:31760,y:32830,varname:node_9350,prsc:2|A-1662-UVOUT,B-9148-OUT;n:type:ShaderForge.SFN_ValueProperty,id:9148,x:31517,y:32998,ptovrint:False,ptlb:Grid Size,ptin:_GridSize,varname:node_9148,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:12;n:type:ShaderForge.SFN_Add,id:4899,x:32282,y:32934,varname:node_4899,prsc:2|A-4023-R,B-8546-OUT;n:type:ShaderForge.SFN_Fresnel,id:8546,x:31959,y:33017,varname:node_8546,prsc:2|EXP-6105-OUT;n:type:ShaderForge.SFN_ValueProperty,id:6105,x:31733,y:33059,ptovrint:False,ptlb:Opacity Fresnel Exponent,ptin:_OpacityFresnelExponent,varname:node_6105,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:1;n:type:ShaderForge.SFN_Lerp,id:3637,x:32531,y:32625,varname:node_3637,prsc:2|A-8667-OUT,B-7241-RGB,T-6582-OUT;n:type:ShaderForge.SFN_Subtract,id:8667,x:32012,y:32476,varname:node_8667,prsc:2|A-7241-RGB,B-2807-OUT;n:type:ShaderForge.SFN_Vector1,id:2807,x:31815,y:32554,varname:node_2807,prsc:2,v1:0.6;n:type:ShaderForge.SFN_Fresnel,id:6582,x:32141,y:32621,varname:node_6582,prsc:2|EXP-8907-OUT;n:type:ShaderForge.SFN_ValueProperty,id:8907,x:31871,y:32718,ptovrint:False,ptlb:Color Fresnel Exponent,ptin:_ColorFresnelExponent,varname:node_8907,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:1;n:type:ShaderForge.SFN_TexCoord,id:1320,x:30787,y:33389,varname:node_1320,prsc:2,uv:0;n:type:ShaderForge.SFN_Multiply,id:908,x:31041,y:33445,varname:node_908,prsc:2|A-1320-UVOUT,B-6152-OUT;n:type:ShaderForge.SFN_Vector1,id:6152,x:30787,y:33550,varname:node_6152,prsc:2,v1:1;n:type:ShaderForge.SFN_ComponentMask,id:5034,x:31263,y:33270,varname:node_5034,prsc:2,cc1:0,cc2:-1,cc3:-1,cc4:-1|IN-908-OUT;n:type:ShaderForge.SFN_ComponentMask,id:9868,x:31260,y:33617,varname:node_9868,prsc:2,cc1:1,cc2:-1,cc3:-1,cc4:-1|IN-908-OUT;n:type:ShaderForge.SFN_Multiply,id:179,x:31603,y:33269,varname:node_179,prsc:2|A-5034-OUT,B-9220-OUT;n:type:ShaderForge.SFN_OneMinus,id:9220,x:31432,y:33341,varname:node_9220,prsc:2|IN-5034-OUT;n:type:ShaderForge.SFN_Power,id:2254,x:31778,y:33269,varname:node_2254,prsc:2|VAL-179-OUT,EXP-5080-OUT;n:type:ShaderForge.SFN_Vector1,id:5080,x:31585,y:33462,varname:node_5080,prsc:2,v1:2.2;n:type:ShaderForge.SFN_Multiply,id:7311,x:31962,y:33269,varname:node_7311,prsc:2|A-2254-OUT,B-9754-OUT;n:type:ShaderForge.SFN_Vector1,id:9754,x:31778,y:33462,varname:node_9754,prsc:2,v1:40;n:type:ShaderForge.SFN_Multiply,id:8396,x:31601,y:33618,varname:node_8396,prsc:2|A-9868-OUT,B-7047-OUT;n:type:ShaderForge.SFN_OneMinus,id:7047,x:31430,y:33690,varname:node_7047,prsc:2|IN-9868-OUT;n:type:ShaderForge.SFN_Power,id:6083,x:31776,y:33618,varname:node_6083,prsc:2|VAL-8396-OUT,EXP-5080-OUT;n:type:ShaderForge.SFN_Multiply,id:3357,x:31960,y:33618,varname:node_3357,prsc:2|A-6083-OUT,B-9754-OUT;n:type:ShaderForge.SFN_Multiply,id:6379,x:32156,y:33432,varname:node_6379,prsc:2|A-7311-OUT,B-3357-OUT;n:type:ShaderForge.SFN_Multiply,id:8333,x:32483,y:33003,varname:node_8333,prsc:2|A-4899-OUT,B-2531-OUT;n:type:ShaderForge.SFN_Clamp01,id:6062,x:32323,y:33432,varname:node_6062,prsc:2|IN-6379-OUT;n:type:ShaderForge.SFN_Multiply,id:2531,x:32407,y:33189,varname:node_2531,prsc:2|A-6062-OUT,B-5535-OUT;n:type:ShaderForge.SFN_Vector1,id:5535,x:32407,y:33307,varname:node_5535,prsc:2,v1:0.5;n:type:ShaderForge.SFN_TexCoord,id:9537,x:29570,y:31575,varname:node_9537,prsc:2,uv:0;n:type:ShaderForge.SFN_Vector2,id:2290,x:29573,y:31763,varname:node_2290,prsc:2,v1:0.5,v2:0.5;n:type:ShaderForge.SFN_Distance,id:1144,x:29827,y:31645,varname:node_1144,prsc:2|A-9537-UVOUT,B-2290-OUT;n:type:ShaderForge.SFN_Divide,id:2370,x:30061,y:31714,varname:node_2370,prsc:2|A-1144-OUT,B-9051-OUT;n:type:ShaderForge.SFN_OneMinus,id:2339,x:30237,y:31714,varname:node_2339,prsc:2|IN-2370-OUT;n:type:ShaderForge.SFN_Multiply,id:5388,x:30401,y:31907,varname:node_5388,prsc:2|A-2339-OUT,B-6530-OUT;n:type:ShaderForge.SFN_Vector1,id:6530,x:30177,y:31894,varname:node_6530,prsc:2,v1:2.333;n:type:ShaderForge.SFN_Multiply,id:8651,x:30580,y:31891,varname:node_8651,prsc:2|A-5388-OUT,B-5388-OUT;n:type:ShaderForge.SFN_Vector1,id:7124,x:30580,y:31830,varname:node_7124,prsc:2,v1:1;n:type:ShaderForge.SFN_Power,id:7180,x:30753,y:31858,varname:node_7180,prsc:2|VAL-8651-OUT,EXP-7124-OUT;n:type:ShaderForge.SFN_Divide,id:7146,x:30926,y:31805,varname:node_7146,prsc:2|A-3110-OUT,B-7180-OUT;n:type:ShaderForge.SFN_Vector1,id:3110,x:30751,y:31799,varname:node_3110,prsc:2,v1:1;n:type:ShaderForge.SFN_If,id:6236,x:31159,y:31675,varname:node_6236,prsc:2|A-2339-OUT,B-5893-OUT,GT-7146-OUT,EQ-9922-OUT,LT-9922-OUT;n:type:ShaderForge.SFN_Vector1,id:5893,x:30895,y:31735,varname:node_5893,prsc:2,v1:0;n:type:ShaderForge.SFN_Vector1,id:9922,x:30910,y:31935,varname:node_9922,prsc:2,v1:1;n:type:ShaderForge.SFN_OneMinus,id:5684,x:31441,y:31739,varname:node_5684,prsc:2|IN-6236-OUT;n:type:ShaderForge.SFN_Add,id:4823,x:32786,y:32570,varname:node_4823,prsc:2|A-2064-OUT,B-3637-OUT;n:type:ShaderForge.SFN_Clamp01,id:2563,x:31834,y:31809,varname:node_2563,prsc:2|IN-5770-OUT;n:type:ShaderForge.SFN_Divide,id:4316,x:30055,y:32084,varname:node_4316,prsc:2|A-1144-OUT,B-8765-OUT;n:type:ShaderForge.SFN_OneMinus,id:7080,x:30231,y:32084,varname:node_7080,prsc:2|IN-4316-OUT;n:type:ShaderForge.SFN_Multiply,id:6631,x:30395,y:32277,varname:node_6631,prsc:2|A-7080-OUT,B-1462-OUT;n:type:ShaderForge.SFN_Vector1,id:1462,x:30171,y:32264,varname:node_1462,prsc:2,v1:2.333;n:type:ShaderForge.SFN_Multiply,id:4851,x:30574,y:32261,varname:node_4851,prsc:2|A-6631-OUT,B-6631-OUT;n:type:ShaderForge.SFN_Vector1,id:3392,x:30574,y:32200,varname:node_3392,prsc:2,v1:2.718;n:type:ShaderForge.SFN_Power,id:1068,x:30747,y:32228,varname:node_1068,prsc:2|VAL-4851-OUT,EXP-3392-OUT;n:type:ShaderForge.SFN_Divide,id:389,x:30920,y:32175,varname:node_389,prsc:2|A-9297-OUT,B-1068-OUT;n:type:ShaderForge.SFN_Vector1,id:9297,x:30745,y:32169,varname:node_9297,prsc:2,v1:1;n:type:ShaderForge.SFN_If,id:4948,x:31153,y:32045,varname:node_4948,prsc:2|A-7080-OUT,B-8970-OUT,GT-389-OUT,EQ-7846-OUT,LT-7846-OUT;n:type:ShaderForge.SFN_Vector1,id:8970,x:30889,y:32105,varname:node_8970,prsc:2,v1:0;n:type:ShaderForge.SFN_Vector1,id:7846,x:30904,y:32305,varname:node_7846,prsc:2,v1:1;n:type:ShaderForge.SFN_Multiply,id:5770,x:31660,y:31809,varname:node_5770,prsc:2|A-5684-OUT,B-4948-OUT;n:type:ShaderForge.SFN_Time,id:5667,x:28823,y:31953,varname:node_5667,prsc:2;n:type:ShaderForge.SFN_Multiply,id:988,x:29085,y:32027,varname:node_988,prsc:2|A-5667-T,B-8047-OUT;n:type:ShaderForge.SFN_ValueProperty,id:8047,x:28823,y:32148,ptovrint:False,ptlb:Speed,ptin:_Speed,varname:node_8047,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:1;n:type:ShaderForge.SFN_Add,id:9051,x:29836,y:31905,varname:node_9051,prsc:2|A-6299-OUT,B-4737-OUT;n:type:ShaderForge.SFN_Add,id:8765,x:29836,y:32132,varname:node_8765,prsc:2|A-4737-OUT,B-9840-OUT;n:type:ShaderForge.SFN_Frac,id:4737,x:29323,y:32055,varname:node_4737,prsc:2|IN-988-OUT;n:type:ShaderForge.SFN_ValueProperty,id:6299,x:29533,y:31923,ptovrint:False,ptlb:Pulse Radius 1,ptin:_PulseRadius1,varname:node_6299,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:0.5;n:type:ShaderForge.SFN_ValueProperty,id:9840,x:29585,y:32228,ptovrint:False,ptlb:Pulse Radius 2,ptin:_PulseRadius2,varname:_PulseRadius2,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:0.4;n:type:ShaderForge.SFN_Multiply,id:2064,x:32160,y:32039,varname:node_2064,prsc:2|A-2670-OUT,B-6405-OUT;n:type:ShaderForge.SFN_ValueProperty,id:6405,x:31820,y:32165,ptovrint:False,ptlb:Pulse Power,ptin:_PulsePower,varname:node_6405,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:1;n:type:ShaderForge.SFN_Multiply,id:2670,x:31978,y:31966,varname:node_2670,prsc:2|A-2563-OUT,B-4737-OUT;proporder:7241-4023-9148-6105-8907-8047-6299-9840-6405;pass:END;sub:END;*/

Shader "Shader Forge/Grid_RoomEditor" {
    Properties {
        _Color ("Color", Color) = (0.07843138,0.3921569,0.7843137,1)
        _GridTexture ("Grid Texture", 2D) = "white" {}
        _GridSize ("Grid Size", Float ) = 12
        _OpacityFresnelExponent ("Opacity Fresnel Exponent", Float ) = 1
        _ColorFresnelExponent ("Color Fresnel Exponent", Float ) = 1
        _Speed ("Speed", Float ) = 1
        _PulseRadius1 ("Pulse Radius 1", Float ) = 0.5
        _PulseRadius2 ("Pulse Radius 2", Float ) = 0.4
        _PulsePower ("Pulse Power", Float ) = 1
        [HideInInspector]_Cutoff ("Alpha cutoff", Range(0,1)) = 0.5
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
            Blend SrcAlpha OneMinusSrcAlpha
            ZWrite Off
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_FORWARDBASE
            #include "UnityCG.cginc"
            #pragma multi_compile_fwdbase
            #pragma exclude_renderers gles3 metal d3d11_9x xbox360 xboxone ps3 ps4 psp2 
            #pragma target 3.0
            uniform float4 _TimeEditor;
            uniform float4 _Color;
            uniform sampler2D _GridTexture; uniform float4 _GridTexture_ST;
            uniform float _GridSize;
            uniform float _OpacityFresnelExponent;
            uniform float _ColorFresnelExponent;
            uniform float _Speed;
            uniform float _PulseRadius1;
            uniform float _PulseRadius2;
            uniform float _PulsePower;
            struct VertexInput {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
                float2 texcoord0 : TEXCOORD0;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float2 uv0 : TEXCOORD0;
                float4 posWorld : TEXCOORD1;
                float3 normalDir : TEXCOORD2;
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.normalDir = UnityObjectToWorldNormal(v.normal);
                o.posWorld = mul(_Object2World, v.vertex);
                o.pos = mul(UNITY_MATRIX_MVP, v.vertex );
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
                i.normalDir = normalize(i.normalDir);
/////// Vectors:
                float3 viewDirection = normalize(_WorldSpaceCameraPos.xyz - i.posWorld.xyz);
                float3 normalDirection = i.normalDir;
////// Lighting:
////// Emissive:
                float node_1144 = distance(i.uv0,float2(0.5,0.5));
                float4 node_5667 = _Time + _TimeEditor;
                float node_4737 = frac((node_5667.g*_Speed));
                float node_2339 = (1.0 - (node_1144/(_PulseRadius1+node_4737)));
                float node_6236_if_leA = step(node_2339,0.0);
                float node_6236_if_leB = step(0.0,node_2339);
                float node_9922 = 1.0;
                float node_5388 = (node_2339*2.333);
                float node_7080 = (1.0 - (node_1144/(node_4737+_PulseRadius2)));
                float node_4948_if_leA = step(node_7080,0.0);
                float node_4948_if_leB = step(0.0,node_7080);
                float node_7846 = 1.0;
                float node_6631 = (node_7080*2.333);
                float3 emissive = (((saturate(((1.0 - lerp((node_6236_if_leA*node_9922)+(node_6236_if_leB*(1.0/pow((node_5388*node_5388),1.0))),node_9922,node_6236_if_leA*node_6236_if_leB))*lerp((node_4948_if_leA*node_7846)+(node_4948_if_leB*(1.0/pow((node_6631*node_6631),2.718))),node_7846,node_4948_if_leA*node_4948_if_leB)))*node_4737)*_PulsePower)+lerp((_Color.rgb-0.6),_Color.rgb,pow(1.0-max(0,dot(normalDirection, viewDirection)),_ColorFresnelExponent)));
                float3 finalColor = emissive;
                float2 node_9350 = (i.uv0*_GridSize);
                float4 _GridTexture_var = tex2D(_GridTexture,TRANSFORM_TEX(node_9350, _GridTexture));
                float2 node_908 = (i.uv0*1.0);
                float node_5034 = node_908.r;
                float node_5080 = 2.2;
                float node_9754 = 40.0;
                float node_9868 = node_908.g;
                return fixed4(finalColor,((_GridTexture_var.r+pow(1.0-max(0,dot(normalDirection, viewDirection)),_OpacityFresnelExponent))*(saturate(((pow((node_5034*(1.0 - node_5034)),node_5080)*node_9754)*(pow((node_9868*(1.0 - node_9868)),node_5080)*node_9754)))*0.5)));
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
    CustomEditor "ShaderForgeMaterialInspector"
}
