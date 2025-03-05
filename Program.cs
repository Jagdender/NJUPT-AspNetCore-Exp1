using System.Text.Json.Serialization;
using NJUPT_AspNetCore_Exp1;

var builder = WebApplication.CreateSlimBuilder(args);

builder.Services.ConfigureHttpJsonOptions(options =>
{
    options.SerializerOptions.TypeInfoResolverChain.Insert(0, AppJsonSerializerContext.Default);
});

var app = builder.Build();

var api = app.MapGroup("/Party");

api.MapGet("/All", () => Party.Values);
api.MapGet(
    "/{id}",
    (long id) =>
        Party.Values.FirstOrDefault(a => a.Id == id) is { } party
            ? Results.Ok(party)
            : Results.NotFound()
);

api.MapPost(
    "/",
    (PartyRequest request) =>
    {
        var party = request.ToParty(Party.NewId);
        Party.Write([.. Party.Values, party]);
        return Results.Created($"/Party/{party.Id}", party);
    }
);
api.MapPut(
    "/{id}",
    (long id, PartyRequest request) =>
    {
        var parties = Party.Values;
        int index = Array.FindIndex(parties, a => a.Id == id);

        if (index > -1)
        {
            parties[index] = request.ToParty(id);
            Party.Write(parties);
        }

        return Results.NoContent();
    }
);

api.MapDelete(
    "/{id}",
    (long id) =>
    {
        var parties = Party.Values.ToList();

        if (parties.RemoveAll(a => a.Id == id) > 0)
        {
            Party.Write([.. parties]);
        }

        return Results.NoContent();
    }
);

app.Run();

[JsonSerializable(typeof(Party[]))]
[JsonSerializable(typeof(PartyRequest))]
internal sealed partial class AppJsonSerializerContext : JsonSerializerContext { }
