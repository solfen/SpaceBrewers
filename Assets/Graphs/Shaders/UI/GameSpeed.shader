// Shader created with Shader Forge v1.19 
// Shader Forge (c) Neat Corporation / Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.19;sub:START;pass:START;ps:flbk:,iptp:1,cusa:True,bamd:0,lico:1,lgpr:1,limd:0,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:False,hqlp:False,rprd:False,enco:False,rmgx:True,rpth:0,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:True,tesm:0,olmd:1,culm:2,bsrc:0,bdst:7,dpts:2,wrdp:True,dith:0,rfrpo:True,rfrpn:Refraction,coma:15,ufog:False,aust:True,igpj:False,qofs:0,qpre:2,rntp:3,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5,fgcg:0.5,fgcb:0.5,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False;n:type:ShaderForge.SFN_Final,id:1873,x:33229,y:32719,varname:node_1873,prsc:2|emission-3193-RGB,clip-4770-OUT;n:type:ShaderForge.SFN_TexCoord,id:1999,x:31444,y:33134,varname:node_1999,prsc:2,uv:0;n:type:ShaderForge.SFN_Length,id:53,x:31772,y:33134,varname:node_53,prsc:2|IN-9402-OUT;n:type:ShaderForge.SFN_RemapRange,id:9402,x:31607,y:33134,varname:node_9402,prsc:2,frmn:0,frmx:1,tomn:-1,tomx:1|IN-1999-UVOUT;n:type:ShaderForge.SFN_OneMinus,id:3675,x:31953,y:33134,varname:node_3675,prsc:2|IN-53-OUT;n:type:ShaderForge.SFN_Ceil,id:4711,x:32222,y:33121,varname:node_4711,prsc:2|IN-3675-OUT;n:type:ShaderForge.SFN_Subtract,id:5864,x:31936,y:33372,varname:node_5864,prsc:2|A-3675-OUT,B-6937-OUT;n:type:ShaderForge.SFN_Vector1,id:6937,x:31755,y:33464,varname:node_6937,prsc:2,v1:0.1;n:type:ShaderForge.SFN_OneMinus,id:5197,x:32107,y:33327,varname:node_5197,prsc:2|IN-5864-OUT;n:type:ShaderForge.SFN_Multiply,id:7268,x:32504,y:33145,varname:node_7268,prsc:2|A-4711-OUT,B-2803-OUT;n:type:ShaderForge.SFN_Floor,id:2803,x:32287,y:33265,varname:node_2803,prsc:2|IN-5197-OUT;n:type:ShaderForge.SFN_TexCoord,id:7811,x:31440,y:32774,varname:node_7811,prsc:2,uv:0;n:type:ShaderForge.SFN_ArcTan2,id:5588,x:31891,y:32776,varname:node_5588,prsc:2,attp:2|A-9320-OUT,B-706-OUT;n:type:ShaderForge.SFN_RemapRange,id:706,x:31677,y:32675,varname:node_706,prsc:2,frmn:0,frmx:1,tomn:-1,tomx:1|IN-7811-U;n:type:ShaderForge.SFN_RemapRange,id:9320,x:31677,y:32860,varname:node_9320,prsc:2,frmn:0,frmx:1,tomn:-1,tomx:1|IN-7811-V;n:type:ShaderForge.SFN_Multiply,id:4770,x:32734,y:33037,varname:node_4770,prsc:2|A-3687-OUT,B-7268-OUT;n:type:ShaderForge.SFN_Ceil,id:3687,x:32463,y:32893,varname:node_3687,prsc:2|IN-9767-OUT;n:type:ShaderForge.SFN_Add,id:9767,x:32225,y:32753,varname:node_9767,prsc:2|A-9150-OUT,B-5588-OUT;n:type:ShaderForge.SFN_Slider,id:6420,x:31520,y:32521,ptovrint:False,ptlb:Value,ptin:_Value,varname:node_6420,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:1,max:1;n:type:ShaderForge.SFN_Vector1,id:629,x:31858,y:32414,varname:node_629,prsc:2,v1:-1;n:type:ShaderForge.SFN_Add,id:9150,x:31956,y:32535,varname:node_9150,prsc:2|A-629-OUT,B-6420-OUT;n:type:ShaderForge.SFN_Color,id:3193,x:32832,y:32746,ptovrint:False,ptlb:Color,ptin:_Color,varname:node_3193,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0,c2:0.751724,c3:1,c4:1;proporder:3193-6420;pass:END;sub:END;*/

Shader "Shader Forge/GameSpeed" {
    Properties {
        _Color ("Color", Color) = (0,0.751724,1,1)
        _Value ("Value", Range(0, 1)) = 1
        [HideInInspector]_Cutoff ("Alpha cutoff", Range(0,1)) = 0.5
        [MaterialToggle] PixelSnap ("Pixel snap", Float) = 0
    }
    SubShader {
        Tags {
            "Queue"="AlphaTest"
            "RenderType"="TransparentCutout"
            "CanUseSpriteAtlas"="True"
            "PreviewType"="Plane"
        }
        Pass {
            Name "FORWARD"
            Tags {
                "LightMode"="ForwardBase"
            }
            Blend One OneMinusSrcAlpha
            Cull Off
            
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_FORWARDBASE
            #pragma multi_compile _ PIXELSNAP_ON
            #include "UnityCG.cginc"
            #pragma multi_compile_fwdbase_fullshadows
            #pragma exclude_renderers gles3 metal d3d11_9x xbox360 xboxone ps3 ps4 psp2 
            #pragma target 3.0
            uniform float _Value;
            uniform float4 _Color;
            struct VertexInput {
                float4 vertex : POSITION;
                float2 texcoord0 : TEXCOORD0;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float2 uv0 : TEXCOORD0;
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.pos = mul(UNITY_MATRIX_MVP, v.vertex );
                #ifdef PIXELSNAP_ON
                    o.pos = UnityPixelSnap(o.pos);
                #endif
                return o;
            }
            float4 frag(VertexOutput i, float facing : VFACE) : COLOR {
                float isFrontFace = ( facing >= 0 ? 1 : 0 );
                float faceSign = ( facing >= 0 ? 1 : -1 );
/////// Vectors:
                float node_3675 = (1.0 - length((i.uv0*2.0+-1.0)));
                clip((ceil((((-1.0)+_Value)+((atan2((i.uv0.g*2.0+-1.0),(i.uv0.r*2.0+-1.0))/6.28318530718)+0.5)))*(ceil(node_3675)*floor((1.0 - (node_3675-0.1))))) - 0.5);
////// Lighting:
////// Emissive:
                float3 emissive = _Color.rgb;
                float3 finalColor = emissive;
                return fixed4(finalColor,1);
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
            #pragma multi_compile _ PIXELSNAP_ON
            #include "UnityCG.cginc"
            #include "Lighting.cginc"
            #pragma fragmentoption ARB_precision_hint_fastest
            #pragma multi_compile_shadowcaster
            #pragma exclude_renderers gles3 metal d3d11_9x xbox360 xboxone ps3 ps4 psp2 
            #pragma target 3.0
            uniform float _Value;
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
                #ifdef PIXELSNAP_ON
                    o.pos = UnityPixelSnap(o.pos);
                #endif
                TRANSFER_SHADOW_CASTER(o)
                return o;
            }
            float4 frag(VertexOutput i, float facing : VFACE) : COLOR {
                float isFrontFace = ( facing >= 0 ? 1 : 0 );
                float faceSign = ( facing >= 0 ? 1 : -1 );
/////// Vectors:
                float node_3675 = (1.0 - length((i.uv0*2.0+-1.0)));
                clip((ceil((((-1.0)+_Value)+((atan2((i.uv0.g*2.0+-1.0),(i.uv0.r*2.0+-1.0))/6.28318530718)+0.5)))*(ceil(node_3675)*floor((1.0 - (node_3675-0.1))))) - 0.5);
                SHADOW_CASTER_FRAGMENT(i)
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
    CustomEditor "ShaderForgeMaterialInspector"
}
