// Shader created with Shader Forge v1.19 
// Shader Forge (c) Neat Corporation / Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.19;sub:START;pass:START;ps:flbk:,iptp:1,cusa:True,bamd:0,lico:1,lgpr:1,limd:0,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:False,hqlp:False,rprd:False,enco:False,rmgx:True,rpth:0,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:True,tesm:0,olmd:1,culm:2,bsrc:0,bdst:0,dpts:2,wrdp:False,dith:0,rfrpo:True,rfrpn:Refraction,coma:15,ufog:False,aust:True,igpj:True,qofs:0,qpre:3,rntp:2,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5,fgcg:0.5,fgcb:0.5,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False;n:type:ShaderForge.SFN_Final,id:1873,x:33548,y:32711,varname:node_1873,prsc:2|emission-1749-OUT,alpha-603-OUT;n:type:ShaderForge.SFN_VertexColor,id:5376,x:32389,y:33036,varname:node_5376,prsc:2;n:type:ShaderForge.SFN_Multiply,id:1749,x:33344,y:32810,cmnt:Premultiply Alpha,varname:node_1749,prsc:2|A-868-OUT,B-603-OUT;n:type:ShaderForge.SFN_Multiply,id:603,x:33131,y:32984,cmnt:A,varname:node_603,prsc:2|A-7704-A,B-5376-A;n:type:ShaderForge.SFN_Multiply,id:9134,x:31877,y:32452,varname:node_9134,prsc:2|A-7968-OUT,B-7560-OUT;n:type:ShaderForge.SFN_Sin,id:3179,x:32050,y:32452,varname:node_3179,prsc:2|IN-9134-OUT;n:type:ShaderForge.SFN_Panner,id:2542,x:31318,y:32407,varname:node_2542,prsc:2,spu:0.04,spv:-0.04;n:type:ShaderForge.SFN_ComponentMask,id:8650,x:31512,y:32407,varname:node_8650,prsc:2,cc1:0,cc2:1,cc3:-1,cc4:-1|IN-2542-UVOUT;n:type:ShaderForge.SFN_Clamp01,id:4091,x:32213,y:32452,varname:node_4091,prsc:2|IN-3179-OUT;n:type:ShaderForge.SFN_SwitchProperty,id:7968,x:31705,y:32384,ptovrint:False,ptlb:Horizontal,ptin:_Horizontal,varname:node_7060,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,on:True|A-8650-R,B-8650-G;n:type:ShaderForge.SFN_ValueProperty,id:7560,x:31705,y:32558,ptovrint:False,ptlb:Lines finess,ptin:_Linesfiness,varname:node_8693,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:100;n:type:ShaderForge.SFN_Add,id:2524,x:32668,y:32703,varname:node_2524,prsc:2|A-9252-OUT,B-7704-RGB;n:type:ShaderForge.SFN_Tex2d,id:7704,x:32143,y:32817,ptovrint:False,ptlb:MainTex,ptin:_MainTex,varname:node_7704,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:1d225b7575a8b2441b71c0793919fb71,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Multiply,id:9252,x:32448,y:32599,varname:node_9252,prsc:2|A-4091-OUT,B-7704-RGB;n:type:ShaderForge.SFN_Multiply,id:6547,x:32706,y:32471,varname:node_6547,prsc:2|A-4202-OUT,B-2524-OUT;n:type:ShaderForge.SFN_ValueProperty,id:4202,x:32683,y:32382,ptovrint:False,ptlb:Opacity,ptin:_Opacity,varname:node_4202,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:0.7;n:type:ShaderForge.SFN_Multiply,id:868,x:33100,y:32785,varname:node_868,prsc:2|A-6547-OUT,B-5376-RGB;proporder:7704-7968-7560-4202;pass:END;sub:END;*/

Shader "Shader Forge/InfoSlider" {
    Properties {
        _MainTex ("MainTex", 2D) = "white" {}
        [MaterialToggle] _Horizontal ("Horizontal", Float ) = 0
        _Linesfiness ("Lines finess", Float ) = 100
        _Opacity ("Opacity", Float ) = 0.7
        [HideInInspector]_Cutoff ("Alpha cutoff", Range(0,1)) = 0.5
        [MaterialToggle] PixelSnap ("Pixel snap", Float) = 0
    }
    SubShader {
        Tags {
            "IgnoreProjector"="True"
            "Queue"="Transparent"
            "RenderType"="Transparent"
            "CanUseSpriteAtlas"="True"
            "PreviewType"="Plane"
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
            #pragma multi_compile _ PIXELSNAP_ON
            #include "UnityCG.cginc"
            #pragma multi_compile_fwdbase
            #pragma exclude_renderers gles3 metal d3d11_9x xbox360 xboxone ps3 ps4 psp2 
            #pragma target 3.0
            uniform float4 _TimeEditor;
            uniform fixed _Horizontal;
            uniform float _Linesfiness;
            uniform sampler2D _MainTex; uniform float4 _MainTex_ST;
            uniform float _Opacity;
            struct VertexInput {
                float4 vertex : POSITION;
                float2 texcoord0 : TEXCOORD0;
                float4 vertexColor : COLOR;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float2 uv0 : TEXCOORD0;
                float4 vertexColor : COLOR;
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.vertexColor = v.vertexColor;
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
////// Lighting:
////// Emissive:
                float4 node_5548 = _Time + _TimeEditor;
                float2 node_8650 = (i.uv0+node_5548.g*float2(0.04,-0.04)).rg;
                float4 _MainTex_var = tex2D(_MainTex,TRANSFORM_TEX(i.uv0, _MainTex));
                float node_603 = (_MainTex_var.a*i.vertexColor.a); // A
                float3 emissive = (((_Opacity*((saturate(sin((lerp( node_8650.r, node_8650.g, _Horizontal )*_Linesfiness)))*_MainTex_var.rgb)+_MainTex_var.rgb))*i.vertexColor.rgb)*node_603);
                float3 finalColor = emissive;
                return fixed4(finalColor,node_603);
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
    CustomEditor "ShaderForgeMaterialInspector"
}
