using DataAccessLayer.Entities;
using Microsoft.Data.SqlClient;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using DataAccessLayer.Interfaces;
using System.Data.Common;
using System.Reflection;

namespace DataAccessLayer.Repositories;

/// <summary>
/// Base repository for all repositories.
/// </summary>
/// <typeparam name="TEntity"></typeparam>
public abstract class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : IEntity, new()
{
    [Required]
    protected readonly string _connectionString;

    public BaseRepository(DbConnectionStringBuilder connectionBuilder)
    {
        _connectionString = connectionBuilder.ConnectionString;
    }

    /// <summary>
    /// Returns list of all entities from database.
    /// </summary>
    /// <returns></returns>
    public List<TEntity> Load()
    {
        List<TEntity> entities = new();
        string tableName = GetTypeName();

        using (SqlConnection connection = new(_connectionString))
        {

            SqlCommand command = new($"SELECT * FROM {tableName}", connection)
            {
                CommandType = CommandType.Text
            };

            try
            {
                connection.Open();
                var returnValue = ExecuteReadEntitiesCommand(command).ToList();
                Trace.WriteLine($"Successfully loaded {tableName} entities");
                return returnValue;
            }
            catch(Exception ex)
            {
                Trace.WriteLine($"Couldn't load {tableName} entities.\n{ex.Message}");
                throw;
            }
            finally
            {
                connection.Close();
            }
        }
    }    
    
    /// <summary>
    /// Adds entity in database.
    /// </summary>
    /// <param name="entity"></param>
    /// <returns></returns>
    public int Create(TEntity entity)
    {
        using (SqlConnection connection = new(_connectionString))
        {
            SqlCommand command = GetCreateCommand(entity);
            command.Connection = connection;

            try
            {
                connection.Open();
                command.ExecuteNonQuery();
                Trace.WriteLine($"Successfully created {GetTypeName()} entity with data\n{entity}");
                return entity.Id;
            }
            catch (Exception ex)
            {
                Trace.WriteLine($"Couldn't create entity from {GetTypeName()} with data\n{entity}.\n{ex.Message}");
                throw;
            }
            finally
            {
                connection.Close();
            }
        }
    }

    /// <summary>
    /// Reads entity from database with given id.
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public TEntity Read(int id)
    {
        string tableName = GetTypeName();

        using (SqlConnection connection = new(_connectionString))
        {

            SqlCommand command = new($"SELECT * FROM {tableName} WHERE {tableName}Id = {id}", connection)
            {
                CommandType = CommandType.Text
            };

            try
            {
                connection.Open();
                var returnValue = ExecuteReadEntitiesCommand(command).Single();
                Trace.WriteLine($"Successfully read {GetTypeName()} entity with id: {id}");
                return returnValue;
            }
            catch (Exception ex)
            {
                Trace.WriteLine($"Couldn't read entity from {tableName} with id = {id}.\n{ex.Message}");
                throw;
            }
            finally
            {
                connection.Close();
            }
        }
    }

    /// <summary>
    /// Updates given entity in database.
    /// </summary>
    /// <param name="entity"></param>
    public void Update(TEntity entity)
    {
        using (SqlConnection connection = new(_connectionString))
        {
            SqlCommand command = GetUpdateCommand(entity);
            command.Connection = connection;

            try
            {
                connection.Open();
                command.ExecuteNonQuery();
                Trace.WriteLine($"Successfully updated {GetTypeName()} entity with id: {entity.Id}");
            }
            catch (Exception ex)
            {
                Trace.WriteLine($"Couldn't create entity from {GetTypeName()} with id:{entity.Id}.\n{ex.Message}");
                throw;
            }
            finally
            {
                connection.Close();
            }
        }
    }

    /// <summary>
    /// Deletes given entity from database.
    /// </summary>
    /// <param name="entity"></param>
    public void Delete(TEntity entity)
    {
        using (SqlConnection connection = new(_connectionString))
        {
            SqlCommand command = new($"DELETE FROM {GetTypeName()} WHERE id = {entity.Id}", connection)
            {
                CommandType = CommandType.Text
            };

            try
            {
                connection.Open();
                command.ExecuteNonQuery();
                Trace.WriteLine($"Successfully deleted {GetTypeName()} entity with id: {entity.Id}");
            }
            catch (Exception ex)
            {
                Trace.WriteLine($"Couldn't delete entity from {GetTypeName()} with id = {entity.Id}.\n{ex.Message}");
                throw;
            }
            finally
            {
                connection.Close();
            }
        }
    }

    /// <summary>
    /// Executes given command.
    /// </summary>
    /// <param name="command">sql command to execute</param>
    /// <returns>List of data selected from given command</returns>
    private IEnumerable<TEntity> ExecuteReadEntitiesCommand(SqlCommand command)
    {
        using (SqlDataReader reader = command.ExecuteReader())
        {
            while (reader.Read())
            {
                yield return ReadCurrentEntity(reader);
            }
        }
    }

    /// <summary>
    /// </summary>
    /// <returns>Name of the TEntity in runtime.</returns>
    private string GetTypeName()
    {
        string name = typeof(TEntity).Name;
        return name;
    }

    /// <summary>
    /// Returns current entity in SqlDataReader
    /// </summary>
    /// <param name="reader">SqlDataReader where the entity should be read from</param>
    /// <returns>Current enetity in reader</returns>
    protected TEntity ReadCurrentEntity(SqlDataReader reader)
    {
        PropertyInfo[] properties = typeof(TEntity).GetProperties();

        TEntity entity = new();

        int index = 0;
        foreach(var property in properties)
        {
            property.SetValue(entity, reader.GetValue(index));
            index++;
        }

        return entity;
    }

    /// <summary>
    /// Returns update command for given entity.
    /// </summary>
    /// <param name="entity"></param>
    /// <returns></returns>
    protected SqlCommand GetUpdateCommand(TEntity entity)
    {
        string[] zippedArguments = GetEntityPropertyNames(false).Zip(GetEntityPropertyParameterNames(false), (string s1, string s2) => $"{s1}  = {s2}").ToArray();
        string arguments = string.Join(", ", zippedArguments);
        string createSql = $"UPDATE {typeof(TEntity).Name} SET\n{arguments}\nWHERE id = @id";

        using (SqlCommand command = new())
        {
            command.CommandType = CommandType.Text;
            command.CommandText = createSql;

            return InsertParametersInCommand(command, entity);
        }
    }

    /// <summary>
    /// Returns create command for given entity.
    /// </summary>
    /// <param name="entity"></param>
    /// <returns></returns>
    protected SqlCommand GetCreateCommand(TEntity entity)
    {
        string arguments = "(" + string.Join(", ", GetEntityPropertyNames(false)) + ")";
        string parameters = "(" + string.Join(", ", GetEntityPropertyParameterNames(false)) + ")";

        string createSql = $"INSERT INTO {typeof(TEntity).Name}\n{arguments} Values\n{parameters}";

        using (SqlCommand command = new())
        {
            command.CommandType = CommandType.Text;
            command.CommandText = createSql;

            return InsertParametersInCommand(command, entity);
        }
    }

    /// <summary>
    /// Inserts parameters from given entity into given command.
    /// </summary>
    /// <param name="command"></param>
    /// <param name="entity"></param>
    /// <returns></returns>
    protected SqlCommand InsertParametersInCommand(SqlCommand command, TEntity entity)
    {
        PropertyInfo[] properties = typeof(TEntity).GetProperties();

        foreach (var property in properties)
        {
            object propertyValue = property.GetValue(entity, null)!;

            command.Parameters.AddWithValue($"@{property.Name}", propertyValue);
        }

        return command;
    }

    /// <summary>
    /// Returns array of property names of TEntity.
    /// </summary>
    /// <param name="withId"></param>
    /// <returns></returns>
    private string[] GetEntityPropertyNames(bool withId = true)
    {
        return typeof(TEntity).GetProperties().Select(p => p.Name).Where(name => name != "Id" || withId).ToArray();
    }

    /// <summary>
    /// Returns array of property names of TEntity with @ prefix.
    /// </summary>
    /// <param name="withId"></param>
    /// <returns></returns>
    private string[] GetEntityPropertyParameterNames(bool withId = true)
    {
        return typeof(TEntity).GetProperties().Select(p => "@" + p.Name).Where(name => name != "@Id" || withId).ToArray().ToArray();
    }
}