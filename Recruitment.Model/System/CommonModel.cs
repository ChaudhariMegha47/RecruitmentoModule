﻿namespace Recruitment.Model.System
{
    public class JsonResponseModel
    {
        public bool isError { get; set; } = true;
        public string strMessage { get; set; } = "";
        public string type { get; set; } = PopupMessageType.error.ToString();
        public dynamic? result { get; set; }
        public bool Success { get; set; }
        public string? Message { get; set; }
    }
}
