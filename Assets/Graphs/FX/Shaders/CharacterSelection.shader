// Shader created with Shader Forge v1.19 
// Shader Forge (c) Neat Corporation / Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.19;sub:START;pass:START;ps:flbk:,iptp:0,cusa:False,bamd:0,lico:1,lgpr:1,limd:0,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:False,hqlp:False,rprd:False,enco:False,rmgx:True,rpth:0,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:0,bsrc:3,bdst:7,dpts:2,wrdp:False,dith:0,rfrpo:True,rfrpn:Refraction,coma:15,ufog:False,aust:True,igpj:True,qofs:0,qpre:3,rntp:2,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5,fgcg:0.5,fgcb:0.5,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False;n:type:ShaderForge.SFN_Final,id:3138,x:32719,y:32712,varname:node_3138,prsc:2|emission-2705-OUT,alpha-2765-R;n:type:ShaderForge.SFN_Color,id:7241,x:32192,y:32664,ptovrint:False,ptlb:Color,ptin:_Color,varname:node_7241,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0.07843138,c2:0.3921569,c3:0.7843137,c4:1;n:type:ShaderForge.SFN_Tex2d,id:2765,x:32192,y:32884,ptovrint:False,ptlb:Texture,ptin:_Texture,varname:node_2765,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:2c752c03c90756a4c87b15fbecbfaee9,ntxv:0,isnm:False|UVIN-4399-UVOUT;n:type:ShaderForge.SFN_Multiply,id:2705,x:32464,y:32780,varname:node_2705,prsc:2|A-7241-RGB,B-2765-R;n:type:ShaderForge.SFN_Rotator,id:4399,x:31958,y:32873,varname:node_4399,prsc:2|SPD-6903-OUT;n:type:ShaderForge.SFN_ValueProperty,id:6903,x:31714,y:32973,ptovrint:False,ptlb:Rotation Speed,ptin:_RotationSpeed,varname:node_6903,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:1;proporder:7241-2765-6903;pass:END;sub:END;*/

Shader "Shader Forge/CharacterSelection" {
    Properties {
        _Color ("Color", Color) = (0.07843138,0.3921569,0.7843137,1)
        _Texture ("Texture", 2D) = "white" {}
        _RotationSpeed ("Rotation Speed", Float ) = 1
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
            uniform sampler2D _Texture; uniform float4 _Texture_ST;
            uniform float _RotationSpeed;
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
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
/////// Vectors:
////// Lighting:
////// Emissive:
                float4 node_328 = _Time + _TimeEditor;
                float node_4399_ang = node_328.g;
                float node_4399_spd = _RotationSpeed;
                float node_4399_cos = cos(node_4399_spd*node_4399_ang);
                float node_4399_sin = sin(node_4399_spd*node_4399_ang);
                float2 node_4399_piv = float2(0.5,0.5);
                float2 node_4399 = (mul(i.uv0-node_4399_piv,float2x2( node_4399_cos, -node_4399_sin, node_4399_sin, node_4399_cos))+node_4399_piv);
                float4 _Texture_var = tex2D(_Texture,TRANSFORM_TEX(node_4399, _Texture));
                float3 emissive = (_Color.rgb*_Texture_var.r);
                float3 finalColor = emissive;
                return fixed4(finalColor,_Texture_var.r);
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
    CustomEditor "ShaderForgeMaterialInspector"
}
