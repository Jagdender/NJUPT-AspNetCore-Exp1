using System.Text.Json.Serialization;
using NJUPT_AspNetCore_Exp1;

var builder = WebApplication.CreateSlimBuilder(args);

builder.Services.ConfigureHttpJsonOptions(options =>
{
    options.SerializerOptions.TypeInfoResolverChain.Insert(0, AppJsonSerializerContext.Default);
});

builder.Services.AddCors(options =>
    options.AddDefaultPolicy(policy => policy.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader())
);

var app = builder.Build();

app.UseCors();

var api = app.MapGroup("/Party").MapEndpoints();

app.Run();

[JsonSerializable(typeof(Party[]))]
[JsonSerializable(typeof(PartyRequest))]
[JsonSourceGenerationOptions(PropertyNameCaseInsensitive = true)]
internal sealed partial class AppJsonSerializerContext : JsonSerializerContext { }
