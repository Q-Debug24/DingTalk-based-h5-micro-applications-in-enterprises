using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Top.Api.Util;
using Top.Api;
using Top.Api.DingTalk;

namespace DingTalk.Api.Request
{
    /// <summary>
    /// TOP API: dingtalk.oapi.smartapp.form.instance.add
    /// </summary>
    public class OapiSmartappFormInstanceAddRequest : BaseDingTalkRequest<DingTalk.Api.Response.OapiSmartappFormInstanceAddResponse>
    {
        /// <summary>
        /// 表单应用ID
        /// </summary>
        public string AppUuid { get; set; }

        /// <summary>
        /// 插入数据列表
        /// </summary>
        public string DataList { get; set; }

        public List<FormInstanceWriteUnitVoDomain> DataList_ { set { this.DataList = TopUtils.ObjectToJson(value); } } 

        /// <summary>
        /// 表单ID
        /// </summary>
        public string FormCode { get; set; }

        /// <summary>
        /// 操作人ID
        /// </summary>
        public string OperatorUserid { get; set; }

        #region IDingTalkRequest Members

        public override string GetApiName()
        {
            return "dingtalk.oapi.smartapp.form.instance.add";
        }

        public override string GetApiCallType()
        {
            return DingTalkConstants.CALL_TYPE_OAPI;
        }

        public override IDictionary<string, string> GetParameters()
        {
            TopDictionary parameters = new TopDictionary();
            parameters.Add("app_uuid", this.AppUuid);
            parameters.Add("data_list", this.DataList);
            parameters.Add("form_code", this.FormCode);
            parameters.Add("operator_userid", this.OperatorUserid);
            if (this.otherParams != null)
            {
                parameters.AddAll(this.otherParams);
            }
            return parameters;
        }

        public override void Validate()
        {
            RequestValidator.ValidateRequired("app_uuid", this.AppUuid);
            RequestValidator.ValidateObjectMaxListSize("data_list", this.DataList, 50);
            RequestValidator.ValidateRequired("form_code", this.FormCode);
            RequestValidator.ValidateRequired("operator_userid", this.OperatorUserid);
        }

	/// <summary>
/// FormDataDomain Data Structure.
/// </summary>
[Serializable]

public class FormDataDomain : TopObject
{
	        /// <summary>
	        /// 扩展值
	        /// </summary>
	        [XmlElement("extend_value")]
	        public string ExtendValue { get; set; }
	
	        /// <summary>
	        /// 组件字段名
	        /// </summary>
	        [XmlElement("name")]
	        public string Name { get; set; }
	
	        /// <summary>
	        /// 组件值
	        /// </summary>
	        [XmlElement("value")]
	        public string Value { get; set; }
}

	/// <summary>
/// FormInstanceWriteUnitVoDomain Data Structure.
/// </summary>
[Serializable]

public class FormInstanceWriteUnitVoDomain : TopObject
{
	        /// <summary>
	        /// 业务主键
	        /// </summary>
	        [XmlElement("biz_id")]
	        public string BizId { get; set; }
	
	        /// <summary>
	        /// 数据负责人ID列表
	        /// </summary>
	        [XmlArray("charger_userid_list")]
	        [XmlArrayItem("string")]
	        public List<string> ChargerUseridList { get; set; }
	
	        /// <summary>
	        /// 数据创建人ID
	        /// </summary>
	        [XmlElement("creator_userid")]
	        public string CreatorUserid { get; set; }
	
	        /// <summary>
	        /// 组件值列表
	        /// </summary>
	        [XmlArray("form_component_values")]
	        [XmlArrayItem("form_data")]
	        public List<FormDataDomain> FormComponentValues { get; set; }
	
	        /// <summary>
	        /// 协同人ID列表
	        /// </summary>
	        [XmlArray("participant_userid_list")]
	        [XmlArrayItem("string")]
	        public List<string> ParticipantUseridList { get; set; }
}

        #endregion
    }
}
