using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Top.Api;

namespace DingTalk.Api.Response
{
    /// <summary>
    /// OapiRetailUserTokenCheckResponse.
    /// </summary>
    public class OapiRetailUserTokenCheckResponse : DingTalkResponse
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
        /// xx
        /// </summary>
        [XmlElement("result")]
        public UserBindDtoDomain Result { get; set; }

        /// <summary>
        /// 成功失败
        /// </summary>
        [XmlElement("success")]
        public bool Success { get; set; }

	/// <summary>
/// UserBindDtoDomain Data Structure.
/// </summary>
[Serializable]

public class UserBindDtoDomain : TopObject
{
	        /// <summary>
	        /// 中心组织唯一ID
	        /// </summary>
	        [XmlElement("associate_union_id")]
	        public string AssociateUnionId { get; set; }
	
	        /// <summary>
	        /// 扩展字段
	        /// </summary>
	        [XmlElement("extension")]
	        public string Extension { get; set; }
}

    }
}
