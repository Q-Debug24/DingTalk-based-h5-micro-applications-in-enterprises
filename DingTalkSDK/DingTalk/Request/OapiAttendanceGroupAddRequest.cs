using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Top.Api.Util;
using Top.Api;
using Top.Api.DingTalk;

namespace DingTalk.Api.Request
{
    /// <summary>
    /// TOP API: dingtalk.oapi.attendance.group.add
    /// </summary>
    public class OapiAttendanceGroupAddRequest : BaseDingTalkRequest<DingTalk.Api.Response.OapiAttendanceGroupAddResponse>
    {
        /// <summary>
        /// 操作人id
        /// </summary>
        public string OpUserId { get; set; }

        /// <summary>
        /// 考勤组信息
        /// </summary>
        public string TopGroup { get; set; }

        public TopGroupVoDomain TopGroup_ { set { this.TopGroup = TopUtils.ObjectToJson(value); } } 

        #region IDingTalkRequest Members

        public override string GetApiName()
        {
            return "dingtalk.oapi.attendance.group.add";
        }

        public override string GetApiCallType()
        {
            return DingTalkConstants.CALL_TYPE_OAPI;
        }

        public override IDictionary<string, string> GetParameters()
        {
            TopDictionary parameters = new TopDictionary();
            parameters.Add("op_user_id", this.OpUserId);
            parameters.Add("top_group", this.TopGroup);
            if (this.otherParams != null)
            {
                parameters.AddAll(this.otherParams);
            }
            return parameters;
        }

        public override void Validate()
        {
            RequestValidator.ValidateRequired("op_user_id", this.OpUserId);
            RequestValidator.ValidateRequired("top_group", this.TopGroup);
        }

	/// <summary>
/// TopPositionVoDomain Data Structure.
/// </summary>
[Serializable]

public class TopPositionVoDomain : TopObject
{
	        /// <summary>
	        /// 精度
	        /// </summary>
	        [XmlElement("accuracy")]
	        public string Accuracy { get; set; }
	
	        /// <summary>
	        /// 地址
	        /// </summary>
	        [XmlElement("address")]
	        public string Address { get; set; }
	
	        /// <summary>
	        /// corpId
	        /// </summary>
	        [XmlElement("corp_id")]
	        public string CorpId { get; set; }
	
	        /// <summary>
	        /// 纬度
	        /// </summary>
	        [XmlElement("latitude")]
	        public string Latitude { get; set; }
	
	        /// <summary>
	        /// 经度
	        /// </summary>
	        [XmlElement("longitude")]
	        public string Longitude { get; set; }
	
	        /// <summary>
	        /// 标题
	        /// </summary>
	        [XmlElement("title")]
	        public string Title { get; set; }
}

	/// <summary>
/// TopShiftVoDomain Data Structure.
/// </summary>
[Serializable]

public class TopShiftVoDomain : TopObject
{
	        /// <summary>
	        /// 班次id
	        /// </summary>
	        [XmlElement("id")]
	        public Nullable<long> Id { get; set; }
}

	/// <summary>
/// TopMemberVoDomain Data Structure.
/// </summary>
[Serializable]

public class TopMemberVoDomain : TopObject
{
	        /// <summary>
	        /// corpId
	        /// </summary>
	        [XmlElement("corp_id")]
	        public string CorpId { get; set; }
	
	        /// <summary>
	        /// 角色
	        /// </summary>
	        [XmlElement("role")]
	        public string Role { get; set; }
	
	        /// <summary>
	        /// 类型
	        /// </summary>
	        [XmlElement("type")]
	        public string Type { get; set; }
	
	        /// <summary>
	        /// 用户id
	        /// </summary>
	        [XmlElement("user_id")]
	        public string UserId { get; set; }
}

	/// <summary>
/// TopGroupVoDomain Data Structure.
/// </summary>
[Serializable]

public class TopGroupVoDomain : TopObject
{
	        /// <summary>
	        /// 打卡是否需要健康码
	        /// </summary>
	        [XmlElement("check_need_healthy_code")]
	        public Nullable<bool> CheckNeedHealthyCode { get; set; }
	
	        /// <summary>
	        /// corpId
	        /// </summary>
	        [XmlElement("corp_id")]
	        public string CorpId { get; set; }
	
	        /// <summary>
	        /// 是否开启拍照打卡
	        /// </summary>
	        [XmlElement("enable_camera_check")]
	        public Nullable<bool> EnableCameraCheck { get; set; }
	
	        /// <summary>
	        /// 未排班时允许员工选择班次打卡
	        /// </summary>
	        [XmlElement("enable_emp_select_class")]
	        public Nullable<bool> EnableEmpSelectClass { get; set; }
	
	        /// <summary>
	        /// 是否开启人脸检测
	        /// </summary>
	        [XmlElement("enable_face_check")]
	        public Nullable<bool> EnableFaceCheck { get; set; }
	
	        /// <summary>
	        /// 是否开启外勤打卡必须拍照
	        /// </summary>
	        [XmlElement("enable_outside_camera_check")]
	        public Nullable<bool> EnableOutsideCameraCheck { get; set; }
	
	        /// <summary>
	        /// 是否可以外勤打卡
	        /// </summary>
	        [XmlElement("enable_outside_check")]
	        public Nullable<bool> EnableOutsideCheck { get; set; }
	
	        /// <summary>
	        /// 考勤组id
	        /// </summary>
	        [XmlElement("id")]
	        public Nullable<long> Id { get; set; }
	
	        /// <summary>
	        /// 考勤组成员
	        /// </summary>
	        [XmlArray("members")]
	        [XmlArrayItem("top_member_vo")]
	        public List<TopMemberVoDomain> Members { get; set; }
	
	        /// <summary>
	        /// 是否有修改考勤组成员相关信息
	        /// </summary>
	        [XmlElement("modify_member")]
	        public Nullable<bool> ModifyMember { get; set; }
	
	        /// <summary>
	        /// 考勤组名
	        /// </summary>
	        [XmlElement("name")]
	        public string Name { get; set; }
	
	        /// <summary>
	        /// 考勤组owner
	        /// </summary>
	        [XmlElement("owner")]
	        public string Owner { get; set; }
	
	        /// <summary>
	        /// 考勤地址
	        /// </summary>
	        [XmlArray("positions")]
	        [XmlArrayItem("top_position_vo")]
	        public List<TopPositionVoDomain> Positions { get; set; }
	
	        /// <summary>
	        /// 班次信息
	        /// </summary>
	        [XmlArray("shift_vo_list")]
	        [XmlArrayItem("top_shift_vo")]
	        public List<TopShiftVoDomain> ShiftVoList { get; set; }
	
	        /// <summary>
	        /// 是否跳过节假日
	        /// </summary>
	        [XmlElement("skip_holidays")]
	        public Nullable<bool> SkipHolidays { get; set; }
	
	        /// <summary>
	        /// 特殊日期配置
	        /// </summary>
	        [XmlElement("special_days")]
	        public string SpecialDays { get; set; }
	
	        /// <summary>
	        /// 考勤组类型
	        /// </summary>
	        [XmlElement("type")]
	        public string Type { get; set; }
}

        #endregion
    }
}
