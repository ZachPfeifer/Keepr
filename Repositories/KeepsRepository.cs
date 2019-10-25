using System;
using System.Collections.Generic;
using System.Data;
using Keepr.Models;
using Dapper;


namespace Keepr.Repositories
{
  public class KeepsRepository
  {
    private readonly IDbConnection _db;
    public KeepsRepository(IDbConnection db)
    {
      _db = db;
    }

    public IEnumerable<Keep> Get()
    {
      string sql = "SELECT * FROM keeps";
      return _db.Query<Keep>(sql);
    }

    public Keep Get(int id)
    {
      string sql = "SELECT * FROM keeps WHERE id = @id";
      return _db.QueryFirstOrDefault<Keep>(sql, new { id });
    }
    public IEnumerable<Keep> GetUsersKeeps(string userId)
    {
      string sql = "SELECT * FROM keeps WHERE userId = @userId";
      return _db.Query<Keep>(sql, new { userId });
    }

    public int Create(Keep newKeep)
    {
      string sql = @"
            INSERT INTO keeps
            (name, description, img, isPrivate, userId)
            VALUES
            (@Name, @Description, @Img, @isPrivate, @UserId);
            SELECT LAST_INSERT_ID();";
      return _db.ExecuteScalar<int>(sql, newKeep);
      //views, shares, keeps,
      // @Views, @Shares, @Keeps,
    }

    public void Edit(Keep keep)
    {
      string sql = @"
            UPDATE keeps
            SET

                isPrivate = @isPrivate,
                views = @Views,
                shares = @Shares,
                keeps = @Keeps
            WHERE id = @Id";

      _db.Execute(sql, keep);

    }

    public void Delete(int id)
    {
      string sql = "DELETE FROM keeps WHERE id = @id";
      _db.Execute(sql, new { id });
    }

    // public IEnumerable<Keep> GetTagsByKeepId(string keepId)
    // {
    //   string sql = @"
    //             SELECT * FROM keepstagss ko
    //             INNER JOIN tagss t ON t.id = ko.tagId
    //             WHERE so.keepId = @keepId
    //         ";
    //   return _db.Query<Keep>(sql, new { keepId });
    // }

    // public void Counts(Keep count) //FIXME
    // {
    //   string sql = @"
    //   INSERT INTO keeps
    //    VALUES (1,0);
    //     UPDATE keeps SET views = views+1 WHERE id = 1";
    //   //UPDATE keeps SET views = views+1 WHERE id = 'SOME NUMBER'

    //   _db.Execute(sql, count);

    // }
  }
}