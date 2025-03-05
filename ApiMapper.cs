namespace NJUPT_AspNetCore_Exp1;

public static class ApiMapper
{
    private const string html = "./index.html";

    public static IEndpointRouteBuilder MapEndpoints(this IEndpointRouteBuilder api)
    {
        api.MapGet("/All", () => Party.Values);
        api.MapGet(
            "/{id}",
            (long id) =>
                Party.Values.Find(id) is Party party ? Results.Ok(party) : Results.NotFound()
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

                if (parties.Find(id) is Party party)
                {
                    parties[Array.FindIndex(parties, p => p.Id == id)] = request.ToParty(id);
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

        api.MapGet(
            "/Party",
            () =>
                File.Exists(html)
                    ? Results.Text(File.ReadAllText(html), "text/html")
                    : Results.NotFound()
        );

        return api;
    }
}
