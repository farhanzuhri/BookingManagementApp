using API.Models;

namespace API.DTOs.Accounts
{
    public class AccountDto : GeneralDto
    {
        public string Password { get; set; }
        public bool IsDeleted { get; set; }
        public int Otp { get; set; }
        public bool IsUsed { get; set; }
        public DateTime ExpiredTime { get; set; }

        public static explicit operator AccountDto(Account account)
        {
            return new AccountDto
            {
                Guid = account.Guid,
                Password = account.Password,
                IsDeleted = account.IsDeleted,
                Otp = account.Otp,
                IsUsed = account.IsUsed,
                ExpiredTime = account.ExpiredTime
            };
        }

        public static implicit operator Account(AccountDto accountDto)
        {
            return new Account
            {
                Guid = accountDto.Guid,
                Password = accountDto.Password,
                IsDeleted = accountDto.IsDeleted,
                Otp = accountDto.Otp,
                IsUsed = accountDto.IsUsed,
                ExpiredTime = accountDto.ExpiredTime,
                ModifiedDate = DateTime.Now
            };
        }
    }
}
