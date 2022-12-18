using System;
using System.Linq;
using System.Text;
using SqlSugar;

namespace Auth.Models
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

    }
}
