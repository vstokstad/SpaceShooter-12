Shader "Unlit/ToonTest"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
        _RampTex ("Ramp Texture", 2D) = "white" {}
        _Color("Color", Color) = (1, 1, 1, 1)
        _AmbientStrength("Ambient Lighting Strength", float) = 0.2
        _Glossiness("Glossiness", float) = 32
    }
    SubShader
    {
        // Regular color & Lighting pass
        Tags { "LightMode" = "ForwardBase" }
        LOD 100

        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #pragma multi_compile_fwdbase
            // make fog work
            #pragma multi_compile_fog

            #include "UnityCG.cginc"
            #include "AutoLight.cginc"

            struct VertexInput
            {
                float4 pos : POSITION;
                float3 normal : NORMAL;
                float2 uv : TEXCOORD0;
            };

            struct v2f
            {
                float3 normal : NORMAL;
                float2 uv : TEXCOORD0;
                float4 pos : SV_POSITION;
                float3 viewDirection : TEXCOORD1;
                SHADOW_COORDS(2)
            };

            sampler2D _MainTex;
            sampler2D _RampTex;
            float4 _Color;
            float4 _LightColor0;
            float4 _MainTex_ST;
            float _AmbientStrength;
            float _Glossiness;

            v2f vert (VertexInput input)
            {
                v2f output;
                
                output.pos = UnityObjectToClipPos(input.pos);
                output.normal = UnityObjectToWorldNormal(input.normal);
                
                output.uv = input.uv;
                output.viewDirection = WorldSpaceViewDir(input.pos);

                TRANSFER_SHADOW(output);
                UNITY_TRANSFER_FOG(output, output.pos);
                return output;
            }

            float3 frag (v2f input) : SV_Target
            {
                // sample the texture
                float3 normal = normalize(input.normal); 
                float3 viewDir = normalize(input.viewDirection);
                fixed4 col = tex2D(_MainTex, input.uv);
                float3 lightDir = normalize(_WorldSpaceLightPos0);

                float shadow = SHADOW_ATTENUATION(input);
                
                float NdotL = dot(_WorldSpaceLightPos0, normal);

                float lightIntensity = clamp(smoothstep(0, 0, NdotL * shadow), 0, 1);
                
                // diffuse
                float diffuseAngle = saturate(dot(normal, lightDir) * 0.5 + 0.5);
                float3 diffuse = tex2D(_RampTex, float2(diffuseAngle, diffuseAngle)).rgb * lightIntensity; 
                
                // specular
                float3 halfVector = normalize(_WorldSpaceLightPos0 + viewDir);
                float NdotH = dot(normal, halfVector);
                float specularIntensity = pow(NdotH * lightIntensity, _Glossiness * _Glossiness);
                float3 specular = smoothstep(0.005, 0.006, specularIntensity);
                
                float3 lighting = ((diffuse + specular + _AmbientStrength) * _LightColor0.rgb);


                float2 TiledUV = TRANSFORM_TEX(input.uv, _MainTex);
                float3 albedo = tex2D(_MainTex, TiledUV);
                
                col *= float4(lighting * _Color * albedo, 1.0f);
                
                // apply fog
                UNITY_APPLY_FOG(input.fogCoord, col);
                return col;
            }
            ENDCG
        }
        // Shadow pass
        Pass
        {
            Tags
            {
                "LightMode" = "ShadowCaster"
            }

            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #pragma multi_compile_shadowcaster
            #include "UnityCG.cginc"

            struct v2f
            {
                V2F_SHADOW_CASTER;
            };

            v2f vert(appdata_base v)
            {
                v2f output;
                TRANSFER_SHADOW_CASTER_NORMALOFFSET(output);
                return output;
            }

            float4 frag(v2f input) : SV_Target
            {
                SHADOW_CASTER_FRAGMENT(input);
            }
            ENDCG
        }
    }
}
