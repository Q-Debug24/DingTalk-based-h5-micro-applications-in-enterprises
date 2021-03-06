using System;
using System.Collections.Generic;
using Top.Api.Util;
using Top.Api;
using Top.Api.DingTalk;

namespace DingTalk.Api.Request
{
    /// <summary>
    /// TOP API: dingtalk.oapi.edu.group.msg.send
    /// </summary>
    public class OapiEduGroupMsgSendRequest : BaseDingTalkRequest<DingTalk.Api.Response.OapiEduGroupMsgSendResponse>
    {
        /// <summary>
        /// 订购此应用的企业标识
        /// </summary>
        public Nullable<long> AgentId { get; set; }

        /// <summary>
        /// 发送此消息的唯一ID
        /// </summary>
        public string BizId { get; set; }

        /// <summary>
        /// 班级id
        /// </summary>
        public Nullable<long> ClassId { get; set; }

        /// <summary>
        /// 群中哪些人接受此消息，不填默认全部
        /// </summary>
        public string ReceiveUseridList { get; set; }

        /// <summary>
        /// json串，按照不同的消息模板填写不同的json串
        /// </summary>
        public string Replace { get; set; }

        /// <summary>
        /// 群发消息模板id
        /// </summary>
        public string TemplateCode { get; set; }

        /// <summary>
        /// 发送消息人的员工id
        /// </summary>
        public string Userid { get; set; }

        #region IDingTalkRequest Members

        public override string GetApiName()
        {
            return "dingtalk.oapi.edu.group.msg.send";
        }

        public override string GetApiCallType()
        {
            return DingTalkConstants.CALL_TYPE_OAPI;
        }

        public override IDictionary<string, string> GetParameters()
        {
            TopDictionary parameters = new TopDictionary();
            parameters.Add("agent_id", this.AgentId);
            parameters.Add("biz_id", this.BizId);
            parameters.Add("class_id", this.ClassId);
            parameters.Add("receive_userid_list", this.ReceiveUseridList);
            parameters.Add("replace", this.Replace);
            parameters.Add("template_code", this.TemplateCode);
            parameters.Add("userid", this.Userid);
            if (this.otherParams != null)
            {
                parameters.AddAll(this.otherParams);
            }
            return parameters;
        }

        public override void Validate()
        {
            RequestValidator.ValidateRequired("agent_id", this.AgentId);
            RequestValidator.ValidateRequired("biz_id", this.BizId);
            RequestValidator.ValidateRequired("class_id", this.ClassId);
            RequestValidator.ValidateMaxListSize("receive_userid_list", this.ReceiveUseridList, 20);
            RequestValidator.ValidateRequired("template_code", this.TemplateCode);
            RequestValidator.ValidateRequired("userid", this.Userid);
        }

        #endregion
    }
}
