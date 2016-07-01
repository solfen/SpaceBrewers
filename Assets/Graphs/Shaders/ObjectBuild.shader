// Shader created with Shader Forge v1.19 
// Shader Forge (c) Neat Corporation / Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.19;sub:START;pass:START;ps:flbk:,iptp:0,cusa:False,bamd:0,lico:1,lgpr:1,limd:3,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:True,hqlp:False,rprd:True,enco:False,rmgx:True,rpth:0,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:0,bsrc:3,bdst:7,dpts:2,wrdp:False,dith:0,rfrpo:True,rfrpn:Refraction,coma:15,ufog:True,aust:True,igpj:True,qofs:0,qpre:3,rntp:2,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5,fgcg:0.5,fgcb:0.5,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False;n:type:ShaderForge.SFN_Final,id:2865,x:32719,y:32712,varname:node_2865,prsc:2|emission-566-OUT,alpha-790-OUT;n:type:ShaderForge.SFN_Fresnel,id:3611,x:31742,y:33203,varname:node_3611,prsc:2|EXP-4971-OUT;n:type:ShaderForge.SFN_Color,id:7333,x:31473,y:32846,ptovrint:False,ptlb:Color,ptin:_Color,varname:node_7333,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0,c2:0.751724,c3:1,c4:1;n:type:ShaderForge.SFN_ValueProperty,id:4971,x:31480,y:33200,ptovrint:False,ptlb:Fresnel Exponent,ptin:_FresnelExponent,varname:node_4971,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:1.5;n:type:ShaderForge.SFN_Lerp,id:6257,x:31958,y:32988,varname:node_6257,prsc:2|A-3744-OUT,B-7333-RGB,T-3611-OUT;n:type:ShaderForge.SFN_Subtract,id:3744,x:31703,y:32966,varname:node_3744,prsc:2|A-7333-RGB,B-807-OUT;n:type:ShaderForge.SFN_Vector1,id:807,x:31509,y:33061,varname:node_807,prsc:2,v1:0.6;n:type:ShaderForge.SFN_Multiply,id:9060,x:32147,y:32905,varname:node_9060,prsc:2|A-5461-OUT,B-6257-OUT;n:type:ShaderForge.SFN_ValueProperty,id:5461,x:31894,y:32845,ptovrint:False,ptlb:Glow,ptin:_Glow,varname:node_5461,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:2;n:type:ShaderForge.SFN_Add,id:566,x:32434,y:32739,varname:node_566,prsc:2|A-7377-OUT,B-9060-OUT;n:type:ShaderForge.SFN_Tex2d,id:2934,x:31377,y:32347,varname:node_2934,prsc:2,tex:92d6743cfb8b42647ae6f1fb49da609a,ntxv:0,isnm:False|UVIN-3091-OUT,TEX-2629-TEX;n:type:ShaderForge.SFN_Tex2dAsset,id:2629,x:30620,y:32637,ptovrint:False,ptlb:Grid Texture,ptin:_GridTexture,varname:node_2629,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:92d6743cfb8b42647ae6f1fb49da609a,ntxv:0,isnm:False;n:type:ShaderForge.SFN_FragmentPosition,id:5216,x:29804,y:32179,varname:node_5216,prsc:2;n:type:ShaderForge.SFN_ComponentMask,id:418,x:30033,y:32083,varname:node_418,prsc:2,cc1:0,cc2:2,cc3:-1,cc4:-1|IN-5216-XYZ;n:type:ShaderForge.SFN_Multiply,id:3091,x:31133,y:32209,varname:node_3091,prsc:2|A-418-OUT,B-6089-OUT;n:type:ShaderForge.SFN_ValueProperty,id:6089,x:30620,y:32550,ptovrint:False,ptlb:Tiling,ptin:_Tiling,varname:node_6089,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:4;n:type:ShaderForge.SFN_ComponentMask,id:8413,x:30033,y:32270,varname:node_8413,prsc:2,cc1:0,cc2:1,cc3:-1,cc4:-1|IN-5216-XYZ;n:type:ShaderForge.SFN_Tex2d,id:5060,x:31377,y:32515,varname:node_5060,prsc:2,tex:92d6743cfb8b42647ae6f1fb49da609a,ntxv:0,isnm:False|UVIN-9755-OUT,TEX-2629-TEX;n:type:ShaderForge.SFN_Multiply,id:9755,x:31133,y:32402,varname:node_9755,prsc:2|A-8413-OUT,B-6089-OUT;n:type:ShaderForge.SFN_Add,id:218,x:31577,y:32465,varname:node_218,prsc:2|A-2934-R,B-5060-R;n:type:ShaderForge.SFN_Multiply,id:7377,x:32075,y:32122,varname:node_7377,prsc:2|A-2821-OUT,B-218-OUT;n:type:ShaderForge.SFN_Panner,id:6897,x:31074,y:31602,varname:node_6897,prsc:2,spu:1,spv:0|UVIN-7690-OUT,DIST-4002-OUT;n:type:ShaderForge.SFN_Multiply,id:7690,x:30460,y:31597,varname:node_7690,prsc:2|A-8156-OUT,B-418-OUT;n:type:ShaderForge.SFN_Vector1,id:8156,x:30460,y:31537,varname:node_8156,prsc:2,v1:1.96465;n:type:ShaderForge.SFN_Tex2dAsset,id:3538,x:31078,y:31782,ptovrint:False,ptlb:Mask Texture,ptin:_MaskTexture,varname:node_3538,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:909d3a1def655c741b0dbb7b677eacd1,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Tex2d,id:6131,x:31545,y:31743,varname:node_6131,prsc:2,tex:909d3a1def655c741b0dbb7b677eacd1,ntxv:0,isnm:False|UVIN-6897-UVOUT,TEX-3538-TEX;n:type:ShaderForge.SFN_Panner,id:3385,x:31078,y:31951,varname:node_3385,prsc:2,spu:-1,spv:0|UVIN-4988-OUT,DIST-4002-OUT;n:type:ShaderForge.SFN_Tex2d,id:535,x:31545,y:31911,varname:node_535,prsc:2,tex:909d3a1def655c741b0dbb7b677eacd1,ntxv:0,isnm:False|UVIN-3385-UVOUT,TEX-3538-TEX;n:type:ShaderForge.SFN_Multiply,id:2821,x:31800,y:31932,varname:node_2821,prsc:2|A-6131-RGB,B-535-R;n:type:ShaderForge.SFN_Time,id:8995,x:29873,y:31768,varname:node_8995,prsc:2;n:type:ShaderForge.SFN_Multiply,id:4002,x:30115,y:31809,varname:node_4002,prsc:2|A-8995-T,B-8865-OUT;n:type:ShaderForge.SFN_ValueProperty,id:8865,x:29886,y:31950,ptovrint:False,ptlb:Speed,ptin:_Speed,varname:node_8865,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:1;n:type:ShaderForge.SFN_Multiply,id:4988,x:30762,y:32017,varname:node_4988,prsc:2|A-8413-OUT,B-6976-OUT;n:type:ShaderForge.SFN_Vector1,id:6976,x:30762,y:32140,varname:node_6976,prsc:2,v1:1.05564;n:type:ShaderForge.SFN_Multiply,id:790,x:32420,y:33197,varname:node_790,prsc:2|A-5170-OUT,B-3611-OUT;n:type:ShaderForge.SFN_Tex2d,id:5902,x:31432,y:33418,varname:node_5902,prsc:2,tex:909d3a1def655c741b0dbb7b677eacd1,ntxv:0,isnm:False|UVIN-193-UVOUT,TEX-3538-TEX;n:type:ShaderForge.SFN_Multiply,id:3573,x:30590,y:32955,varname:node_3573,prsc:2|A-8413-OUT,B-2822-OUT;n:type:ShaderForge.SFN_Vector1,id:2822,x:30567,y:33082,varname:node_2822,prsc:2,v1:0.1;n:type:ShaderForge.SFN_Panner,id:193,x:30962,y:33142,varname:node_193,prsc:2,spu:-0.5,spv:0|UVIN-3573-OUT,DIST-1187-OUT;n:type:ShaderForge.SFN_Divide,id:1187,x:30567,y:33220,varname:node_1187,prsc:2|A-4002-OUT,B-3295-OUT;n:type:ShaderForge.SFN_Vector1,id:3295,x:30561,y:33416,varname:node_3295,prsc:2,v1:2;n:type:ShaderForge.SFN_Add,id:5170,x:31854,y:33368,varname:node_5170,prsc:2|A-5902-R,B-410-OUT;n:type:ShaderForge.SFN_Vector1,id:410,x:31831,y:33513,varname:node_410,prsc:2,v1:0.7;proporder:7333-4971-5461-2629-6089-3538-8865;pass:END;sub:END;*/

Shader "Shader Forge/ObjectBuild" {
    Properties {
        _Color ("Color", Color) = (0,0.751724,1,1)
        _FresnelExponent ("Fresnel Exponent", Float ) = 1.5
        _Glow ("Glow", Float ) = 2
        _GridTexture ("Grid Texture", 2D) = "white" {}
        _Tiling ("Tiling", Float ) = 4
        _MaskTexture ("Mask Texture", 2D) = "white" {}
        _Speed ("Speed", Float ) = 1
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
            #define _GLOSSYENV 1
            #include "UnityCG.cginc"
            #include "UnityPBSLighting.cginc"
            #include "UnityStandardBRDF.cginc"
            #pragma multi_compile_fwdbase
            #pragma multi_compile_fog
            #pragma exclude_renderers gles3 metal d3d11_9x xbox360 xboxone ps3 ps4 psp2 
            #pragma target 3.0
            uniform float4 _TimeEditor;
            uniform float4 _Color;
            uniform float _FresnelExponent;
            uniform float _Glow;
            uniform sampler2D _GridTexture; uniform float4 _GridTexture_ST;
            uniform float _Tiling;
            uniform sampler2D _MaskTexture; uniform float4 _MaskTexture_ST;
            uniform float _Speed;
            struct VertexInput {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float4 posWorld : TEXCOORD0;
                float3 normalDir : TEXCOORD1;
                UNITY_FOG_COORDS(2)
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.normalDir = UnityObjectToWorldNormal(v.normal);
                o.posWorld = mul(_Object2World, v.vertex);
                o.pos = mul(UNITY_MATRIX_MVP, v.vertex );
                UNITY_TRANSFER_FOG(o,o.pos);
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
                i.normalDir = normalize(i.normalDir);
/////// Vectors:
                float3 viewDirection = normalize(_WorldSpaceCameraPos.xyz - i.posWorld.xyz);
                float3 normalDirection = i.normalDir;
////// Lighting:
////// Emissive:
                float4 node_8995 = _Time + _TimeEditor;
                float node_4002 = (node_8995.g*_Speed);
                float2 node_418 = i.posWorld.rgb.rb;
                float2 node_6897 = ((1.96465*node_418)+node_4002*float2(1,0));
                float4 node_6131 = tex2D(_MaskTexture,TRANSFORM_TEX(node_6897, _MaskTexture));
                float2 node_8413 = i.posWorld.rgb.rg;
                float2 node_3385 = ((node_8413*1.05564)+node_4002*float2(-1,0));
                float4 node_535 = tex2D(_MaskTexture,TRANSFORM_TEX(node_3385, _MaskTexture));
                float2 node_3091 = (node_418*_Tiling);
                float4 node_2934 = tex2D(_GridTexture,TRANSFORM_TEX(node_3091, _GridTexture));
                float2 node_9755 = (node_8413*_Tiling);
                float4 node_5060 = tex2D(_GridTexture,TRANSFORM_TEX(node_9755, _GridTexture));
                float node_3611 = pow(1.0-max(0,dot(normalDirection, viewDirection)),_FresnelExponent);
                float3 emissive = (((node_6131.rgb*node_535.r)*(node_2934.r+node_5060.r))+(_Glow*lerp((_Color.rgb-0.6),_Color.rgb,node_3611)));
                float3 finalColor = emissive;
                float2 node_193 = ((node_8413*0.1)+(node_4002/2.0)*float2(-0.5,0));
                float4 node_5902 = tex2D(_MaskTexture,TRANSFORM_TEX(node_193, _MaskTexture));
                fixed4 finalRGBA = fixed4(finalColor,((node_5902.r+0.7)*node_3611));
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
            uniform float4 _Color;
            uniform float _FresnelExponent;
            uniform float _Glow;
            uniform sampler2D _GridTexture; uniform float4 _GridTexture_ST;
            uniform float _Tiling;
            uniform sampler2D _MaskTexture; uniform float4 _MaskTexture_ST;
            uniform float _Speed;
            struct VertexInput {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
                float2 texcoord1 : TEXCOORD1;
                float2 texcoord2 : TEXCOORD2;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float4 posWorld : TEXCOORD0;
                float3 normalDir : TEXCOORD1;
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.normalDir = UnityObjectToWorldNormal(v.normal);
                o.posWorld = mul(_Object2World, v.vertex);
                o.pos = UnityMetaVertexPosition(v.vertex, v.texcoord1.xy, v.texcoord2.xy, unity_LightmapST, unity_DynamicLightmapST );
                return o;
            }
            float4 frag(VertexOutput i) : SV_Target {
                i.normalDir = normalize(i.normalDir);
/////// Vectors:
                float3 viewDirection = normalize(_WorldSpaceCameraPos.xyz - i.posWorld.xyz);
                float3 normalDirection = i.normalDir;
                UnityMetaInput o;
                UNITY_INITIALIZE_OUTPUT( UnityMetaInput, o );
                
                float4 node_8995 = _Time + _TimeEditor;
                float node_4002 = (node_8995.g*_Speed);
                float2 node_418 = i.posWorld.rgb.rb;
                float2 node_6897 = ((1.96465*node_418)+node_4002*float2(1,0));
                float4 node_6131 = tex2D(_MaskTexture,TRANSFORM_TEX(node_6897, _MaskTexture));
                float2 node_8413 = i.posWorld.rgb.rg;
                float2 node_3385 = ((node_8413*1.05564)+node_4002*float2(-1,0));
                float4 node_535 = tex2D(_MaskTexture,TRANSFORM_TEX(node_3385, _MaskTexture));
                float2 node_3091 = (node_418*_Tiling);
                float4 node_2934 = tex2D(_GridTexture,TRANSFORM_TEX(node_3091, _GridTexture));
                float2 node_9755 = (node_8413*_Tiling);
                float4 node_5060 = tex2D(_GridTexture,TRANSFORM_TEX(node_9755, _GridTexture));
                float node_3611 = pow(1.0-max(0,dot(normalDirection, viewDirection)),_FresnelExponent);
                o.Emission = (((node_6131.rgb*node_535.r)*(node_2934.r+node_5060.r))+(_Glow*lerp((_Color.rgb-0.6),_Color.rgb,node_3611)));
                
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
