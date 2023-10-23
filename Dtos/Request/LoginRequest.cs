using System.ComponentModel.DataAnnotations;

namespace BOOK_STORE_DEMO.Dtos.Request;

public class LoginRequest
{
    [Required(ErrorMessage = "Email là trường bắt buộc")]
    public string? Username { get; set; }
    [Required(ErrorMessage = "Xác nhận mật khẩu là trường bắt buộc")]
    public string? Password { get; set; }
}