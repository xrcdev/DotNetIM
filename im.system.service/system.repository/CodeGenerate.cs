using SqlSugar;
using System;
using DbType = SqlSugar.DbType;

namespace system.repository
{
    public class CodeGenerate
    {
        public void Start()
        {
            string constr = "Server=127.0.0.1;Port=3306;Database=im;Uid=root;Pwd=123456;charset=utf8;Allow User Variables=True";

            var db = new SqlSugarClient(new ConnectionConfig()
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
            string prefix = "im_";
            foreach (var item in db.DbMaintenance.GetTableInfoList())
            {
                string entityName = item.Name.Replace(prefix, "");//去除前缀

                entityName = FirstUpper(entityName);


                db.MappingTables.Add(entityName, item.Name);
                foreach (var col in db.DbMaintenance.GetColumnInfosByTableName(item.Name))
                {
                    string newName = FirstUpper(col.DbColumnName);
                    db.MappingColumns.Add(newName, col.DbColumnName, entityName);
                }
            }


            db.DbFirst.IsCreateAttribute().CreateClassFile("D:\\daima\\im\\Solution1\\im.system.service\\system.models\\", "system.models");

        }
        /// <summary>
        /// 首字母大写
        /// </summary>
        /// <param name="world"></param>
        /// <returns></returns>
        public string FirstUpper(string world)
        {
            return world.Replace(world[0].ToString(), world[0].ToString().ToUpper());

        }
    }
}
