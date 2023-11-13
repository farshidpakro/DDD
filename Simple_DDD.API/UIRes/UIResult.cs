using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Simple_DDD.API.UIRes
{
    public class UIResult
    {

    }

    public class ResultData<T>
    {
        public string Code { get; set; }
        public string Massage { get; set; }
        public T Result { get; set; }
    }


    public class BaseApiResult<T> : JsonResult
    {
        public BaseApiResult() : base(null)
        {
            ContentType = "application/json";
        }
        public IActionResult Void()
        {
            Value = new ResultData<T>
            {
                Code = "200",
                Massage = "Sucsess"

            };

            StatusCode = 200;

            return this;
        }
        public IActionResult Success(T result)
        {
            Value = new ResultData<T>
            {
                Code = "200",
                Massage = "Sucsess",
                Result = result
            };

            StatusCode = 200;

            return this;
        }

        public IActionResult Fail(T result, string code, string massage)
        {
            Value = new ResultData<T>
            {
                Code = code,
                Massage = massage,
                Result = result
            };

            StatusCode = 400;

            return this;
        }

        public IActionResult ServerError(T result)
        {
            Value = new ResultData<T>
            {
                Code = "500",
                Massage = "Internal Server Error",
                Result = result
            };

            StatusCode = 500;

            return this;
        }
    }
}