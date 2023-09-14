using System.ComponentModel.DataAnnotations;

namespace BOOK_STORE_DEMO.Dtos
{
    public class UserDto
    {
        [Required(ErrorMessage = "Email là trường bắt buộc")]
        public string? Username { get; set; }
        [Required(ErrorMessage = "Mật khẩu là trường bắt buộc")]
        [DataType(DataType.Password)]
        public string? Password { get; set; }
        [Required(ErrorMessage = "Xác nhận mật khẩu là trường bắt buộc")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Xác nhận mật khẩu không khớp")]
        public string? PasswordConfirm { get; set; }
    }
}
