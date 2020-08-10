using System;
using System.Collections.Generic;
using Top.Api.Util;
using Top.Api;
using Top.Api.DingTalk;

namespace DingTalk.Api.Request
{
    /// <summary>
    /// TOP API: dingtalk.oapi.robot.message.sendorggroup
    /// </summary>
    public class OapiRobotMessageSendorggroupRequest : BaseDingTalkRequest<DingTalk.Api.Response.OapiRobotMessageSendorggroupResponse>
    {
        /// <summary>
        /// 申请到的企业机器人唯一标识符
        /// </summary>
        public string ChatbotId { get; set; }

        /// <summary>
        /// 申请到的消息模板唯一标识符
        /// </summary>
        public string MsgKey { get; set; }

        /// <summary>
        /// 消息模板中，变量本次替换的值
        /// </summary>
        public string MsgParam { get; set; }

        /// <summary>
        /// 开放的群ID
        /// </summary>
        public string OpenConversationId { get; set; }

        #region IDingTalkRequest Members

        public override string GetApiName()
        {
            return "dingtalk.oapi.robot.message.sendorggroup";
        }

        public override string GetApiCallType()
        {
            return DingTalkConstants.CALL_TYPE_OAPI;
        }

        public override IDictionary<string, string> GetParameters()
        {
            TopDictionary parameters = new TopDictionary();
            parameters.Add("chatbot_id", this.ChatbotId);
            parameters.Add("msg_key", this.MsgKey);
            parameters.Add("msg_param", this.MsgParam);
            parameters.Add("open_conversation_id", this.OpenConversationId);
            if (this.otherParams != null)
            {
                parameters.AddAll(this.otherParams);
            }
            return parameters;
        }

        public override void Validate()
        {
            RequestValidator.ValidateRequired("chatbot_id", this.ChatbotId);
            RequestValidator.ValidateRequired("msg_key", this.MsgKey);
            RequestValidator.ValidateRequired("msg_param", this.MsgParam);
            RequestValidator.ValidateRequired("open_conversation_id", this.OpenConversationId);
        }

        #endregion
    }
}
