using DingTalk.Api;
using DingTalk.Api.Request;
using DingTalk.Api.Response;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace DingDingPuls.Controllers
{
    public class DingTalkController : Controller
    {
        public IConfiguration Configuration { get; }
        public string UserId;
        public string Code;
        public string Token;

        public DingTalkController(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        //自动获取access_token，有效期为7200秒，两个小时后进行服务端接口的调用需要再次获取
        public string GetAuthToken()
        {
            IDingTalkClient client = new DefaultDingTalkClient("https://oapi.dingtalk.com/gettoken");
            OapiGettokenRequest request = new OapiGettokenRequest();

            request.Appkey = Configuration["Appkey"];
            request.Appsecret = Configuration["AppSecret"];

            request.SetHttpMethod("GET");
            OapiGettokenResponse response = client.Execute(request);
            if (!string.IsNullOrEmpty(response.AccessToken))
            {
                Token = response.AccessToken;
                return Token;
            }
            return response.Errmsg;
        }

        //获取钉钉用户的userid
        //获取免登授权码，有效期5分钟
        public IActionResult GetUserInfo(string code)
        {
            IDingTalkClient client = new DefaultDingTalkClient("https://oapi.dingtalk.com/user/getuserinfo");
            OapiUserGetuserinfoRequest req = new OapiUserGetuserinfoRequest();
            //req.Code = Request.Form["code"].ToString();
            if (string.IsNullOrEmpty(code))
            {
                return Json(" 空 code");
            }
            req.Code = code;
            req.SetHttpMethod("GET");

            OapiUserGetuserinfoResponse rsp = client.Execute(req, GetAuthToken());
            if (!string.IsNullOrEmpty(rsp.Userid))
            {
                UserId = rsp.Userid;
            }
            return Json(rsp.Body);
        }

        //发送工作消息
        public IActionResult SendWrokMsg(string userid, string masg)
        {
            IDingTalkClient client = new DefaultDingTalkClient("https://oapi.dingtalk.com/topapi/message/corpconversation/asyncsend_v2");
            OapiMessageCorpconversationAsyncsendV2Request req = new OapiMessageCorpconversationAsyncsendV2Request();
            req.AgentId = 781xxxx;

            req.UseridList = userid;
            // req.ToAllUser = true;
            OapiMessageCorpconversationAsyncsendV2Request.MsgDomain obj1 = new OapiMessageCorpconversationAsyncsendV2Request.MsgDomain();
            obj1.Msgtype = "text";
            OapiMessageCorpconversationAsyncsendV2Request.TextDomain obj2 = new OapiMessageCorpconversationAsyncsendV2Request.TextDomain();
            obj2.Content = masg;
            obj1.Text = obj2;
            req.Msg_ = obj1;
            OapiMessageCorpconversationAsyncsendV2Response rsp = client.Execute(req, GetAuthToken());

            return Json(rsp);
        }
    }
}