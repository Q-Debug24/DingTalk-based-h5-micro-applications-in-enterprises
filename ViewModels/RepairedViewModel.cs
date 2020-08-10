using System;
using System.ComponentModel.DataAnnotations;

namespace DingDingPuls.ViewModels
{
    public class RepairedViewModel
    {
        [Required(ErrorMessage = "{0}是必填项")]
        public string CreatNumber { get; set; }

        [Required(ErrorMessage = "{0}是必填项")]
        [DataType(DataType.DateTime)]
        public DateTime BrokenTime { get; set; }

        [Required(ErrorMessage = "{0}是必填项")]
        [DataType(DataType.DateTime)]
        public DateTime StartTime { get; set; }

        [Required(ErrorMessage = "{0}是必填项")]
        [DataType(DataType.DateTime)]
        public DateTime EndTime { get; set; }

        [Required(ErrorMessage = "{0}是必填项"), MaxLength(100, ErrorMessage = "{0}的长度不可超过{1}")]
        public string Workers { get; set; }

        public string Reason { get; set; }
        public string ImgUrl { get; set; }

        public int AssetsId { get; set; }
        public int DepartmentId { get; set; }

        public int IsFinshed { get; set; }
        public decimal Cost { get; set; }
    }
}