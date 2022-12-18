using System;
using System.Linq;
using System.Text;
using SqlSugar;

namespace service.models
{
    ///<summary>
    ///用户表
    ///</summary>
    [SugarTable("im_user")]
    public partial class User
    {
           public User(){


           }
           /// <summary>
           /// Desc:userid
           /// Default:
           /// Nullable:False
           /// </summary>           
           [SugarColumn(IsPrimaryKey=true,IsIdentity=true,ColumnName="id")]
           public int Id {get;set;}

           /// <summary>
           /// Desc:用户名
           /// Default:
           /// Nullable:False
           /// </summary>           
           [SugarColumn(ColumnName="username")]
           public string Username {get;set;}

           /// <summary>
           /// Desc:密码
           /// Default:
           /// Nullable:False
           /// </summary>           
           [SugarColumn(ColumnName="password")]
           public string Password {get;set;}

           /// <summary>
           /// Desc:保存头像对应的oss地址
           /// Default:
           /// Nullable:True
           /// </summary>           
           [SugarColumn(ColumnName="headsrc")]
           public string Headsrc {get;set;}

           /// <summary>
           /// Desc:用户唯一id标识
           /// Default:
           /// Nullable:True
           /// </summary>           
           [SugarColumn(ColumnName="userTag")]
           public string UserTag {get;set;}

    }
}
