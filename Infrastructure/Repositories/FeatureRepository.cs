using Infrastructure.Contexts;
using Infrastructure.Entities;
using Infrastructure.Factories;
using Infrastructure.Models;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace Infrastructure.Repositories;

public class FeatureRepository(AppDataContext context) : Repo<FeatureEntity>(context)
{
    private readonly AppDataContext _context = context;

    public override async Task<ResponseResult> GetAllAsync()
    {
        try
        {
            IEnumerable<FeatureEntity> result = await _context.Features
                .Include(x => x.FeatureItems)
                .ToListAsync();
            return ResponseFactory.Ok(result);
        }
        catch (Exception e)
        {
            Debug.WriteLine(e);
            return ResponseFactory.Error(e.Message);
        }
    }

}
