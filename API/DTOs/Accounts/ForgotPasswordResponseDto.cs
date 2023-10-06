using API.Models;

namespace API.DTOs.Accounts
{
    public class ForgotPasswordResponseDto
    {
        public int Otp { get; set; }
        public DateTime ExpiredTime { get; set; }

        //membuat implicit operator untuk update
        public static explicit operator ForgotPasswordResponseDto(Account account)
        {
            return new ForgotPasswordResponseDto
            {
                Otp = account.Otp,
                ExpiredTime = account.ExpiredTime
            };
        }
    }
}

