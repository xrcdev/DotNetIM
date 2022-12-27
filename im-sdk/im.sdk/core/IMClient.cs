using im.sdk.entity.Request;
using im.sdk.entity.Response;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace im.sdk.client
{
    /// <summary>
    /// 
    /// </summary>
    public interface IMClient
    {
        /// <summary>
        /// 获取联系人列表
        /// </summary>
        /// <returns></returns>
        Task<ContsCtsListResponse> getContsCtsListResponse(ContsCtsListRequest req);


        /// <summary>
        /// 获取联系人列表
        /// </summary>
        /// <returns></returns>
        Task<LoginReponse> getLoginResponse(LoginRequest req);


        Task<ImServerAddrResponse> getServerAddrResponse(ServerAddrRequest req);

        Task<Response> getResponse(RegistRequest req);


        Task<Response> SendTxtMessage(TxtMessageRequest req);


        Task<Response> SendStreamMessage(TxtMessageRequest req);


    }
}
