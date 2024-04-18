using Infrastructure.Contexts;

namespace Infrastructure.Repositories;

public class FeatureItemRepository(AppDataContext context) : Repo<FeatureItemRepository>(context)
{
    private readonly AppDataContext _context = context;
}