// Shader created with Shader Forge v1.19 
// Shader Forge (c) Neat Corporation / Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.19;sub:START;pass:START;ps:flbk:,iptp:0,cusa:False,bamd:0,lico:1,lgpr:1,limd:0,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:False,hqlp:False,rprd:False,enco:False,rmgx:True,rpth:0,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:0,bsrc:0,bdst:0,dpts:2,wrdp:False,dith:0,rfrpo:True,rfrpn:Refraction,coma:15,ufog:True,aust:True,igpj:True,qofs:0,qpre:3,rntp:2,fgom:False,fgoc:True,fgod:False,fgor:False,fgmd:0,fgcr:0,fgcg:0,fgcb:0,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False;n:type:ShaderForge.SFN_Final,id:4795,x:32724,y:32693,varname:node_4795,prsc:2|emission-2393-OUT;n:type:ShaderForge.SFN_Multiply,id:2393,x:32514,y:32793,varname:node_2393,prsc:2|A-5176-OUT,B-2053-RGB,C-797-RGB,D-2705-OUT;n:type:ShaderForge.SFN_VertexColor,id:2053,x:32235,y:32772,varname:node_2053,prsc:2;n:type:ShaderForge.SFN_Color,id:797,x:32235,y:32930,ptovrint:True,ptlb:Color,ptin:_TintColor,varname:_TintColor,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0.07586217,c2:1,c3:0,c4:1;n:type:ShaderForge.SFN_Vector1,id:9248,x:31834,y:33212,varname:node_9248,prsc:2,v1:1;n:type:ShaderForge.SFN_Sin,id:2999,x:31834,y:32991,varname:node_2999,prsc:2|IN-7225-OUT;n:type:ShaderForge.SFN_Multiply,id:2705,x:32297,y:33132,varname:node_2705,prsc:2|A-3184-OUT,B-7749-OUT;n:type:ShaderForge.SFN_Time,id:1260,x:31458,y:32881,varname:node_1260,prsc:2;n:type:ShaderForge.SFN_Add,id:3184,x:32055,y:33040,varname:node_3184,prsc:2|A-2999-OUT,B-9248-OUT;n:type:ShaderForge.SFN_Vector1,id:7749,x:32013,y:33259,varname:node_7749,prsc:2,v1:0.5;n:type:ShaderForge.SFN_Tex2d,id:5309,x:31801,y:32553,ptovrint:False,ptlb:Blur,ptin:_Blur,varname:node_5309,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:1890057c282c74a4f89d1585bd849490,ntxv:0,isnm:False;n:type:ShaderForge.SFN_OneMinus,id:3932,x:32022,y:32570,varname:node_3932,prsc:2|IN-5309-R;n:type:ShaderForge.SFN_Subtract,id:5176,x:32235,y:32622,varname:node_5176,prsc:2|A-3932-OUT,B-8243-OUT;n:type:ShaderForge.SFN_ValueProperty,id:8243,x:32022,y:32758,ptovrint:False,ptlb:Thickness,ptin:_Thickness,varname:node_8243,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:-0.05;n:type:ShaderForge.SFN_Multiply,id:7225,x:31632,y:32991,varname:node_7225,prsc:2|A-1260-TDB,B-7192-OUT;n:type:ShaderForge.SFN_ValueProperty,id:7192,x:31407,y:33087,ptovrint:False,ptlb:Speed,ptin:_Speed,varname:node_7192,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:1;proporder:797-5309-8243-7192;pass:END;sub:END;*/

Shader "Shader Forge/Tuto" {
    Properties {
        _TintColor ("Color", Color) = (0.07586217,1,0,1)
        _Blur ("Blur", 2D) = "white" {}
        _Thickness ("Thickness", Float ) = -0.05
        _Speed ("Speed", Float ) = 1
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
            uniform float4 _TintColor;
            uniform sampler2D _Blur; uniform float4 _Blur_ST;
            uniform float _Thickness;
            uniform float _Speed;
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
                float4 _Blur_var = tex2D(_Blur,TRANSFORM_TEX(i.uv0, _Blur));
                float4 node_1260 = _Time + _TimeEditor;
                float3 emissive = (((1.0 - _Blur_var.r)-_Thickness)*i.vertexColor.rgb*_TintColor.rgb*((sin((node_1260.b*_Speed))+1.0)*0.5));
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
