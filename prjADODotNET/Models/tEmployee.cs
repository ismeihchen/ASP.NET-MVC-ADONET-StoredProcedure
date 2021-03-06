//------------------------------------------------------------------------------
// <auto-generated>
//     這個程式碼是由範本產生。
//
//     對這個檔案進行手動變更可能導致您的應用程式產生未預期的行為。
//     如果重新產生程式碼，將會覆寫對這個檔案的手動變更。
// </auto-generated>
//------------------------------------------------------------------------------

namespace prjADODotNET.Models
{
    using System;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;

    public partial class tEmployee
    {
        [DisplayName("員工編號")]
        public int fEmpId { get; set; }
        [DisplayName("員工姓名")]
        [Required(ErrorMessage = "請輸入員工姓名")]
        [MaxLength(10, ErrorMessage = "員工姓名長度不可超過 10 個字元")]
        public string fName { get; set; }
        [DisplayName("員工電話")]
        [Required(ErrorMessage = "請輸入員工電話")]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "員工電話格式不正確")]
        public string fPhone { get; set; }
        [DisplayName("部門編號")]
        [Required(ErrorMessage = "請輸入部門編號")]
        public Nullable<int> fDepId { get; set; }
    }
}
