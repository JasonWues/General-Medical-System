namespace Utility.ApiResult
{
    public class ApiResultHelp
    {
        public static ApiResult Success(object data)
        {
            return new ApiResult
            {
                Code = 200,
                Result = data,
                Message = "成功"
            };
        }

        public static ApiResult Error(string msg)
        {
            return new ApiResult
            {
                Code = 500,
                Result = null,
                Message = msg
            };
        }
    }
}