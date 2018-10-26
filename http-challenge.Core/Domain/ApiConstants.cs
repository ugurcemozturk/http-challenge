namespace http_challenge.Core.Domain
{
    public static class ApiConstants
    {
        //DB Connection properties
        public const string ConnectionStringName = "JobPostDatabase";
        //End of DB Connection properties

        //HTTP Header properties
        public const string Basic = "Basic";
        public const string Bearer = "Bearer";
        //End of HTTP Header properties

        //Server side CORS Headers
        public const string CorsHeadersClient = "Access-Control-Allow-Headers";
        public const string CorsMethodClient = "Access-Control-Request-Headers";
        public const string CorsOriginClient = "Access-Control-Request-Headers";
        //End of Server side CORS Headers
    }
}