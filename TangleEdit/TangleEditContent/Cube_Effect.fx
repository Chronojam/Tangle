float4x4 WorldViewProj;

float4 AmbientColor = float4(1,1,1,1);
float AmbientIntensity = 0.1;

float4x4 WorldInverseTranspose;

float3 DiffuseLightDirection = float3(1,0,0);
float4 DiffuseColor = float4(1,1,1,1);
float DiffuseIntensity = 1.0;

texture FrontTexture;
texture BackTexture;
texture RightTexture;
texture LeftTexture;
texture BottomTexture;
texture TopTexture;

sampler2D Frontsampler = sampler_state {
Texture = (FrontTexture);
MagFilter = Linear;
MinFilter = Linear;
AddressU = Clamp;
AddressV = Clamp;
};

sampler2D Backsampler = sampler_state {
Texture = (BackTexture);
MagFilter = Linear;
MinFilter = Linear;
AddressU = Clamp;
AddressV = Clamp;
};

sampler2D Rightsampler = sampler_state {
Texture = (RightTexture);
MagFilter = Linear;
MinFilter = Linear;
AddressU = Clamp;
AddressV = Clamp;
};

sampler2D Leftsampler = sampler_state {
Texture = (LeftTexture);
MagFilter = Linear;
MinFilter = Linear;
AddressU = Clamp;
AddressV = Clamp;
};

sampler2D Bottomsampler = sampler_state {
Texture = (BottomTexture);
MagFilter = Linear;
MinFilter = Linear;
AddressU = Clamp;
AddressV = Clamp;
};

sampler2D Topsampler = sampler_state {
Texture = (FrontTexture);
MagFilter = Linear;
MinFilter = Linear;
AddressU = Clamp;
AddressV = Clamp;
};



// TODO: add effect parameters here.

struct VertexShaderInput
{
    float4 Position : POSITION0;
    float4 Normal : NORMAL0;
	float4 Color : COLOR0;
    float2 TextureCoordinate : TEXCOORD0;
};

struct VertexShaderOutput
{
    float4 Position : POSITION0;
    float3 Normal : NORMAL1;
	float3 NormalNormal : NORMAL0;
    float2 TextureCoordinate : TEXCOORD0;
};

VertexShaderOutput VertexShaderFunction(VertexShaderInput input)
{
    VertexShaderOutput output;

    output.Position = mul(input.Position, WorldViewProj);

    output.Normal = mul(input.Normal, WorldInverseTranspose);
	output.NormalNormal = input.Normal;
    output.TextureCoordinate = input.TextureCoordinate;

    return output;
}

float4 SampleFromTextures(float3 normal, float2 textureCoordinate)
{
	sampler2D Sampler;
	float4 Top;
	float4 Bottom;
	float4 Right;
	float4 Left;
	float4 Front;
	float4 Back;

	Top = tex2D(Topsampler, textureCoordinate);
	Bottom = tex2D(Bottomsampler, textureCoordinate);
	Right = tex2D(Rightsampler, textureCoordinate);
	Left = tex2D(Leftsampler, textureCoordinate);
	Front = tex2D(Frontsampler, textureCoordinate);
	Back = tex2D(Backsampler, textureCoordinate);

	if (normal.y == 1 && normal.x == 0 && normal.z == 0)
	{
		return Top;
	}
	if (normal.y == -1 && normal.x == 0 && normal.z == 0)
	{
		return Bottom;
	}
	if (normal.y == 0 && normal.x == 1 && normal.z == 0)
	{
		return Front;
	}
	if (normal.y == 0 && normal.x == -1 && normal.z == 0)
	{
		return Back;
	}
	if (normal.y == 0 && normal.x == 0 && normal.z == 1)
	{
		return Right;
	}
	if (normal.y == 0 && normal.x == 0 && normal.z == -1)
	{
		return Left;
	}

	return float4(0,0,0,0);
}

float4 PixelShaderFunction(VertexShaderOutput input) : COLOR0
{
    float3 diffuseLight = dot(input.Normal, DiffuseLightDirection) * DiffuseIntensity * DiffuseColor;
    float3 ambientLight = AmbientColor * AmbientIntensity;

	
	float4 textureColor = SampleFromTextures(input.NormalNormal, input.TextureCoordinate);
    return float4 (saturate(textureColor * 1 + diffuseLight + ambientLight), 1);
}



technique Technique1
{
    pass Pass1
    {
        // TODO: set renderstates here.

        VertexShader = compile vs_3_0 VertexShaderFunction();
        PixelShader = compile ps_3_0 PixelShaderFunction();
    }
}
