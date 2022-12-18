 
using IM_Router.untils;
using SqlSugar;
using System.Linq.Expressions;

namespace IM_Router.Dao
{
    public  class Repository<T>: SimpleClient<T> where T : class, new() {

       
        public Repository(ISqlSugarClient context = null) : base(context)//注意这里要有默认值等于null
        {
            base.Context = SugarClientUntils.db;
        }
         
    }
}
