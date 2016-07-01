// Shader created with Shader Forge v1.19 
// Shader Forge (c) Neat Corporation / Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.19;sub:START;pass:START;ps:flbk:,iptp:1,cusa:True,bamd:0,lico:1,lgpr:1,limd:0,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:False,hqlp:False,rprd:False,enco:False,rmgx:True,rpth:0,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:True,tesm:0,olmd:1,culm:2,bsrc:3,bdst:7,dpts:2,wrdp:False,dith:0,rfrpo:True,rfrpn:Refraction,coma:15,ufog:False,aust:True,igpj:True,qofs:0,qpre:3,rntp:2,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5,fgcg:0.5,fgcb:0.5,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False;n:type:ShaderForge.SFN_Final,id:1873,x:33838,y:33173,varname:node_1873,prsc:2|emission-1749-OUT,alpha-603-OUT;n:type:ShaderForge.SFN_Multiply,id:1086,x:33352,y:33198,cmnt:RGB,varname:node_1086,prsc:2|A-7986-OUT,B-5376-RGB;n:type:ShaderForge.SFN_VertexColor,id:5376,x:32915,y:33453,varname:node_5376,prsc:2;n:type:ShaderForge.SFN_Multiply,id:1749,x:33585,y:33273,cmnt:Premultiply Alpha,varname:node_1749,prsc:2|A-1086-OUT,B-603-OUT;n:type:ShaderForge.SFN_Multiply,id:603,x:33352,y:33400,cmnt:A,varname:node_603,prsc:2|A-1807-A,B-5376-A;n:type:ShaderForge.SFN_Add,id:7986,x:33108,y:33141,varname:node_7986,prsc:2|A-3200-OUT,B-1807-RGB;n:type:ShaderForge.SFN_Multiply,id:3200,x:32881,y:33035,varname:node_3200,prsc:2|A-4006-OUT,B-1807-A;n:type:ShaderForge.SFN_Panner,id:9249,x:32146,y:32798,varname:node_9249,prsc:2,spu:1,spv:0|UVIN-5465-OUT,DIST-1930-OUT;n:type:ShaderForge.SFN_Tex2dAsset,id:3916,x:32146,y:33025,ptovrint:False,ptlb:Bubble,ptin:_Bubble,varname:node_3916,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:df5f991d641acba42be0d90d3b2c89ad,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Tex2d,id:1777,x:32417,y:32810,varname:node_1777,prsc:2,tex:df5f991d641acba42be0d90d3b2c89ad,ntxv:0,isnm:False|UVIN-9249-UVOUT,TEX-3916-TEX;n:type:ShaderForge.SFN_Tex2d,id:5154,x:32428,y:33064,varname:node_5154,prsc:2,tex:df5f991d641acba42be0d90d3b2c89ad,ntxv:0,isnm:False|UVIN-893-UVOUT,TEX-3916-TEX;n:type:ShaderForge.SFN_Panner,id:893,x:32146,y:33245,varname:node_893,prsc:2,spu:1.5,spv:0|UVIN-5504-OUT,DIST-1930-OUT;n:type:ShaderForge.SFN_Add,id:4006,x:32646,y:32942,varname:node_4006,prsc:2|A-1777-R,B-5154-R;n:type:ShaderForge.SFN_TexCoord,id:8384,x:30573,y:32893,varname:node_8384,prsc:2,uv:0;n:type:ShaderForge.SFN_Multiply,id:5504,x:31914,y:33222,varname:node_5504,prsc:2|A-5465-OUT,B-2940-OUT;n:type:ShaderForge.SFN_Vector1,id:2940,x:31703,y:33316,varname:node_2940,prsc:2,v1:1.5;n:type:ShaderForge.SFN_Time,id:9593,x:31656,y:32835,varname:node_9593,prsc:2;n:type:ShaderForge.SFN_Multiply,id:1930,x:31846,y:32905,varname:node_1930,prsc:2|A-9593-T,B-9592-OUT;n:type:ShaderForge.SFN_ValueProperty,id:9592,x:31625,y:33015,ptovrint:False,ptlb:Bubble Speed,ptin:_BubbleSpeed,varname:node_9592,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:0.5;n:type:ShaderForge.SFN_Tex2d,id:1807,x:32598,y:33284,ptovrint:False,ptlb:MainTex,ptin:_MainTex,varname:node_1807,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:695a0a6696ef9e7438b132fa687587aa,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Multiply,id:6526,x:30762,y:33045,varname:node_6526,prsc:2|A-8384-U,B-2686-OUT;n:type:ShaderForge.SFN_ValueProperty,id:2686,x:30573,y:33124,ptovrint:False,ptlb:Tiling U,ptin:_TilingU,varname:node_2686,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:1;n:type:ShaderForge.SFN_Append,id:9440,x:30943,y:32969,varname:node_9440,prsc:2|A-6526-OUT,B-8384-V;n:type:ShaderForge.SFN_Multiply,id:5465,x:31256,y:33045,varname:node_5465,prsc:2|A-9440-OUT,B-3817-OUT;n:type:ShaderForge.SFN_ValueProperty,id:3817,x:31000,y:33209,ptovrint:False,ptlb:Tiling Global,ptin:_TilingGlobal,varname:node_3817,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:1;proporder:1807-3916-9592-2686-3817;pass:END;sub:END;*/

Shader "Shader Forge/AlcoholBar" {
    Properties {
        _MainTex ("MainTex", 2D) = "white" {}
        _Bubble ("Bubble", 2D) = "white" {}
        _BubbleSpeed ("Bubble Speed", Float ) = 0.5
        _TilingU ("Tiling U", Float ) = 1
        _TilingGlobal ("Tiling Global", Float ) = 1
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
            Blend SrcAlpha OneMinusSrcAlpha
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
            uniform sampler2D _Bubble; uniform float4 _Bubble_ST;
            uniform float _BubbleSpeed;
            uniform sampler2D _MainTex; uniform float4 _MainTex_ST;
            uniform float _TilingU;
            uniform float _TilingGlobal;
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
                float4 node_9593 = _Time + _TimeEditor;
                float node_1930 = (node_9593.g*_BubbleSpeed);
                float2 node_5465 = (float2((i.uv0.r*_TilingU),i.uv0.g)*_TilingGlobal);
                float2 node_9249 = (node_5465+node_1930*float2(1,0));
                float4 node_1777 = tex2D(_Bubble,TRANSFORM_TEX(node_9249, _Bubble));
                float2 node_893 = ((node_5465*1.5)+node_1930*float2(1.5,0));
                float4 node_5154 = tex2D(_Bubble,TRANSFORM_TEX(node_893, _Bubble));
                float4 _MainTex_var = tex2D(_MainTex,TRANSFORM_TEX(i.uv0, _MainTex));
                float node_603 = (_MainTex_var.a*i.vertexColor.a); // A
                float3 emissive = (((((node_1777.r+node_5154.r)*_MainTex_var.a)+_MainTex_var.rgb)*i.vertexColor.rgb)*node_603);
                float3 finalColor = emissive;
                return fixed4(finalColor,node_603);
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
    CustomEditor "ShaderForgeMaterialInspector"
}
