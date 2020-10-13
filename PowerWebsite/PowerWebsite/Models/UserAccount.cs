using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PowerWebsite.Models
{
    [Table("useraccount")]
    public class UserAccount
    {
        [Key]
        public int id { get; set; }
        public string user_name { get; set; }
        public string password { get; set; }
        public String full_name { get; set; }
        public String phone { get; set; }
        public String email { get; set; }
        public String role { get; set; }
        public int isValid { get; set; }

    }

    public class UserAccountCreate
    {
        [Key]
        public int id { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập tên đăng nhập.")]
        [MinLength(3, ErrorMessage = "Tên đăng nhập ít nhất 3 kí tự.")]
        public string user_name { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập mật khẩu.")]
        [MinLength(6, ErrorMessage = "Mật khẩu ít nhất 6 kí tự.")]
        [DataType(DataType.Password)]
        public string password { get; set; }

        [Required(ErrorMessage = "Vui lòng xác nhận mật khẩu.")]
        [DataType(DataType.Password)]
        [Compare("password", ErrorMessage = "Mật khẩu xác nhận không khớp.")]
        [NotMapped]
        public string password_confirm { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập tên người dùng.")]
        public String full_name { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập số điện thoại người dùng.")]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Số điện thoại không hợp lệ.")]
        public String phone { get; set; }


        [Required(ErrorMessage = "Vui lòng nhập email.")]
        [DataType(DataType.EmailAddress)]
        [EmailAddress(ErrorMessage = "Email không hợp lệ.")]
        public String email { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập chức vụ của người dùng.")]
        public String role { get; set; }
        public int isValid { get; set; }

    }

    public class UserAccountUpdate
    {
        [Key]
        public int id { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập tên đăng nhập.")]
        [MinLength(3, ErrorMessage = "Tên đăng nhập ít nhất 3 kí tự.")]
        public string user_name { get; set; }

        [DataType(DataType.Password)]
        public string password { get; set; }

        [Compare("password", ErrorMessage = "Mật khẩu xác nhận không khớp.")]
        [NotMapped]
        public string password_confirm { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập tên người dùng.")]
        public String full_name { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập số điện thoại người dùng.")]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Số điện thoại không hợp lệ.")]
        public String phone { get; set; }


        [Required(ErrorMessage = "Vui lòng nhập email.")]
        [DataType(DataType.EmailAddress)]
        [EmailAddress(ErrorMessage = "Email không hợp lệ.")]
        public String email { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập chức vụ của người dùng.")]
        public String role { get; set; }
        public int isValid { get; set; }

    }

    public class UserAccLogin
    {
        [Required(ErrorMessage = "Vui lòng nhập tên đăng nhập.")]
        [MinLength(3, ErrorMessage = "Tên đăng nhập ít nhất 3 kí tự.")]
        public string user_name { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập mật khẩu.")]
        [MinLength(6, ErrorMessage = "Mật khẩu ít nhất 6 kí tự.")]
        [DataType(DataType.Password)]
        public string password { get; set; }
    }

    public class UserAccChangePass
    {
        [Required(ErrorMessage = "Vui lòng nhập mật khẩu.")]
        [MinLength(6, ErrorMessage = "Mật khẩu ít nhất 6 kí tự.")]
        [DataType(DataType.Password)]
        public string OldPassword { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập mật khẩu mới.")]
        [MinLength(6, ErrorMessage = "Mật khẩu ít nhất 6 kí tự.")]
        [DataType(DataType.Password)]
        public string NewPassword { get; set; }

        [Required(ErrorMessage = "Vui lòng xác nhận mật khẩu.")]
        [DataType(DataType.Password)]
        [Compare("NewPassword", ErrorMessage = "Mật khẩu xác nhận không khớp.")]
        //[NotMapped]
        public string ConfirmPassword { get; set; }
    }
}