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
                Message = "Success",
                ResultObject = string.Empty
            };

        }

        /// <summary>
        /// 设置API调用结果为成功
        /// </summary>
        /// <param name="resultObject">不需要从Data里面读取返回值对象时，存储简单的值对象或者string</param>
        /// <returns></returns>
        public static ApiResult SuccessResult(string resultObject)
        {
            return new ApiResult
            {
                Code = 200,
                Success = true,
                Message = "Success",
                ResultObject = resultObject
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
                Message = "Success",
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
        public static ApiResult<T> SuccessResult(T t)
        {
            var result = new ApiResult<T>();
            result.Success = true;
            result.Code = 200;
            result.ResultObject = t.GetType().Name;
            result.Data = t;
            return result;
        }
    }
}
