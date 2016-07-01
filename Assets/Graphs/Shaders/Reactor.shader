// Shader created with Shader Forge v1.19 
// Shader Forge (c) Neat Corporation / Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.19;sub:START;pass:START;ps:flbk:,iptp:0,cusa:False,bamd:0,lico:1,lgpr:1,limd:0,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:False,hqlp:False,rprd:False,enco:False,rmgx:True,rpth:0,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:2,bsrc:0,bdst:0,dpts:2,wrdp:False,dith:0,rfrpo:True,rfrpn:Refraction,coma:15,ufog:True,aust:True,igpj:True,qofs:0,qpre:3,rntp:2,fgom:False,fgoc:True,fgod:False,fgor:False,fgmd:0,fgcr:0,fgcg:0,fgcb:0,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False;n:type:ShaderForge.SFN_Final,id:4795,x:32989,y:32505,varname:node_4795,prsc:2|emission-5509-OUT;n:type:ShaderForge.SFN_Color,id:797,x:32087,y:32346,ptovrint:True,ptlb:Color,ptin:_TintColor,varname:_TintColor,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0,c2:0.8344827,c3:1,c4:1;n:type:ShaderForge.SFN_TexCoord,id:1833,x:30582,y:32284,varname:node_1833,prsc:2,uv:0;n:type:ShaderForge.SFN_Multiply,id:5578,x:30765,y:32382,varname:node_5578,prsc:2|A-1833-U,B-5610-OUT;n:type:ShaderForge.SFN_Vector1,id:5610,x:30582,y:32490,varname:node_5610,prsc:2,v1:1;n:type:ShaderForge.SFN_Append,id:3442,x:30937,y:32315,varname:node_3442,prsc:2|A-5578-OUT,B-1833-V;n:type:ShaderForge.SFN_Panner,id:9247,x:31126,y:32202,varname:node_9247,prsc:2,spu:0,spv:-1|UVIN-3442-OUT,DIST-4810-OUT;n:type:ShaderForge.SFN_TexCoord,id:135,x:30580,y:32578,varname:node_135,prsc:2,uv:0;n:type:ShaderForge.SFN_Multiply,id:1465,x:30763,y:32676,varname:node_1465,prsc:2|A-135-U,B-7667-OUT;n:type:ShaderForge.SFN_Vector1,id:7667,x:30580,y:32784,varname:node_7667,prsc:2,v1:5;n:type:ShaderForge.SFN_Append,id:2442,x:30935,y:32609,varname:node_2442,prsc:2|A-1465-OUT,B-135-V;n:type:ShaderForge.SFN_Panner,id:6424,x:31164,y:32609,varname:node_6424,prsc:2,spu:0.5,spv:-0.64|UVIN-2442-OUT,DIST-4810-OUT;n:type:ShaderForge.SFN_Multiply,id:8239,x:31662,y:32447,varname:node_8239,prsc:2|A-5315-R,B-577-R;n:type:ShaderForge.SFN_TexCoord,id:7915,x:30312,y:33048,varname:node_7915,prsc:2,uv:0;n:type:ShaderForge.SFN_Multiply,id:9137,x:30716,y:33070,varname:node_9137,prsc:2|A-7915-U,B-6374-OUT;n:type:ShaderForge.SFN_OneMinus,id:6374,x:30526,y:33131,varname:node_6374,prsc:2|IN-7915-U;n:type:ShaderForge.SFN_Add,id:935,x:30960,y:33204,varname:node_935,prsc:2|A-7915-V,B-9137-OUT;n:type:ShaderForge.SFN_OneMinus,id:360,x:30540,y:32959,varname:node_360,prsc:2|IN-7915-V;n:type:ShaderForge.SFN_Multiply,id:8747,x:31180,y:33049,varname:node_8747,prsc:2|A-935-OUT,B-9137-OUT;n:type:ShaderForge.SFN_Multiply,id:8048,x:31380,y:33049,varname:node_8048,prsc:2|A-8747-OUT,B-9639-OUT;n:type:ShaderForge.SFN_Vector1,id:9639,x:31180,y:33189,varname:node_9639,prsc:2,v1:3;n:type:ShaderForge.SFN_Clamp01,id:7875,x:31564,y:33049,varname:node_7875,prsc:2|IN-8048-OUT;n:type:ShaderForge.SFN_Multiply,id:5483,x:32075,y:32686,varname:node_5483,prsc:2|A-6317-OUT,B-2042-OUT;n:type:ShaderForge.SFN_TexCoord,id:5979,x:30577,y:31995,varname:node_5979,prsc:2,uv:0;n:type:ShaderForge.SFN_Multiply,id:9894,x:30760,y:32093,varname:node_9894,prsc:2|A-5979-U,B-6009-OUT;n:type:ShaderForge.SFN_Vector1,id:6009,x:30577,y:32201,varname:node_6009,prsc:2,v1:0.5;n:type:ShaderForge.SFN_Append,id:9638,x:30932,y:32026,varname:node_9638,prsc:2|A-9894-OUT,B-5979-V;n:type:ShaderForge.SFN_Panner,id:5667,x:31161,y:32026,varname:node_5667,prsc:2,spu:0,spv:-0.3|UVIN-9638-OUT,DIST-4810-OUT;n:type:ShaderForge.SFN_Add,id:6317,x:31839,y:32382,varname:node_6317,prsc:2|A-7042-OUT,B-8239-OUT;n:type:ShaderForge.SFN_Tex2dAsset,id:3204,x:31137,y:32396,ptovrint:False,ptlb:Clouds,ptin:_Clouds,varname:node_3204,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:05419124b56c98846b3d53d8a1dc476d,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Tex2d,id:1253,x:31390,y:32073,varname:node_1253,prsc:2,tex:05419124b56c98846b3d53d8a1dc476d,ntxv:0,isnm:False|UVIN-5667-UVOUT,TEX-3204-TEX;n:type:ShaderForge.SFN_Tex2d,id:5315,x:31390,y:32306,varname:node_5315,prsc:2,tex:05419124b56c98846b3d53d8a1dc476d,ntxv:0,isnm:False|UVIN-9247-UVOUT,TEX-3204-TEX;n:type:ShaderForge.SFN_Tex2d,id:577,x:31390,y:32537,varname:node_577,prsc:2,tex:05419124b56c98846b3d53d8a1dc476d,ntxv:0,isnm:False|UVIN-6424-UVOUT,TEX-3204-TEX;n:type:ShaderForge.SFN_Power,id:5389,x:31121,y:32868,varname:node_5389,prsc:2|VAL-360-OUT,EXP-998-OUT;n:type:ShaderForge.SFN_Vector1,id:998,x:31121,y:32991,varname:node_998,prsc:2,v1:5;n:type:ShaderForge.SFN_Clamp01,id:849,x:31299,y:32868,varname:node_849,prsc:2|IN-5389-OUT;n:type:ShaderForge.SFN_Multiply,id:2042,x:31797,y:32866,varname:node_2042,prsc:2|A-1338-OUT,B-7875-OUT;n:type:ShaderForge.SFN_OneMinus,id:1338,x:31486,y:32868,varname:node_1338,prsc:2|IN-849-OUT;n:type:ShaderForge.SFN_Multiply,id:7042,x:31630,y:32172,varname:node_7042,prsc:2|A-1023-OUT,B-1253-RGB;n:type:ShaderForge.SFN_Vector1,id:1023,x:31619,y:32093,varname:node_1023,prsc:2,v1:2;n:type:ShaderForge.SFN_Add,id:4112,x:32270,y:32769,varname:node_4112,prsc:2|A-5483-OUT,B-4707-OUT;n:type:ShaderForge.SFN_Vector1,id:4707,x:32075,y:32863,varname:node_4707,prsc:2,v1:0.5;n:type:ShaderForge.SFN_Lerp,id:1045,x:32505,y:32677,varname:node_1045,prsc:2|A-6181-OUT,B-797-RGB,T-4112-OUT;n:type:ShaderForge.SFN_Subtract,id:6181,x:32087,y:32491,varname:node_6181,prsc:2|A-797-RGB,B-57-OUT;n:type:ShaderForge.SFN_Vector1,id:57,x:32087,y:32604,varname:node_57,prsc:2,v1:0.6;n:type:ShaderForge.SFN_Multiply,id:5509,x:32729,y:32606,varname:node_5509,prsc:2|A-5483-OUT,B-1045-OUT;n:type:ShaderForge.SFN_Time,id:6659,x:30050,y:32334,varname:node_6659,prsc:2;n:type:ShaderForge.SFN_Multiply,id:4810,x:30270,y:32409,varname:node_4810,prsc:2|A-6659-T,B-8267-OUT;n:type:ShaderForge.SFN_ValueProperty,id:8267,x:30032,y:32512,ptovrint:False,ptlb:Speed,ptin:_Speed,varname:node_8267,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:-3;proporder:797-3204-8267;pass:END;sub:END;*/

Shader "Shader Forge/Reactor" {
    Properties {
        _TintColor ("Color", Color) = (0,0.8344827,1,1)
        _Clouds ("Clouds", 2D) = "white" {}
        _Speed ("Speed", Float ) = -3
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
            Cull Off
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
            uniform float4 _TintColor;
            uniform sampler2D _Clouds; uniform float4 _Clouds_ST;
            uniform float _Speed;
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
////// Lighting:
////// Emissive:
                float4 node_6659 = _Time + _TimeEditor;
                float node_4810 = (node_6659.g*_Speed);
                float2 node_5667 = (float2((i.uv0.r*0.5),i.uv0.g)+node_4810*float2(0,-0.3));
                float4 node_1253 = tex2D(_Clouds,TRANSFORM_TEX(node_5667, _Clouds));
                float2 node_9247 = (float2((i.uv0.r*1.0),i.uv0.g)+node_4810*float2(0,-1));
                float4 node_5315 = tex2D(_Clouds,TRANSFORM_TEX(node_9247, _Clouds));
                float2 node_6424 = (float2((i.uv0.r*5.0),i.uv0.g)+node_4810*float2(0.5,-0.64));
                float4 node_577 = tex2D(_Clouds,TRANSFORM_TEX(node_6424, _Clouds));
                float node_9137 = (i.uv0.r*(1.0 - i.uv0.r));
                float3 node_5483 = (((2.0*node_1253.rgb)+(node_5315.r*node_577.r))*((1.0 - saturate(pow((1.0 - i.uv0.g),5.0)))*saturate((((i.uv0.g+node_9137)*node_9137)*3.0))));
                float3 emissive = (node_5483*lerp((_TintColor.rgb-0.6),_TintColor.rgb,(node_5483+0.5)));
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
