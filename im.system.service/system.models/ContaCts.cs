using System;
using System.Linq;
using System.Text;
using SqlSugar;

namespace system.models
{
    ///<summary>
    ///保存联系人
    ///</summary>
    [SugarTable("im_contacts")]
    public partial class ContaCts
    {
           public ContaCts(){


           }
           /// <summary>
           /// Desc:
           /// Default:
           /// Nullable:False
           /// </summary>           
           [SugarColumn(IsPrimaryKey=true,IsIdentity=true,ColumnName="id")]
           public int Id {get;set;}

           /// <summary>
           /// Desc:用户id
           /// Default:
           /// Nullable:True
           /// </summary>           
           [SugarColumn(ColumnName="userid")]
           public int? Userid {get;set;}

           /// <summary>
           /// Desc:好友id
           /// Default:
           /// Nullable:True
           /// </summary>           
           [SugarColumn(ColumnName="contactid")]
           public int? ContaCtid {get;set;}

    }
}
