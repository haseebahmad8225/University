using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DataTransferModels.ResponseModels
{
    public sealed class ResponseVM
    {
        private static ResponseVM? instance = null;

        private ResponseVM()
        {
        }

        public static ResponseVM Instance
        {
            get
            {
                //if (instance == null)
                {
                    instance = new ResponseVM();
                }
                return instance;
            }
        }
        public int responseCode { get; set; }
        public string errorMessage { get; set; } = "";
        public string responseMessage { get; set; } = "";
        public dynamic data { get; set; }
    }
}