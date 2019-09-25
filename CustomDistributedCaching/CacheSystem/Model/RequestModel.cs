namespace CachingDistributedSystem.Services.Model
{
    public  class RequestModel
    {
        public RequestType Type { get; set; }
        public string Key { get; set; }
        public string Value { get; set; }

        public static RequestModel ToRequestModel(string str)
        {
            var ret = new RequestModel();
            // GET/SET/REMOVE/REFRESH 
            string[] args = str.Split(" ");

            try
            {
                switch (args[0])
                {
                    case "GET":
                        ret.Type = RequestType.GET; break;
                    case "SET":
                        ret.Type = RequestType.SET; break;
                    case "REMOVE":
                        ret.Type = RequestType.REMOVE; break;
                    case "REFRESH":
                        ret.Type = RequestType.REFRESH; break;
                    default:
                        break;
                }

                ret.Key = args[1];

                if (ret.Type == RequestType.SET)
                {
                    ret.Value = args[2];
                }
            }
            catch  
            {

                return null;
            }

            return ret;
        }
        public static RequestModel ToRequestModel(byte [] data)
        {
            var ret = new RequestModel();
            //  1 GET/ 2 SET/3 REMOVE/REFRESH 

            try
            {
                switch (data[0])
                {
                    case 1: break;
                    case 2: break;
                    case 3: break;
                }
            }
            catch
            {

                return null;
            }

            return ret;
        }
    }

    public enum RequestType { GET, SET, REMOVE, REFRESH }

}
