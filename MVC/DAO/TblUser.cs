using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BO;

public partial class TblUser
{
    [Required(ErrorMessage = "Tài khoản không được để trống")]
    public string UserId { get; set; } = null!;
    [Required(ErrorMessage = "Mật khẩu không được để trống")]
  
    public string Password { get; set; } = null!;
    [Required(ErrorMessage = "Họ và tên không được để trống")]
    public string FullName { get; set; } = null!;

    public string Role { get; set; } = null!;
    [Required(ErrorMessage = "Số điện thoại không được để trống")]
    [RegularExpression(@"([0-9]{10})\b", ErrorMessage = "Số điện thoại không hợp lệ")]
    public string Phone { get; set; } = null!;

    [Required(ErrorMessage = "Địa chỉ không được để trống")]
    public string Address { get; set; } = null!;
}
