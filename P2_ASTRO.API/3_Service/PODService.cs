using P2_ASTRO.API.DTO;

namespace P2_ASTRO.API.Service;

public class PODService : IPODService
{
    public PODOutDTO CreateNewPOD(PODInDTO newPODInDTO)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<PODOutDTO> GetAllPODs()
    {
        throw new NotImplementedException();
    }

    public PODOutDTO? GetPODbyDate(DateOnly date)
    {
        throw new NotImplementedException();
    }

    public PODOutDTO? GetPODbyId(int PODId)
    {
        throw new NotImplementedException();
    }
}