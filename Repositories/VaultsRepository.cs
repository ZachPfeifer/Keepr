using System;
using System.Collections.Generic;
using System.Data;
using Keepr.Models;
using Dapper;


namespace Keepr.Repositories
{
  public class VaultsRepository
  {
    private readonly IDbConnection _db;
    public VaultsRepository(IDbConnection db)
    {
      _db = db;
    }

    public IEnumerable<Vault> Get()
    {
      string sql = "SELECT * FROM vaults";
      return _db.Query<Vault>(sql);
    }

    public Vault Get(int id)
    {
      string sql = "SELECT * FROM vaults WHERE id = @id";
      return _db.QueryFirstOrDefault<Vault>(sql, new { id });
    }
    public IEnumerable<Vault> GetUsersVaults(string userId)
    {
      string sql = "SELECT * FROM vaults WHERE userId = @userId";
      return _db.Query<Vault>(sql, new { userId });
    }

    public int Create(Vault newVault)
    {
      string sql = @"
            INSERT INTO vaults
            (name, description, userId)
            VALUES
            (@Name, @Description, @UserId);
            SELECT LAST_INSERT_ID();";
      return _db.ExecuteScalar<int>(sql, newVault);
    }

    public void Edit(Vault vault)
    {
      string sql = @"
            UPDATE vaults
            SET
                name = @Name,
                description = @Description,
              
                userId = @UserId

            WHERE id = @Id";

      _db.Execute(sql, vault);

    }

    public void Delete(int id)
    {
      string sql = "DELETE FROM vaults WHERE id = @id";
      _db.Execute(sql, new { id });
    }
  }
}
