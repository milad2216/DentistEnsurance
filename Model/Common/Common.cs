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
}