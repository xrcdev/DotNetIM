using System;
using System.Collections.Generic;
using System.Text;
using im.sdk.entity.Vo;

namespace im.sdk.entity.Response
{
    public class ContsCtsListResponse: Response
    {
        private List<ConCtsVo> _conCtsVos;
        public ContsCtsListResponse(List<ConCtsVo> conCtsVos)
        {
            _conCtsVos = conCtsVos;
        }
        /// <summary>
        /// 获取联系人列表
        /// </summary>
        /// <returns></returns>
        public List<ConCtsVo> GetConCtsList()
        {
            return _conCtsVos;
        }

    }
}
