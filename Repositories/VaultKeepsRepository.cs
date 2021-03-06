using System.Collections.Generic;
using System.Data;
using Dapper;
using Keepr.Models;

namespace Keepr.Repositories
{
  public class VaultKeepsRepository
  {

    private readonly IDbConnection _db;
    public VaultKeepsRepository(IDbConnection db)
    {
      _db = db;
    }
    // public IEnumerable<VaultKeep> Get()
    // {
    //   string sql = "SELECT * FROM vaultkeeps";
    //   return _db.Query<VaultKeep>(sql);
    // }
    // internal VaultKeep GetVaultKeep(VaultKeep vk)
    // {
    //   string sql = @"
    //   SELECT * FROM vaultkeeps
    //    WHERE vaultId = @VaultId
    //    AND keepId = @KeepId";
    //   return _db.QueryFirstOrDefault<VaultKeep>(sql, vk);
    // }

    public IEnumerable<Keep> GetVaultKeep(int vaultId, string userId)
    {
      string sql = @"
                SELECT * FROM vaultkeeps vk
                INNER JOIN keeps k ON k.id = vk.keepId
                WHERE (vaultId = @vaultId
                AND vk.userId = @userId)
            ";
      return _db.Query<Keep>(sql, new { vaultId, userId });
    }

    internal VaultKeep GetIds(int vaultId, int keepId)
    {
      string sql = "SELECT * FROM vaultkeeps WHERE vaultId = @VaultId AND keepId = @KeepId";
      return _db.QueryFirstOrDefault<VaultKeep>(sql, new { vaultId, keepId });
    }
    public int Create(VaultKeep newVaultKeep)
    {
      string sql = @"
            INSERT INTO vaultkeeps
            (keepId, vaultId, userId)
            VALUES
            (@KeepId, @VaultId, @UserId);
            SELECT LAST_INSERT_ID();";
      return _db.ExecuteScalar<int>(sql, newVaultKeep);
    }

    // public void Delete(VaultKeep vaultKeep)
    // {
    //   string sql = @"
    //         UPDATE vaults
    //         SET
    //             name = @Name,
    //             description = @Description,

    //             userId = @UserId

    //         WHERE id = @Id";

    //   _db.Execute(sql, vaultKeep);

    // }
    // public void Delete(int id)
    // {
    //   string sql = "DELETE FROM vaultkeeps WHERE id = @id";
    //   _db.Execute(sql, new { id });
    // }

    // public void RemoveKeepFromVault(int vaultId)
    // {
    //   string sql = "DELETE FROM vaultkeeps WHERE id = @id";
    //   _db.Execute(sql, new { vaultId });
    // }
    public void RemoveKeepFromKeeps(int id)
    {
      string sql = "DELETE FROM vaultkeeps WHERE id = @id";
      _db.Execute(sql, new { id });
    }

  }
}