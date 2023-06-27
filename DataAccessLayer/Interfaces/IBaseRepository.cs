using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Interfaces;

/// <summary>
/// Interface for the base repository
/// </summary>
/// <typeparam name="TEntity"></typeparam>
public interface IBaseRepository<TEntity> where TEntity : IEntity
{
    public List<TEntity> Load();

    public int Create(TEntity entity);

    public TEntity Read(int id);

    public void Update(TEntity entity);

    public void Delete(TEntity entity);
}
