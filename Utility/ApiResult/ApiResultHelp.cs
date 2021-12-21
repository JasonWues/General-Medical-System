namespace Utility
{
    public class ApiResultHelp
    {
        /// <summary>
        /// 设置API调用结果为成功
        /// </summary>
        /// <returns></returns>
        public static ApiResult SuccessResult()
        {
            return new ApiResult
            {
                Code = 200,
                Success = true,
                Message = "成功",
                ResultObject = string.Empty
            };
        }

        /// <summary>
        /// 设置API调用结果为成功
        /// </summary>
        /// <param name="message">自定义返回信息</param>
        /// <returns></returns>
        public static ApiResult SuccessResult(string message)
        {
            return new ApiResult
            {
                Code = 200,
                Success = true,
                Message = message,
                ResultObject = string.Empty
            };
        }

        /// <summary>
        /// 设置API调用结果为成功
        /// </summary>
        /// <param name="resultObject">可能返回匿名类要用到？</param>
        /// <returns></returns>
        public static ApiResult SuccessResult(object resultObject)
        {
            return new ApiResult
            {
                Code = 200,
                Success = true,
                Message = "成功",
                ResultObject = resultObject
            };
        }

        /// <summary>
        /// 设置API调用结果为失败
        /// </summary>
        /// <param name="errorCode">错误代码</param>
        /// <param name="errorMessage">错误消息</param>
        /// <returns></returns>
        public static ApiResult ErrorResult(int errorCode, string errorMessage)
        {
            return new ApiResult
            {
                Code = errorCode,
                Success = false,
                Message = errorMessage,
                ResultObject = string.Empty
            };
        }
    }

    public class ApiResultHelp<T>
    {
        /// <summary>
        /// 设置API调用结果为成功(泛型版)
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public static ApiResult<T> SuccessResult(T t, int? count = 0)
        {
            var result = new ApiResult<T>();
            result.Success = true;
            result.Message = "成功";
            result.Code = 200;
            result.Count = count;
            result.ResultObject = t.GetType().Name;
            result.Data = t;
            return result;
        }
    }
}