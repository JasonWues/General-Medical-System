namespace Utility
{
    public class ApiResult
    {
        public int Code { get; set; }

        /// <summary>
        /// API调用是否成功
        /// </summary>
        public bool Success { get; set; } = false;

        /// <summary>
        /// 服务器回应消息提示
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// 数据总数
        /// </summary>
        public int? Count { get; set; }

        /// <summary>
        /// 服务器回应的返回值对象(API调用失败则返回异常对象)
        /// </summary>
        public object ResultObject { get; set; }
    }

    public class ApiResult<T> : ApiResult
    {
        public T Data { get; set; }
    }
}