using im.sdk.entity.Vo;
using System;
using System.Collections.Generic;
using System.Text;

namespace im.sdk.entity.Response
{
    public class LoginReponse: Response
    {
        private LoginVo _Vo;
        public LoginReponse(LoginVo vo)
        {
            _Vo = vo;
        }

        public LoginVo getLoginVo()
        {
            return _Vo;
        }
    }
}
