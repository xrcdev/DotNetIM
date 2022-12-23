 
using SqlSugar;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace system.repository
{
    public  class Repository<T>: SimpleClient<T> where T : class, new() {

       
        public Repository(ISqlSugarClient context = null) : base(context)//注意这里要有默认值等于null
        {
            base.Context = SugarClientUntils.db;
        }
 
         
    }
}
