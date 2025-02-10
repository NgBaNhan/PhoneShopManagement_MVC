using System.ComponentModel.DataAnnotations;

namespace MVC.Models
{
    public class UserDTO
    {
        [Required(ErrorMessage = "Tài khoản không được để trống")]
        public string UserId { get; set; } = null!;
        [Required(ErrorMessage = "Mật khẩu không được để trống")]

        public string Password { get; set; } = null!;


        [Required(ErrorMessage = "Vui lòng nhập lại mật khẩu")]
        [Compare("Password", ErrorMessage = "Mật khẩu nhập lại không khớp")]
        public string ConfirmPassword { get; set; } = null!; 
        [Required(ErrorMessage = "Họ và tên không được để trống")]
        public string FullName { get; set; } = null!;

        public string Role { get; set; } = null!;
        [Required(ErrorMessage = "Số điện thoại không được để trống")]
        [RegularExpression(@"([0-9]{10})\b", ErrorMessage = "Số điện thoại không hợp lệ")]
        public string Phone { get; set; } = null!;

        [Required(ErrorMessage = "Địa chỉ không được để trống")]
        public string Address { get; set; } = null!;
    }
}
