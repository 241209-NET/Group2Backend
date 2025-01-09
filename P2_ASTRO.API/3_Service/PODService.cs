using P2_ASTRO.API.DTO;
using P2_ASTRO.API.Repository;
using P2_ASTRO.API.Util;

namespace P2_ASTRO.API.Service;

public class PODService : IPODService
{
    private readonly IPODRepository _podRepository;
    private readonly Utility _utility;
    public PODService(IPODRepository podRepository,Utility utility){
        _podRepository = podRepository;
        _utility = utility;
    }
    public PODOutDTO CreateNewPOD(PODInDTO newPODInDTO)
    {
        var pod = _utility.PODInDTOToPOD(newPODInDTO);
        var newPod = _podRepository.CreateNewPOD(pod);
        return _utility.PODToPODOutDTO(newPod);
    }

    public IEnumerable<PODOutDTO> GetAllPODs()
    {
        var pods = _podRepository.GetAllPODs();
        return pods.Select(_utility.PODToPODOutDTO);
    }

    public PODOutDTO? GetPODbyDate(DateOnly date)
    {
        var pod = _podRepository.GetPODbyDate(date);
        if(pod is null) return null;
        return _utility.PODToPODOutDTO(pod);
    }

    public PODOutDTO? GetPODbyId(int PODId)
    {
        var pod = _podRepository.GetPODbyId(PODId);
        if(pod is null) return null;
        return _utility.PODToPODOutDTO(pod);
    }
}