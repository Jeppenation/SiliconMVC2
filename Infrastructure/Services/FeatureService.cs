using Infrastructure.Factories;
using Infrastructure.Models;
using Infrastructure.Repositories;
using System.Diagnostics;

namespace Infrastructure.Services;

public class FeatureService(FeatureRepository featureRepository)
{
    private readonly FeatureRepository _featureRepository = featureRepository;


    public async Task<ResponseResult> GetAllFeaturesAsync()
    {
        try
        {
            var result = await _featureRepository.GetAllAsync();
            return result;

        }
        catch (Exception e)
        {
            Debug.WriteLine(e);
            return ResponseFactory.Error(e.Message);
        }

    }
}
