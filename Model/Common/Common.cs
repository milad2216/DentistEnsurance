namespace Entity.Common
{
    public static class Common
    {

    }
    public enum ReserveStatusEnum { Reserved, Requested, Denied, Done, Canceled }

    public enum ResultCode
    {
        Success = 0,
        Error = 1,
        Exception = 2,
        ValidationError = 3
    }
    public enum UserType
    {
        Admin = 0,
        Referred = 1, // بیمار
        Financial = 2, // مالی
        Secretary = 3 // دندانپزشکی
    }

    public enum MaritalStatus
    {
        Single = 0,
        Married = 1
    }
}