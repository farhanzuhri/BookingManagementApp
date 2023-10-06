namespace API.Utilities.Handler
{
    public class GenerateOTP
    {
        public static int GenerateOTPHandler()
        {
            Random random = new Random();
            int otp = random.Next(100000, 1000000);

            return otp;
        }
    }
}

