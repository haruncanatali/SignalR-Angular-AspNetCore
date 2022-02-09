using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace SecimAnaliz.TransactionManager
{
    class Program
    {
        static void Main(string[] args)
        {
            string connectionString =
                @"data source=DESKTOP-SL1S3RQ\SQLEXPRESS;
         initial catalog=DboSecimAnaliz;integrated security=true";
            string partiAdi = null;
            Random rnd = new Random((int)DateTime.Now.Ticks & 0x0000FFFF);
            
            x:
            Console.WriteLine("Press 1 to start this transaction program");
            var giris = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("\n");

            if (giris == 1)
            {
                goto y;
            }
            else
            {
                goto x;
            }

            y:

            var partiler = new List<Parti>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand komut = new SqlCommand("select Id,PartiAdi from Tbl_Parti", connection);
                try
                {
                    connection.Open();
                    using (SqlDataReader reader = komut.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            partiler.Add(new Parti
                            {
                                Id = int.Parse(reader[0].ToString()),
                                PartiAdi = reader[1].ToString()
                            });
                        }

                        reader.Close();
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("Hata meydana geldi.");
                    goto z;
                }
                finally
                {
                    connection.Close();
                }
            }

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    var oySayisi = rnd.Next(1, 100);
                    var seciliPartiIndex = rnd.Next(0, partiler.Count);
                    var seciliParti = partiler[seciliPartiIndex].Id;

                    for (int i = 0; i < oySayisi; i++)
                    {
                        SqlCommand komut = new SqlCommand("insert into Tbl_Oy(SistemGirisTarihi,PartiId) values(@p1,@p2)", connection);
                        komut.Parameters.AddWithValue("@p1", DateTime.Now.ToShortDateString());
                        komut.Parameters.AddWithValue("@p2", seciliParti.ToString());

                        komut.ExecuteNonQuery();
                    }

                    Console.WriteLine("Parti :"+partiler[seciliPartiIndex].PartiAdi+" Gelen Oy :"+oySayisi+"\n");
                }
                catch (Exception e)
                {
                    Console.WriteLine("Hata meydana geldi.");
                    goto z;
                }
                finally
                {
                    connection.Close();
                }
            }

            System.Threading.Thread.Sleep(3500);

            goto y;
            
            z:

            Console.Read();
        }

        public class Parti
        {
            public string PartiAdi { get; set; }
            public int Id { get; set; }
        }
    }
}
