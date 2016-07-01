// Shader created with Shader Forge v1.19 
// Shader Forge (c) Neat Corporation / Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.19;sub:START;pass:START;ps:flbk:,iptp:0,cusa:False,bamd:0,lico:1,lgpr:1,limd:3,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:True,hqlp:False,rprd:True,enco:False,rmgx:True,rpth:0,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:0,bsrc:0,bdst:1,dpts:2,wrdp:True,dith:0,rfrpo:True,rfrpn:Refraction,coma:15,ufog:True,aust:True,igpj:False,qofs:0,qpre:1,rntp:1,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5,fgcg:0.5,fgcb:0.5,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False;n:type:ShaderForge.SFN_Final,id:2865,x:32719,y:32712,varname:node_2865,prsc:2|diff-4997-OUT;n:type:ShaderForge.SFN_Color,id:4623,x:29895,y:32668,ptovrint:False,ptlb:Shirt Color,ptin:_ShirtColor,varname:_Color,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0,c2:1,c3:0.006896496,c4:1;n:type:ShaderForge.SFN_Tex2d,id:2124,x:29895,y:32239,ptovrint:True,ptlb:Base Color,ptin:_MainTex,varname:_MainTex,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:b289d1633e60bb246ab9eeb505a07f72,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Tex2d,id:9753,x:32428,y:33133,ptovrint:True,ptlb:Normal Map,ptin:_BumpMap,varname:_BumpMap,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:459a3b9be79e7104080ffa935a442c2e,ntxv:3,isnm:True;n:type:ShaderForge.SFN_Tex2d,id:4942,x:32161,y:32541,ptovrint:False,ptlb:Metallic,ptin:_Metallic,varname:node_2509,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:6fd05ae5d3ecfa543be871e73f266488,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Tex2d,id:139,x:32110,y:33080,ptovrint:False,ptlb:Roughness,ptin:_Roughness,varname:node_6920,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:1ec06fa1bb71867498b1140f3018b866,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Add,id:5932,x:32375,y:32914,varname:node_5932,prsc:2|A-767-OUT,B-139-R;n:type:ShaderForge.SFN_OneMinus,id:767,x:32110,y:32905,varname:node_767,prsc:2|IN-664-OUT;n:type:ShaderForge.SFN_Lerp,id:6129,x:30600,y:32174,varname:node_6129,prsc:2|A-1181-OUT,B-7639-OUT,T-8725-R;n:type:ShaderForge.SFN_Tex2d,id:8725,x:29895,y:32456,ptovrint:False,ptlb:Masks,ptin:_Masks,varname:node_3352,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:b91d16493fb3725409433d051117b75f,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Lerp,id:8808,x:30593,y:32431,varname:node_8808,prsc:2|A-1181-OUT,B-9701-OUT,T-8725-G;n:type:ShaderForge.SFN_Lerp,id:5419,x:30590,y:32688,varname:node_5419,prsc:2|A-1181-OUT,B-1563-OUT,T-8725-B;n:type:ShaderForge.SFN_Color,id:5083,x:29895,y:32023,ptovrint:False,ptlb:Scarf Color,ptin:_ScarfColor,varname:_Color_copy,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0.9926471,c2:0.058391,c3:0.058391,c4:1;n:type:ShaderForge.SFN_Color,id:5326,x:29895,y:32854,ptovrint:False,ptlb:Pants Color,ptin:_PantsColor,varname:_Color_copy_copy,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0.1999998,c2:0,c3:1,c4:1;n:type:ShaderForge.SFN_Multiply,id:7639,x:30239,y:32103,varname:node_7639,prsc:2|A-5083-RGB,B-2124-RGB;n:type:ShaderForge.SFN_Multiply,id:9701,x:30246,y:32448,varname:node_9701,prsc:2|A-2124-RGB,B-4623-RGB;n:type:ShaderForge.SFN_Multiply,id:1563,x:30300,y:32702,varname:node_1563,prsc:2|A-2124-RGB,B-5326-RGB;n:type:ShaderForge.SFN_Vector1,id:1181,x:30246,y:32380,varname:node_1181,prsc:2,v1:0;n:type:ShaderForge.SFN_Add,id:7922,x:30796,y:32300,varname:node_7922,prsc:2|A-6129-OUT,B-8808-OUT;n:type:ShaderForge.SFN_Add,id:9100,x:31019,y:32462,varname:node_9100,prsc:2|A-7922-OUT,B-5419-OUT;n:type:ShaderForge.SFN_Lerp,id:4997,x:31565,y:32623,varname:node_4997,prsc:2|A-2124-RGB,B-1854-OUT,T-2813-OUT;n:type:ShaderForge.SFN_Add,id:7669,x:30856,y:32616,varname:node_7669,prsc:2|A-8725-R,B-8725-G;n:type:ShaderForge.SFN_Add,id:8814,x:30856,y:32734,varname:node_8814,prsc:2|A-7669-OUT,B-8725-B;n:type:ShaderForge.SFN_Tex2d,id:8831,x:29893,y:33235,ptovrint:False,ptlb:Masks 2,ptin:_Masks2,varname:node_4978,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:b124635f4a5d1484fb7c919c7189f72b,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Color,id:9636,x:29893,y:33053,ptovrint:False,ptlb:Coat Color,ptin:_CoatColor,varname:_PantsColor_copy,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0,c2:0.9803922,c3:0.9803922,c4:1;n:type:ShaderForge.SFN_Color,id:5499,x:29893,y:33437,ptovrint:False,ptlb:Fur Color,ptin:_FurColor,varname:_PantsColor_copy_copy,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0.9862069,c2:1,c3:0,c4:1;n:type:ShaderForge.SFN_Multiply,id:5785,x:30267,y:32955,varname:node_5785,prsc:2|A-2124-RGB,B-9636-RGB;n:type:ShaderForge.SFN_Multiply,id:4087,x:30254,y:33417,varname:node_4087,prsc:2|A-2124-RGB,B-5499-RGB;n:type:ShaderForge.SFN_Lerp,id:9306,x:30585,y:32991,varname:node_9306,prsc:2|A-1181-OUT,B-5785-OUT,T-8831-B;n:type:ShaderForge.SFN_Lerp,id:1782,x:30583,y:33266,varname:node_1782,prsc:2|A-1181-OUT,B-4087-OUT,T-8831-G;n:type:ShaderForge.SFN_Add,id:3240,x:30827,y:33073,varname:node_3240,prsc:2|A-9306-OUT,B-1782-OUT;n:type:ShaderForge.SFN_Add,id:1854,x:31329,y:32780,varname:node_1854,prsc:2|A-9100-OUT,B-3240-OUT;n:type:ShaderForge.SFN_Add,id:2813,x:30856,y:32860,varname:node_2813,prsc:2|A-8814-OUT,B-4730-OUT;n:type:ShaderForge.SFN_Add,id:6281,x:30214,y:33218,varname:node_6281,prsc:2|A-8831-G,B-8831-B;n:type:ShaderForge.SFN_Hue,id:5265,x:29553,y:33708,varname:node_5265,prsc:2|IN-5573-OUT;n:type:ShaderForge.SFN_Subtract,id:9124,x:29783,y:33708,varname:node_9124,prsc:2|A-5265-OUT,B-6708-OUT;n:type:ShaderForge.SFN_Vector1,id:6708,x:29553,y:33863,varname:node_6708,prsc:2,v1:0.2;n:type:ShaderForge.SFN_Desaturate,id:4017,x:29974,y:33708,varname:node_4017,prsc:2|COL-9124-OUT,DES-355-OUT;n:type:ShaderForge.SFN_Vector1,id:355,x:29783,y:33863,varname:node_355,prsc:2,v1:0.5;n:type:ShaderForge.SFN_Multiply,id:3803,x:30254,y:33619,varname:node_3803,prsc:2|A-2124-RGB,B-4017-OUT;n:type:ShaderForge.SFN_Lerp,id:3428,x:30583,y:33473,varname:node_3428,prsc:2|A-1181-OUT,B-3803-OUT,T-8831-R;n:type:ShaderForge.SFN_Add,id:4730,x:30373,y:33126,varname:node_4730,prsc:2|A-8831-R,B-6281-OUT;n:type:ShaderForge.SFN_Vector1,id:664,x:31811,y:33084,varname:node_664,prsc:2,v1:0.741;n:type:ShaderForge.SFN_Slider,id:5573,x:29161,y:33719,ptovrint:False,ptlb:Skin Tone,ptin:_SkinTone,varname:node_9269,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0,max:1;proporder:4623-2124-8725-5083-5326-8831-9636-5499;pass:END;sub:END;*/

Shader "Shader Forge/MainSailor2" {
    Properties {
    }
    SubShader {
        Tags {
            "RenderType"="Opaque"
        }
        Pass {
            Name "FORWARD"
            Tags {
                "LightMode"="ForwardBase"
            }
            
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_FORWARDBASE
            #define _GLOSSYENV 1
            #include "UnityCG.cginc"
            #include "UnityPBSLighting.cginc"
            #include "UnityStandardBRDF.cginc"
            #pragma multi_compile_fwdbase_fullshadows
            #pragma multi_compile_fog
            #pragma exclude_renderers gles3 metal d3d11_9x xbox360 xboxone ps3 ps4 psp2 
            #pragma target 3.0
            struct VertexInput {
                float4 vertex : POSITION;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                UNITY_FOG_COORDS(0)
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.pos = mul(UNITY_MATRIX_MVP, v.vertex );
                UNITY_TRANSFER_FOG(o,o.pos);
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
/////// Vectors:
////// Lighting:
                float3 finalColor = 0;
                fixed4 finalRGBA = fixed4(finalColor,1);
                UNITY_APPLY_FOG(i.fogCoord, finalRGBA);
                return finalRGBA;
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
    CustomEditor "ShaderForgeMaterialInspector"
}
