using Infrastructure.Contexts;
using Infrastructure.Factories;
using Infrastructure.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public abstract class Repo<TEntity>(AppDataContext context) where TEntity : class
    {
        private readonly AppDataContext _context = context;


        public virtual async Task<ResponseResult> CreateAsync(TEntity entity)
        {


            try
            {
                await _context.Set<TEntity>().AddAsync(entity);
                await _context.SaveChangesAsync();
                return ResponseFactory.Ok(entity);
            }

            catch (Exception e)
            {
                Debug.WriteLine(e);
                return ResponseFactory.Error(e.Message);
            }
        }

        public virtual async Task<ResponseResult> GetAllAsync()
        {
            try
            {
                IEnumerable<TEntity> result = await _context.Set<TEntity>().ToListAsync();
                return ResponseFactory.Ok(result);
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
                return ResponseFactory.Error(e.Message);
            }

        }

        public virtual async Task<ResponseResult> GetOneAsync(Expression<Func<TEntity, bool>> predicate)
        {
            try
            {
                var result = await _context.Set<TEntity>().FirstOrDefaultAsync(predicate);
                if (result == null)
                {
                    return ResponseFactory.NotFound();
                }

                return ResponseFactory.Ok(result);
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
                return ResponseFactory.Error(e.Message);
            }
        }

        public virtual async Task<ResponseResult> UpdateOneAsync(Expression<Func<TEntity, bool>> predicate, TEntity updatedEntity)
        {
            try
            {
                var result = await _context.Set<TEntity>().FirstOrDefaultAsync(predicate);
                if (result != null)
                {
                    _context.Entry(result).CurrentValues.SetValues(updatedEntity);
                    await _context.SaveChangesAsync();
                    return ResponseFactory.Ok(result);
                }

                return ResponseFactory.NotFound();
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
                return ResponseFactory.Error(e.Message);
            }
        }

        public virtual async Task<ResponseResult> DeleteOneAsync(Expression<Func<TEntity, bool>> predicate)
        {
            try
            {
                var result = await _context.Set<TEntity>().FirstOrDefaultAsync(predicate);
                if (result != null)
                {
                    _context.Set<TEntity>().Remove(result);
                    await _context.SaveChangesAsync();
                    return ResponseFactory.Ok("Successfully Removed");
                }

                return ResponseFactory.NotFound();
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
                return ResponseFactory.Error(e.Message);
            }
        }

        public virtual async Task<ResponseResult> AlreadyExistsAsync(Expression<Func<TEntity, bool>> predicate)
        {
            try
            {
                var result = await _context.Set<TEntity>().AnyAsync(predicate);
                if (result)
                {
                    return ResponseFactory.Exists();
                }

                return ResponseFactory.NotFound();
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
                return ResponseFactory.Error(e.Message);
            }
        }


    }


}
