namespace Foodbrowser.Web.Common.Http
{
    public class BaseResponse<T>
    {
        public bool Success { get; private set; }
        public string Message { get; private set; }
        public T Obj { get; private set; }

        protected BaseResponse()
        {

        }

        public static BaseResponse<T> Create(string message)
        {
            var response = new BaseResponse<T>();
            response.Success = false;
            response.Message = message;
            response.Obj = default(T);
            return response;
        }

        public static BaseResponse<T> Create(string message, T obj)
        {
            var response = new BaseResponse<T>();
            response.Success = true;
            response.Message = message;
            response.Obj = obj;
            return response;
        }
    }
}
