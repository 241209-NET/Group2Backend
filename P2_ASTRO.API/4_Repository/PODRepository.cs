using P2_ASTRO.API.Model;
using P2_ASTRO.API.Data;

namespace P2_ASTRO.API.Repository;

public class PODRepository : IPODRepository
{
    private readonly AstroContext _astroContext;

    public PODRepository(AstroContext astroContext) => _astroContext = astroContext;
    public POD CreateNewPOD(POD newPOD)
    {
        _astroContext.PODs.Add(newPOD);
        _astroContext.SaveChanges();
        return newPOD;
    }

    public IEnumerable<POD> GetAllPODs()
    {
        return _astroContext.PODs.ToList(); //TODO might need to .Include(comments)*****************
    }

    public POD? GetPODbyDate(DateOnly date)
    {
        POD? pod = _astroContext.PODs.FirstOrDefault(p => p.Date == date);
        if(pod is null) return null;
        return pod;
    }

    public POD? GetPODbyId(int PODId)
    {
        POD? pod = _astroContext.PODs.FirstOrDefault(p => p.PODId == PODId);
        if(pod is null) return null;
        return pod;
    }
}