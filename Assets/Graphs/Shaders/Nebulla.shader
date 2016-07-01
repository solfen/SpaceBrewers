// Shader created with Shader Forge v1.19 
// Shader Forge (c) Neat Corporation / Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.19;sub:START;pass:START;ps:flbk:,iptp:0,cusa:False,bamd:0,lico:1,lgpr:1,limd:0,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:False,hqlp:False,rprd:False,enco:False,rmgx:True,rpth:0,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:2,bsrc:0,bdst:0,dpts:2,wrdp:False,dith:0,rfrpo:True,rfrpn:Refraction,coma:15,ufog:True,aust:True,igpj:True,qofs:0,qpre:3,rntp:2,fgom:False,fgoc:True,fgod:False,fgor:False,fgmd:0,fgcr:0,fgcg:0,fgcb:0,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False;n:type:ShaderForge.SFN_Final,id:4795,x:32724,y:32693,varname:node_4795,prsc:2|emission-2393-OUT;n:type:ShaderForge.SFN_Tex2d,id:6074,x:31701,y:32380,ptovrint:False,ptlb:MainTex,ptin:_MainTex,varname:_MainTex,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:127ec6ec45b705f468598ef787a04728,ntxv:0,isnm:False|UVIN-9545-UVOUT;n:type:ShaderForge.SFN_Multiply,id:2393,x:32495,y:32793,varname:node_2393,prsc:2|A-3279-OUT,B-2053-RGB,C-797-RGB,D-9248-OUT;n:type:ShaderForge.SFN_VertexColor,id:2053,x:32226,y:32875,varname:node_2053,prsc:2;n:type:ShaderForge.SFN_Color,id:797,x:32226,y:33033,ptovrint:True,ptlb:Color,ptin:_TintColor,varname:_TintColor,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:1,c2:1,c3:1,c4:1;n:type:ShaderForge.SFN_Vector1,id:9248,x:32226,y:33184,varname:node_9248,prsc:2,v1:1;n:type:ShaderForge.SFN_TexCoord,id:6011,x:30719,y:32141,varname:node_6011,prsc:2,uv:0;n:type:ShaderForge.SFN_Multiply,id:6717,x:30933,y:32237,varname:node_6717,prsc:2|A-6011-U,B-2207-OUT;n:type:ShaderForge.SFN_ValueProperty,id:2207,x:30719,y:32373,ptovrint:False,ptlb:Tiling U,ptin:_TilingU,varname:node_2207,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:1;n:type:ShaderForge.SFN_Multiply,id:2598,x:30933,y:32385,varname:node_2598,prsc:2|A-6011-V,B-8474-OUT;n:type:ShaderForge.SFN_ValueProperty,id:8474,x:30719,y:32516,ptovrint:False,ptlb:Tiling V,ptin:_TilingV,varname:node_8474,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:1;n:type:ShaderForge.SFN_Append,id:9301,x:31145,y:32312,varname:node_9301,prsc:2|A-6717-OUT,B-2598-OUT;n:type:ShaderForge.SFN_Multiply,id:3279,x:32012,y:32555,varname:node_3279,prsc:2|A-6074-RGB,B-5889-OUT;n:type:ShaderForge.SFN_TexCoord,id:8849,x:30978,y:32736,varname:node_8849,prsc:2,uv:0;n:type:ShaderForge.SFN_Multiply,id:5418,x:31346,y:32775,varname:node_5418,prsc:2|A-8849-V,B-384-OUT;n:type:ShaderForge.SFN_OneMinus,id:384,x:31169,y:32833,varname:node_384,prsc:2|IN-8849-V;n:type:ShaderForge.SFN_Multiply,id:7010,x:31533,y:32775,varname:node_7010,prsc:2|A-5418-OUT,B-9427-OUT;n:type:ShaderForge.SFN_Vector1,id:9427,x:31494,y:32939,varname:node_9427,prsc:2,v1:3.5;n:type:ShaderForge.SFN_Clamp01,id:5889,x:31701,y:32775,varname:node_5889,prsc:2|IN-7010-OUT;n:type:ShaderForge.SFN_Panner,id:9545,x:31449,y:32380,varname:node_9545,prsc:2,spu:1,spv:0|UVIN-9301-OUT,DIST-2024-OUT;n:type:ShaderForge.SFN_Time,id:4945,x:31099,y:32466,varname:node_4945,prsc:2;n:type:ShaderForge.SFN_Multiply,id:2024,x:31273,y:32511,varname:node_2024,prsc:2|A-4945-TSL,B-4937-OUT;n:type:ShaderForge.SFN_ValueProperty,id:4937,x:31099,y:32625,ptovrint:False,ptlb:Speed,ptin:_Speed,varname:node_4937,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:0.1;proporder:6074-797-2207-8474-4937;pass:END;sub:END;*/

Shader "Shader Forge/Nebulla" {
    Properties {
        _MainTex ("MainTex", 2D) = "white" {}
        _TintColor ("Color", Color) = (1,1,1,1)
        _TilingU ("Tiling U", Float ) = 1
        _TilingV ("Tiling V", Float ) = 1
        _Speed ("Speed", Float ) = 0.1
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
            uniform sampler2D _MainTex; uniform float4 _MainTex_ST;
            uniform float4 _TintColor;
            uniform float _TilingU;
            uniform float _TilingV;
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
            float4 frag(VertexOutput i, float facing : VFACE) : COLOR {
                float isFrontFace = ( facing >= 0 ? 1 : 0 );
                float faceSign = ( facing >= 0 ? 1 : -1 );
/////// Vectors:
////// Lighting:
////// Emissive:
                float4 node_4945 = _Time + _TimeEditor;
                float2 node_9545 = (float2((i.uv0.r*_TilingU),(i.uv0.g*_TilingV))+(node_4945.r*_Speed)*float2(1,0));
                float4 _MainTex_var = tex2D(_MainTex,TRANSFORM_TEX(node_9545, _MainTex));
                float3 emissive = ((_MainTex_var.rgb*saturate(((i.uv0.g*(1.0 - i.uv0.g))*3.5)))*i.vertexColor.rgb*_TintColor.rgb*1.0);
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
