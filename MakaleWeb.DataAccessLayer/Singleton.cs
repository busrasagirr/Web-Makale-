using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MakaleWeb.DataAccessLayer
{
    public class Singleton
    {
        public static DatabaseContext db;   // Oraya "static" dememizin sebebi "static metotta" anca böyle tanımlarsak kullanabileceğimiz için.!
        private static object _obj = new object();

        protected Singleton()  // örneklenmesini engellemek için "protected" yaptık!
        {
            ContextOlustur();
        }

        public static void ContextOlustur()   //tek bir nesneye sahip olmak için kullanılır.
        {
            if (db == null)
            {
                lock (_obj)  //multithread uygulamalarda context nesnesinin iki kere oluşturulmasının önüne geçmek için kilitleme işlemi yapılır.
                {
                    if (db == null)
                    {
                        db = new DatabaseContext();
                    }

                }
            }
        }


    }
}
