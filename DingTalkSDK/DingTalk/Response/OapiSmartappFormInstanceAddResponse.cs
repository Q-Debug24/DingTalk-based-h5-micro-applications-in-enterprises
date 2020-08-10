using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Top.Api;

namespace DingTalk.Api.Response
{
    /// <summary>
    /// OapiSmartappFormInstanceAddResponse.
    /// </summary>
    public class OapiSmartappFormInstanceAddResponse : DingTalkResponse
    {
        /// <summary>
        /// 错误码
        /// </summary>
        [XmlElement("errcode")]
        public long Errcode { get; set; }

        /// <summary>
        /// 错误信息
        /// </summary>
        [XmlElement("errmsg")]
        public string Errmsg { get; set; }

        /// <summary>
        /// 导入错误信息
        /// </summary>
        [XmlArray("result")]
        [XmlArrayItem("form_instance_write_error_vo")]
        public List<FormInstanceWriteErrorVoDomain> Result { get; set; }

        /// <summary>
        /// 执行结果
        /// </summary>
        [XmlElement("success")]
        public bool Success { get; set; }

	/// <summary>
/// FormInstanceWriteErrorVoDomain Data Structure.
/// </summary>
[Serializable]

public class FormInstanceWriteErrorVoDomain : TopObject
{
	        /// <summary>
	        /// 发生错误的业务主键
	        /// </summary>
	        [XmlElement("biz_id")]
	        public string BizId { get; set; }
	
	        /// <summary>
	        /// 该数据导入的错误信息
	        /// </summary>
	        [XmlElement("error_msg")]
	        public string ErrorMsg { get; set; }
}

    }
}
