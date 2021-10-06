using Amazon.Database;
using Amazon.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amazon.Service

{
    public class ConfigurationService
    {
        #region Singleton 
        public static ConfigurationService Instance
        {

            get
            {
                if (instance == null) instance = new ConfigurationService();

                return instance;
            }
        }
        private static ConfigurationService instance { get; set; }

        private ConfigurationService()

        {
        }
        #endregion
        public Config GetConfig(string key)
        {
            using (var context = new AmazonContext())
            {
                return context.Configurations.Find(key);
                //return context.Configurations.Where(a => a.key == key).FirstOrDefault();

            }
        }

    }
}
