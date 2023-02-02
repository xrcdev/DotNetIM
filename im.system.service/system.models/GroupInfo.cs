using System;
using System.Linq;
using System.Text;
using SqlSugar;

namespace system.models
{
    ///<summary>
    ///群里消息
    ///</summary>
    [SugarTable("im_groupInfo")]
    public partial class GroupInfo
    {
           public GroupInfo(){


           }
           /// <summary>
           /// Desc:
           /// Default:
           /// Nullable:False
           /// </summary>           
           [SugarColumn(IsPrimaryKey=true,IsIdentity=true,ColumnName="id")]
           public int Id {get;set;}

           /// <summary>
           /// Desc:群聊名称
           /// Default:
           /// Nullable:True
           /// </summary>           
           [SugarColumn(ColumnName="group_title")]
           public int? Group_title {get;set;}

           /// <summary>
           /// Desc:群聊头像
           /// Default:
           /// Nullable:True
           /// </summary>           
           [SugarColumn(ColumnName="group_headsrc")]
           public string Group_headsrc {get;set;}

           /// <summary>
           /// Desc:群聊介绍
           /// Default:
           /// Nullable:True
           /// </summary>           
           [SugarColumn(ColumnName="group_introduce")]
           public string Group_introduce {get;set;}

           /// <summary>
           /// Desc:创建时间
           /// Default:
           /// Nullable:True
           /// </summary>           
           [SugarColumn(ColumnName="create_time")]
           public DateTime? Create_time {get;set;}

           /// <summary>
           /// Desc:创建人
           /// Default:
           /// Nullable:True
           /// </summary>           
           [SugarColumn(ColumnName="group_userid")]
           public int? Group_userid {get;set;}

    }
}
