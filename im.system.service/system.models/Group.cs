using System;
using System.Linq;
using System.Text;
using SqlSugar;

namespace system.models
{
    ///<summary>
    ///
    ///</summary>
    [SugarTable("im_group")]
    public partial class Group
    {
           public Group(){


           }
           /// <summary>
           /// Desc:
           /// Default:
           /// Nullable:False
           /// </summary>           
           [SugarColumn(IsPrimaryKey=true,IsIdentity=true,ColumnName="id")]
           public int Id {get;set;}

           /// <summary>
           /// Desc:群聊id
           /// Default:
           /// Nullable:True
           /// </summary>           
           [SugarColumn(ColumnName="group_id")]
           public int? Group_id {get;set;}

           /// <summary>
           /// Desc:用户id
           /// Default:
           /// Nullable:True
           /// </summary>           
           [SugarColumn(ColumnName="user_id")]
           public int? User_id {get;set;}

           /// <summary>
           /// Desc:加入时间
           /// Default:
           /// Nullable:True
           /// </summary>           
           [SugarColumn(ColumnName="datetime")]
           public DateTime? Datetime {get;set;}

    }
}
