// Shader created with Shader Forge v1.19 
// Shader Forge (c) Neat Corporation / Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.19;sub:START;pass:START;ps:flbk:,iptp:0,cusa:False,bamd:0,lico:1,lgpr:1,limd:0,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:False,hqlp:False,rprd:False,enco:False,rmgx:True,rpth:0,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:2,bsrc:0,bdst:1,dpts:2,wrdp:True,dith:0,rfrpo:True,rfrpn:Refraction,coma:15,ufog:True,aust:True,igpj:False,qofs:0,qpre:2,rntp:3,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5,fgcg:0.5,fgcb:0.5,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False;n:type:ShaderForge.SFN_Final,id:2865,x:32719,y:32712,varname:node_2865,prsc:2|diff-7736-RGB,spec-5649-OUT,gloss-5649-OUT,emission-4922-OUT,clip-7736-A;n:type:ShaderForge.SFN_Tex2d,id:7736,x:31461,y:32953,ptovrint:True,ptlb:Base Color,ptin:_MainTex,varname:_MainTex,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Vector1,id:5649,x:32398,y:32636,varname:node_5649,prsc:2,v1:0;n:type:ShaderForge.SFN_Multiply,id:8052,x:31747,y:32898,varname:node_8052,prsc:2|A-6360-OUT,B-7736-RGB;n:type:ShaderForge.SFN_ValueProperty,id:6360,x:31533,y:32835,ptovrint:False,ptlb:Glow,ptin:_Glow,varname:node_6360,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:5;n:type:ShaderForge.SFN_Multiply,id:9287,x:31994,y:32864,varname:node_9287,prsc:2|A-9099-RGB,B-8052-OUT;n:type:ShaderForge.SFN_Color,id:9099,x:31787,y:32735,ptovrint:False,ptlb:Emission Color,ptin:_EmissionColor,varname:node_9099,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0.5,c2:0.5,c3:0.5,c4:1;n:type:ShaderForge.SFN_Panner,id:2679,x:31983,y:33154,varname:node_2679,prsc:2,spu:1,spv:0|UVIN-7387-OUT,DIST-5261-OUT;n:type:ShaderForge.SFN_Tex2d,id:53,x:32183,y:33070,ptovrint:False,ptlb:Ramp,ptin:_Ramp,varname:node_53,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,ntxv:0,isnm:False|UVIN-2679-UVOUT;n:type:ShaderForge.SFN_TexCoord,id:3131,x:31279,y:33144,varname:node_3131,prsc:2,uv:0;n:type:ShaderForge.SFN_Lerp,id:4922,x:32473,y:32834,varname:node_4922,prsc:2|A-7231-OUT,B-9287-OUT,T-6223-OUT;n:type:ShaderForge.SFN_Vector3,id:4992,x:31965,y:32599,varname:node_4992,prsc:2,v1:0.1252535,v2:0,v3:0.1911765;n:type:ShaderForge.SFN_Multiply,id:7387,x:31536,y:33215,varname:node_7387,prsc:2|A-3131-UVOUT,B-2747-OUT;n:type:ShaderForge.SFN_Vector1,id:2747,x:31349,y:33307,varname:node_2747,prsc:2,v1:0.001;n:type:ShaderForge.SFN_Time,id:841,x:31488,y:33393,varname:node_841,prsc:2;n:type:ShaderForge.SFN_Multiply,id:5261,x:31745,y:33373,varname:node_5261,prsc:2|A-841-T,B-3244-OUT;n:type:ShaderForge.SFN_Divide,id:9148,x:32187,y:32733,varname:node_9148,prsc:2|A-997-OUT,B-9287-OUT;n:type:ShaderForge.SFN_Vector1,id:997,x:31994,y:32733,varname:node_997,prsc:2,v1:2;n:type:ShaderForge.SFN_OneMinus,id:7231,x:32335,y:32733,varname:node_7231,prsc:2|IN-9148-OUT;n:type:ShaderForge.SFN_Floor,id:6223,x:32298,y:32948,varname:node_6223,prsc:2|IN-53-RGB;n:type:ShaderForge.SFN_ValueProperty,id:3244,x:31488,y:33582,ptovrint:False,ptlb:Flicker Speed,ptin:_FlickerSpeed,varname:node_3244,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:0.25;proporder:7736-6360-9099-53-3244;pass:END;sub:END;*/

Shader "Shader Forge/Neons" {
    Properties {
        _MainTex ("Base Color", 2D) = "white" {}
        _Glow ("Glow", Float ) = 5
        _EmissionColor ("Emission Color", Color) = (0.5,0.5,0.5,1)
        _Ramp ("Ramp", 2D) = "white" {}
        _FlickerSpeed ("Flicker Speed", Float ) = 0.25
        [HideInInspector]_Cutoff ("Alpha cutoff", Range(0,1)) = 0.5
    }
    SubShader {
        Tags {
            "Queue"="AlphaTest"
            "RenderType"="TransparentCutout"
        }
        Pass {
            Name "FORWARD"
            Tags {
                "LightMode"="ForwardBase"
            }
            Cull Off
            
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_FORWARDBASE
            #include "UnityCG.cginc"
            #pragma multi_compile_fwdbase_fullshadows
            #pragma multi_compile_fog
            #pragma exclude_renderers gles3 metal d3d11_9x xbox360 xboxone ps3 ps4 psp2 
            #pragma target 3.0
            uniform float4 _TimeEditor;
            uniform sampler2D _MainTex; uniform float4 _MainTex_ST;
            uniform float _Glow;
            uniform float4 _EmissionColor;
            uniform sampler2D _Ramp; uniform float4 _Ramp_ST;
            uniform float _FlickerSpeed;
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
            float4 frag(VertexOutput i, float facing : VFACE) : COLOR {
                float isFrontFace = ( facing >= 0 ? 1 : 0 );
                float faceSign = ( facing >= 0 ? 1 : -1 );
/////// Vectors:
                float4 _MainTex_var = tex2D(_MainTex,TRANSFORM_TEX(i.uv0, _MainTex));
                clip(_MainTex_var.a - 0.5);
////// Lighting:
////// Emissive:
                float3 node_9287 = (_EmissionColor.rgb*(_Glow*_MainTex_var.rgb));
                float4 node_841 = _Time + _TimeEditor;
                float2 node_2679 = ((i.uv0*0.001)+(node_841.g*_FlickerSpeed)*float2(1,0));
                float4 _Ramp_var = tex2D(_Ramp,TRANSFORM_TEX(node_2679, _Ramp));
                float3 emissive = lerp((1.0 - (2.0/node_9287)),node_9287,floor(_Ramp_var.rgb));
                float3 finalColor = emissive;
                fixed4 finalRGBA = fixed4(finalColor,1);
                UNITY_APPLY_FOG(i.fogCoord, finalRGBA);
                return finalRGBA;
            }
            ENDCG
        }
        Pass {
            Name "ShadowCaster"
            Tags {
                "LightMode"="ShadowCaster"
            }
            Offset 1, 1
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_SHADOWCASTER
            #include "UnityCG.cginc"
            #include "Lighting.cginc"
            #pragma fragmentoption ARB_precision_hint_fastest
            #pragma multi_compile_shadowcaster
            #pragma multi_compile_fog
            #pragma exclude_renderers gles3 metal d3d11_9x xbox360 xboxone ps3 ps4 psp2 
            #pragma target 3.0
            uniform sampler2D _MainTex; uniform float4 _MainTex_ST;
            struct VertexInput {
                float4 vertex : POSITION;
                float2 texcoord0 : TEXCOORD0;
            };
            struct VertexOutput {
                V2F_SHADOW_CASTER;
                float2 uv0 : TEXCOORD1;
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.pos = mul(UNITY_MATRIX_MVP, v.vertex );
                TRANSFER_SHADOW_CASTER(o)
                return o;
            }
            float4 frag(VertexOutput i, float facing : VFACE) : COLOR {
                float isFrontFace = ( facing >= 0 ? 1 : 0 );
                float faceSign = ( facing >= 0 ? 1 : -1 );
/////// Vectors:
                float4 _MainTex_var = tex2D(_MainTex,TRANSFORM_TEX(i.uv0, _MainTex));
                clip(_MainTex_var.a - 0.5);
                SHADOW_CASTER_FRAGMENT(i)
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
    CustomEditor "ShaderForgeMaterialInspector"
}
