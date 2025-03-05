namespace NJUPT_AspNetCore_Exp1;

public readonly record struct PartyRequest(string Topic, string Location, DateTime DateTime)
{
    public Party ToParty(long id) => new(id, Topic, Location, DateTime);
}
