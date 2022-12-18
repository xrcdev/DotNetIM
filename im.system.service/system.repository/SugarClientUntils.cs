using SqlSugar;
using System;

namespace system.repository
{
    public class SugarClientUntils
    {
        public static ISqlSugarClient db;

        public static void Init(string constr)
        {
 
            db = new SqlSugarClient(new ConnectionConfig()
            {
                ConnectionString = constr,
                DbType = DbType.MySql,
                IsAutoCloseConnection = true
            }, db =>
            {
                db.Aop.OnLogExecuting = (sql, pars) =>
                {
                    Console.WriteLine(sql);//输出sql,查看执行sql 性能无影响 
                };

            });
        }
    }
}
